import { runInAction } from "mobx";
import { observer } from "mobx-react-lite";
import { MouseEvent, ReactNode, SyntheticEvent, useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { store, useStore } from "../../app/stores/store";
import LoadingComponent from "../layout/LoadingComponent";
import { Button, Divider, DropdownItemProps, Form, FormGroup, Header, Label, Segment, SegmentGroup } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { Cell } from "../../models/Cell";
import { DropItem } from "../../models/DropItem";
import { dateOptions } from "../../app/options/dateOptions";




const BedComponent = observer(function Bed() {
    const options: DropdownItemProps[] | DropItem [] | undefined=[];

    const [plantId, setPlantId] = useState('');
    const [thisPlantRecordId, setPlantRecordId] = useState('');
    const { bedsStore, globalStore, plantRecordStore, plantStore } = useStore();
    const { selectedBed, loadBed } = bedsStore;
    const { loadPlantRecords, plantRecordMap } = plantRecordStore;
    const { allPlantsRelations, loadAllPlantsRelations } = plantStore;

    const { loadPlantDTO, plantDTOList } = globalStore;

    const { id } = useParams();

    useEffect(() => {
        if (allPlantsRelations.length <= 0)
            loadAllPlantsRelations();
        if (plantDTOList.size <= 0)
            loadPlantDTO();
        if (plantRecordMap.size <= 0)
            loadPlantRecords();
        async function fetchData() {
            if (id)
                await loadBed(id);
        }
        fetchData();

    }, [id, loadBed, loadPlantRecords, plantRecordMap.size, loadPlantDTO, plantDTOList.size, allPlantsRelations.length, loadAllPlantsRelations])

    

    function pushToOptions(key: string, text: string, value: string, image: string, avoid: boolean, companion: boolean) {

        const opt: DropItem = {
            key: key,
            text: text,
            value: value,
            image: {avatar: false, src: `/src/assets/plants/${image}`}
        }

        if (avoid)
            opt.label = { color: 'red', circular: true, empty: true };

        if (companion)
            opt.label = { color: 'green', circular: true, empty: true };
            

        options.push(opt);
    }
   
    function loadDropDownItems() {
        if (selectedBed?.bed.cropRotation > 0 && selectedBed?.bed.isDesign) {
            store.globalStore.plantDTOList.forEach((p) => {
                //console.log(p.name + " trat: " + p.cropRotation);
                if (p.cropRotation == selectedBed.bed.cropRotation || (p.cropRotation == 23 && (selectedBed.bed.cropRotation == 2 || selectedBed.bed.cropRotation == 3))) {
                    let avoid = false;
                    let companion = false;

                    if (selectedBed.avoidPlantsIds.length > 0)
                        if (selectedBed.avoidPlantsIds.includes(p.id))
                            avoid = true;

                    if (selectedBed.companionPlantsIds.length > 0)
                        if (selectedBed.companionPlantsIds.includes(p.id))
                            companion = true;
                    pushToOptions(p.id, p.name, p.id, p.imageSrc, avoid, companion)
                }
                else {
                    let avoid = false;
                    let companion = false;

                    if (selectedBed.avoidPlantsIds.length > 0)
                        if (selectedBed.avoidPlantsIds.includes(p.id))
                            avoid = true;

                    if (selectedBed.companionPlantsIds.length > 0)
                        if (selectedBed.companionPlantsIds.includes(p.id))
                            companion = true;
                    pushToOptions(p.id, p.name, p.id, p.imageSrc, avoid, companion)
                }
            })
        }
        else if (selectedBed.bed.isDesign) {
            store.globalStore.plantDTOList.forEach((p) => {
                //console.log(p.name + " trat: " + p.cropRotation);
                    let avoid = false;
                    let companion = false;

                if (selectedBed.avoidPlantsIds.length > 0)
                    if (selectedBed.avoidPlantsIds.includes(p.id))
                            avoid = true;

                if (selectedBed.companionPlantsIds.length > 0)
                    if (selectedBed.companionPlantsIds.includes(p.id))
                            companion = true;
                    pushToOptions(p.id, p.name, p.id, p.imageSrc, avoid, companion)                
            })
        }
        else { 
            store.plantRecordStore.plantRecordMap.forEach((plantRecord: PlantRecordDTO) => {
                //console.log(plantRecord);
                //console.log(store.globalStore.plantDTOList);
                const plant: PlantDTO = store.globalStore.getPlantDTO(plantRecord.plantId);
                let avoid = false;
                let companion = false;

                if (selectedBed.avoidPlantsIds.includes(plant.id))
                    avoid = true;

                if (selectedBed.companionPlantsIds.includes(plant.id))
                    companion = true;

                pushToOptions(plantRecord.id, plant.name + " - " + plantRecord.datePlanted.toLocaleString('cs-CZ', dateOptions), plant.id, plant.imageSrc, avoid, companion); 
            })
        }
            return options;
    }

    function AddPlantImage() {
        const plant: PlantDTO = store.globalStore.getPlantDTO(plantId);

        const imagePath = 'url(/src/assets/plants/' + plant?.imageSrc + ")";
        const activeCells = new Array<Cell>();

        runInAction(() => {
            selectedBed?.cells.forEach((cell) => {
                if (cell.isActive) {
                    activeCells.push(cell);
                }
            });

        });

        const minColumn = Math.min(...activeCells.map((a) => a.x));
        const maxColumn = Math.max(...activeCells.map((a) => a.x));
        const minRow = Math.min(...activeCells.map((a) => a.y));
        const maxRow = Math.max(...activeCells.map((a) => a.y));
        

        runInAction(() => {
            const maxC = (maxColumn - minColumn) + 1;
            const maxR = (maxRow - minRow) + 1;


            selectedBed?.cells.forEach((cell) => {

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
            selectedBed?.cells.forEach((cell) => {
                if (cell.isActive) {
                    cell.isActive = false;
                }
            });
        });
        selectedBed?.plants.push(plant);
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

        store.bedsStore.updateBed(selectedBed);
    }

    function renderCell(cell: Cell) {

        if (cell.isHidden)
            return;
        function showPlantRecordDetails(): ReactNode {
            //console.log(cell.plantRecordId);
            if (cell.plantRecordId != "") {
                //console.log(cell.plantRecordId);
               
                const plantRecord: PlantRecordDTO = store.plantRecordStore.getPlantRecord(cell.plantRecordId);

                //console.log(store.plantRecordStore.plantRecordMap);

                const id = selectedBed?.bed.isDesign ? cell.plantRecordId : plantRecord.plantId
                if (id) {
                    const plant = store.globalStore.getPlantDTO(id);
                    if (plant) {
                        return <Label className="lbl-name" as={Link} to={selectedBed?.bed.isDesign ? `/plants/${id}/beds/${selectedBed.bed.id}` : '/plantrecords'} >
                            {plant?.name} {selectedBed?.bed.isDesign ? null : ": " + plantRecord.datePlanted}
                        </Label>
                    }
                    else
                        return
                }
            }
            
        }

        return (
            <div className={'grid-item' + (cell.isActive ? " clicked" : "")}
                onClick={(e) => handleClick(e)}
                data-x={cell.x}
                data-y={cell.y}
                key={cell.x + '_' + cell.y}
                id={cell.x + '_' + cell.y}
                style={generateCellStyle(cell)}
            >
                {showPlantRecordDetails()}
                {cell.plantRecordId != "" ?
                    <Button icon='minus'  size='tiny' onClick={() => deleteClick(cell.objectID)} className='no_print, dell_Cell' />
                    :
                    null} 
            </div>
        )
    }

    function generateStyle(): React.CSSProperties {
        let value = "";

        for (let x = 0; x < selectedBed?.bed.numOfColumns; x++) {
            value = value + "60px ";
        }

        let rowValue = ""
        for (let x = 0; x < selectedBed?.bed.numOfRows; x++) {
            rowValue = rowValue + "60px ";
        }

        return { gridTemplateColumns: value, gridTemplateRows: rowValue }; 
    }

    function print(){
        window.print();
    }


    if (store.globalStore.loading || !selectedBed)
        return (
            <LoadingComponent />
        )
    return (
        <SegmentGroup>        
            <Segment>
                <Header>{selectedBed.bed.name}</Header>
                    <Form onSubmit={AddPlantImage}>
                    <Form.Field>
                        <Form.Dropdown options={loadDropDownItems()} onChange={handleDropChange} placeholder='Výběr' scrolling />
                    </Form.Field>
                    <Form.Button type='submit' content="Přidat rostlinu"
                        labelPosition='right'
                        icon='checkmark'
                        positive />
                            
                </Form>
                {/*<Button icon='save' color='blue' content='Ulozit' onClick={saveBed} />*/}
            </Segment>
            <Segment>
                {selectedBed.bed.cropRotation > 0 ? (
                    <Label color='green' ribbon>
                        Pěstování v {selectedBed.bed.cropRotation}. trati
                    </Label>) : null
                }
                <Divider hidden />
                {selectedBed.bed.isDesign ? (
                    <Label color='blue' ribbon>
                        Návrh
                    </Label>) : null
                }

                <div className='grid-container printable' id={`bed_${selectedBed.bed.id}`} key={`bed_${selectedBed.bed.id}`} style={generateStyle()}>
            {
                selectedBed.cells.map((cell) => 
                renderCell(cell))
            }
                    </div>

                <div className='hidden center'>
                    {"delka " + selectedBed.bed.length + " m ---- " + "šířka" + selectedBed.bed.width + " m"}
                    </div>
                </Segment>
            <Segment>
                <Button onClick={() => print()} content='Tisk' />
            </Segment>
        </SegmentGroup>
    )
})

export default BedComponent;