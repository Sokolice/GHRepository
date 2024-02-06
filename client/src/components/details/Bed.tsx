import { runInAction } from "mobx";
import { observer } from "mobx-react-lite";
import { MouseEvent, ReactNode, SyntheticEvent, useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { store, useStore } from "../../app/stores/store";
import LoadingComponent from "../layout/LoadingComponent";
import { Button, DropdownItemProps, Form, Label, Segment, SegmentGroup } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { Cell } from "../../models/Cell";




const BedComponent = observer(function Bed() {   
    const options: DropdownItemProps[] | { key: string; text: string; value: string; image: { avatar: boolean; src: string; }; }[] |undefined=[];

    const [plantId, setPlantId] = useState('');
    const [thisPlantRecordId, setPlantRecordId] = useState('');
    const { bedsStore, globalStore, plantRecordStore } = useStore();
    const { selectedBed, loadBed } = bedsStore;
    const { loadPlantRecords, plantRecordMap } = plantRecordStore;

    const { loadPlantDTO, plantDTOList } = globalStore;

    const { id } = useParams();

    useEffect(() => {
        if (plantDTOList.size <= 0)
            loadPlantDTO();
        if (plantRecordMap.size <= 0)
            loadPlantRecords();
        async function fetchData() {
            if (id)
                await loadBed(id);
        }
        fetchData();

    }, [id, loadBed, loadPlantRecords, plantRecordMap.size, loadPlantDTO, plantDTOList.size])

   
    function loadDropDownItems() {
        if (selectedBed.isDesign) {
            store.globalStore.plantDTOList.forEach((plant) => {
                options.push({
                    key: plant.id,
                    text: plant.name,
                    value: plant.id,
                    image: { avatar: false, src: `/src/assets/plants/${plant.imageSrc}` }
                })
            })
        }
        else { 
            store.plantRecordStore.plantRecordMap.forEach((plantRecord: PlantRecordDTO) => {
            
                const plant: PlantDTO = store.globalStore.getPlantDTO(plantRecord.plantId);

                options.push({
                    key: plantRecord.id,
                    text: plant.name + ": " + plantRecord.datePlanted,
                    value: plant.id,
                    image: { avatar: false, src: `/src/assets/plants/${plant.imageSrc}` }
                })
            })
        }
            return options;
    }

    function AddPlantImage() {
        //console.log("id:" + plantId);
        const plant: PlantDTO = store.globalStore.getPlantDTO(plantId);

        const imagePath = 'url(/src/assets/plants/' + plant?.imageSrc + ")";
        const activeCells = new Array<Cell>();

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

        //const toBeDeleted = new Array<Cell>();
        //const toBeDeletedId = new Array<string>();

        /*activeCells.forEach(cell => {
            if (cell.x != minColumn || cell.y != minRow) {
                cell.isHidden = true;
                //toBeDeleted.push(cell);
                //toBeDeletedId.push(cell.id);
            }
        });*/

        runInAction(() => {
            /*selectedBed.cells = selectedBed.cells.filter(cell => {
                return toBeDeleted.indexOf(cell) < 0;
            })*/

            const maxC = (maxColumn - minColumn) + 1;
            const maxR = (maxRow - minRow) + 1;


            selectedBed.cells.forEach((cell) => {

                if ((cell.x != minColumn || cell.y != minRow) && cell.isActive) {
                    cell.isHidden = true;
                    cell.plantRecordId = thisPlantRecordId;
                    cell.objectID = minColumn + "-" + minRow + "-" + thisPlantRecordId;
                }

                if (cell.x == minColumn && cell.y == minRow) {
                    cell.gridArea = minColumn + ' / ' + minRow + " / span " + maxC + " / span " + maxR;
                    cell.backgroundImage = imagePath;
                    cell.plantRecordId = thisPlantRecordId;
                    cell.objectID = minColumn + "-" + minRow + "-" + thisPlantRecordId;
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

        //store.bedsStore.deleteCells(toBeDeletedId);
        store.bedsStore.updateBed(selectedBed);
    }


    function handleDropChange(e: SyntheticEvent<HTMLElement, Event>, data) {
        setPlantId(data.value);
        const key = options?.find(a => a.value == data.value);

        setPlantRecordId(key?.key);
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

        store.bedsStore.updateBed(selectedBed);

    }
    function generateCellStyle(cell: Cell): React.CSSProperties {

        return { gridArea: cell.gridArea, backgroundImage: cell.backgroundImage, backgroundSize: "cover" };
    }

    function deleteClick(objectID: string) {

        selectedBed.cells.forEach(cell => {
            if (cell.objectID == objectID)
            {
                runInAction(() => {
                    cell.backgroundImage = "";
                    cell.gridArea = " ";
                    cell.isHidden = false;
                    cell.plantRecordId = "";
                    cell.objectID = "";
                    cell.isActive = false;
                })
            }
        })
    }

    function renderCell(cell: Cell) {

        if (cell.isHidden)
            return;
        function showPlantRecordDetails(): ReactNode {

            if (cell.plantRecordId != "") {
               
                const plantRecord: PlantRecordDTO = store.plantRecordStore.getPlantRecord(cell.plantRecordId);
                const id = selectedBed.isDesign ? cell.plantRecordId : plantRecord.plantId
                if (id) {
                    const plant = store.globalStore.getPlantDTO(id);
                    if (plant) {
                        return <Label as={Link} to={selectedBed.isDesign ? `/plants/${id}/beds/${selectedBed.id}` : '/plantrecords'} >
                            {plant?.name} {selectedBed.isDesign ? null : ": " + plantRecord.datePlanted}
                        </Label>
                    }
                    else
                        return
                }
            }
            
        }

        return (
            <div className={'grid-item' + (cell.isActive ? " clicked" : "")} onClick={(e) => handleClick(e)}
                data-x={cell.x} data-y={cell.y} key={cell.x + '_' + cell.y}
                id={cell.x + '_' + cell.y}
                style={generateCellStyle(cell)}
            >
                {showPlantRecordDetails()}
                {cell.plantRecordId != "" ? <Button icon='minus' size='tiny' onClick={() => deleteClick(cell.objectID)} /> : null} 
            </div>
        )
    }

    function generateStyle(): React.CSSProperties {
        let value = "";

        for (let x = 0; x < selectedBed.numOfColumns; x++) {
            value = value + "60px ";
        }

        let rowValue = ""
        for (let x = 0; x < selectedBed.numOfRows; x++) {
            rowValue = rowValue + "60px ";
        }

        return { gridTemplateColumns: value, gridTemplateRows: rowValue }; 
    }


    if (store.globalStore.loading || !selectedBed)
        return (
            <LoadingComponent />
        )
    return (
        <SegmentGroup>        
            <Segment>
                    <Form onSubmit={AddPlantImage}>
                    <Form.Field>
                        <Form.Dropdown options={loadDropDownItems()} onChange={handleDropChange} placeholder='Výběr' scrolling />
                            </Form.Field>
                        <Form.Button type='submit'>
                            Vložit rostlinu
                    </Form.Button>
                </Form>
                {/*<Button icon='save' color='blue' content='Ulozit' onClick={saveBed} />*/}
            </Segment>
            <Segment>
                {selectedBed.isDesign ? (
                    <Label color='blue' ribbon>
                        Návrh
                    </Label>) : null
                }
               
        <div className='grid-container' id={`bed_${selectedBed.id}`} key={`bed_${selectedBed.id}`} style={generateStyle()}>
            {
                selectedBed.cells.map((cell) => 
                renderCell(cell))
            }
                </div>
            </Segment>
        </SegmentGroup>
    )
})

export default BedComponent;