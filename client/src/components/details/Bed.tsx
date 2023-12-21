import { runInAction } from "mobx";
import { observer } from "mobx-react-lite";
import { MouseEvent, SyntheticEvent, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { store, useStore } from "../../app/stores/store";
import LoadingComponent from "../layout/LoadingComponent";
import { Button, DropdownItemProps, Form, Segment, SegmentGroup } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";




const BedComponent = observer(function Bed() {   
    const options: DropdownItemProps[] | { key: string; text: string; value: string; image: { avatar: boolean; src: string; }; }[] | undefined = [];

    const [plantId, setPlantId] = useState('');
    const { bedsStore } = useStore();
    const { selectedBed, loadBed } = bedsStore;

    const { id } = useParams();

    useEffect(() => {
        async function fetchData() {
            if (id)
                loadBed(id);
        }

        fetchData();

    }, [id, loadBed])

    store.globalStore.plantDTOList.forEach((plant: PlantDTO) => {

        options.push({
            key: plant.id,
            text: plant.name,
            value: plant.id,
            image: { avatar: false, src: `/src/assets/plants/${plant.imageSrc}` }
        })
    })
    function AddPlantImage() {

        const imagePath = 'url(/src/assets/plants/' + store.globalStore.getPlantDTO(plantId)?.imageSrc + ")";
        const activeCells = new Array<Cell>();

        //const thisBed: Bed = store.bedsStore.bedList.get("1");
        
        //console.log(thisBed);

        runInAction(() => {
            selectedBed.cells.forEach((cell) => {
                if (cell.isActive) {
                    activeCells.push(cell);
                }
            });

        });

        const minColumn = Math.min(...activeCells.map((a) => a.x));
        const maxColumn = Math.max(...activeCells.map((a) => a.x));
        const minRow = Math.min(...activeCells.map((a) => a.y));
        const maxRow = Math.max(...activeCells.map((a) => a.y));

        const toBeDeleted = new Array<Cell>();
        const toBeDeletedId = new Array<string>();

        activeCells.forEach(cell => {
            if (cell.x != minColumn || cell.y != minRow) {
                toBeDeleted.push(cell);
                toBeDeletedId.push(cell.id);
            }
        });
        runInAction(() => {
            selectedBed.cells = selectedBed.cells.filter(cell => {
                return toBeDeleted.indexOf(cell) < 0;
            })

            //console.log(store.bedsStore.beds[0].cells.length);

            const maxC = (maxColumn - minColumn) + 1;
            console.log(maxC);
            const maxR = (maxRow - minRow) + 1;
            console.log(maxR);

            console.log(minColumn + '/' + minRow + "/ span " + maxC + "/ span " + maxR);
            selectedBed.cells.forEach((cell) => {

                if (cell.x == minColumn && cell.y == minRow) {
                    cell.gridArea = minColumn + ' / ' + minRow + " / span " + maxC + " / span " + maxR;
                    cell.backgroundImage = imagePath;
                }
            });
        })


        runInAction(() => {
            selectedBed.cells.forEach((cell) => {
                if (cell.isActive) {
                    cell.isActive = false;
                }
            });
        });
        //console.log(toBeDeleted);
        store.bedsStore.deleteCells(toBeDeletedId);
        store.bedsStore.updateBed(selectedBed);
    }


    function handleDropChange(event: SyntheticEvent<HTMLElement, Event>, value) {
        setPlantId(value.value);
    }
    function handleClick(event: MouseEvent<HTMLDivElement, MouseEvent>) {


        const thisCell = event.currentTarget;
        const x = Number(thisCell.dataset.x);
        const y = Number(thisCell.dataset.y);

        runInAction(() => { 
            selectedBed.cells.forEach(cell => {
                    if (cell.x == x && cell.y == y)

                        cell.isActive = cell.isActive ? false : true;            
            });
        });

    }
    function generateCellStyle(cell: Cell): React.CSSProperties {

        return { gridArea: cell.gridArea, backgroundImage: cell.backgroundImage, backgroundSize: "cover" };
    }

    function renderCell(cell: Cell) {
        return (
            <div className={'grid-item' + (cell.isActive ? " clicked" : "")} onClick={(e) => handleClick(e)}
                data-x={cell.x} data-y={cell.y} key={cell.x + '_' + cell.y}
                id={cell.x + '_' + cell.y}
                style={generateCellStyle(cell)}
            >
            </div>
        )
    }

    function generateStyle(): React.CSSProperties {
        let value = "";

        for (let x = 0; x < selectedBed.numOfColumns; x++) {
            value = value + "50px ";
        }

        let rowValue = ""
        for (let x = 0; x < selectedBed.numOfRows; x++) {
            rowValue = rowValue + "50px ";
        }

        return { gridTemplateColumns: value, gridTemplateRows: rowValue }; 
    }

    /*function saveBed() {
        store.bedsStore.saveBed(selectedBed);
    }*/

    if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )
    return (
        <SegmentGroup>        
                <Segment>
                    <Form onSubmit={AddPlantImage}>
                        <Form.Field>
                            <Form.Dropdown options={options} onChange={handleDropChange} />
                            </Form.Field>
                        <Form.Button type='submit'>
                            Vlozit rostlinu
                        </Form.Button>
                </Form>
                {/*<Button icon='save' color='blue' content='Ulozit' onClick={saveBed} />*/}
            </Segment>
            <Segment>
        <div className='grid-container' id={`bed_${selectedBed.id}`} key={`bed_${selectedBed.id}`} style={generateStyle()}>
            {
                selectedBed.cells.map((cell) => renderCell(cell))
            }
                </div>
            </Segment>
        </SegmentGroup>
    )
})

export default BedComponent;