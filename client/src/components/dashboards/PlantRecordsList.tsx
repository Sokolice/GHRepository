/* eslint-disable @typescript-eslint/no-unused-vars */
import { observer } from "mobx-react-lite";
import { Button, Card, Container, Divider, Image, Popup, Progress, Item, ItemContent, ItemHeader, Label } from "semantic-ui-react";
import { store, useStore } from "../../app/stores/store";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { useEffect, useState } from "react";
import { PlantDTO } from "../../models/PlantDTO";
import LoadingComponent from "../layout/LoadingComponent";
import PlantRecordFormComponent from "./PlantRecordForm";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSnowflake, faWheatAwn } from "@fortawesome/free-solid-svg-icons";
import ConfirmationDeleteComponent from "../details/ConfirmationDelete";
import HarvestComponent from "../details/HarvestComponent";

const RenderPlantRecord = (plantRecord: PlantRecordDTO, plant: PlantDTO, openForm: (plantRecord: PlantRecordDTO) => void, openDeleteForm: (id: string) => void, openHarvestForm: (plant: PlantDTO) => void) => {

    const options = {
        year: "numeric",
        month: "long",
        day: "numeric",
    };

   
    if (!plant)
        return (
            <LoadingComponent />
        )

    return (
        <Card key={plantRecord.id}>
            <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
            <Card.Content>
                <Card.Header >{plant.name}</Card.Header>
            </Card.Content>
            <Card.Content extra>
                <Card.Header>Datum výsadby: </Card.Header>{new Date(plantRecord.datePlanted).toLocaleString('cs-CZ', options)}
                <Divider />
                <Card.Header>Množství: </Card.Header>{plantRecord.amountPlanted}
                <Divider />
                {plantRecord.progress >= 100 ?
                    <Progress percent={plantRecord.progress} progress success />
                :
                    <Progress percent={plantRecord.progress} progress />
                }
                <Popup content='Smazat' trigger={<Button icon='minus' color='red' onClick={() => openDeleteForm(plantRecord.id)} />} />
                <Popup content='Recepty' trigger={<Button icon='utensils' color='blue' as={Link} to={`/recipeHints/${plant.name}`} />} />
                {plantRecord.note != "" ?
                    <Popup content={plantRecord.note} trigger={<Button icon='comment' color='teal' />} />

                :
                    null}
                <Divider hidden />
                <Button icon='undo' onClick={() => openForm(plantRecord)} content="Uprav mne" key={plantRecord.id} /> 
                <Divider hidden />
                <Popup content="Detail" trigger={<Button icon='info' as={Link} to={`/plants/${plant.id}/plantrecords`} />} />
                <Popup content="Sklidit" trigger={<Button onClick={() => openHarvestForm(plant)} ><FontAwesomeIcon icon={faWheatAwn} /> </Button>} />
             </Card.Content>
        </Card>
    )
}


const PlantRecordsListComponent = observer(function PlantRecordsList() {

    useEffect(() => {
        window.scrollTo(0, 0)
    }, [])
    const { globalStore } = useStore();
    const { stats } = globalStore;
   
    const [open, setOpen] = useState(false);
    const [deleteOpen, setDeleteOpen] = useState(false);
    const [harvestOpen, setHarvestOpen] = useState(false);
    const [plantRecord, setRecord] = useState({
        id: '',
        plantId: '',
        datePlanted: '',
        amountPlanted: 0,
        progress: 0
    });
    const [recordId, setRecordId] = useState("");
    const [plantDTO, setPlantDTO] = useState({
        id: '',
        name: '',
        isHybrid: false,
        directSewing: false,
        germinationTemp: 0,
        cropRotation: 0,
        description: '',
        imageSrc: '',
        repeatedPlanting: 0
    });
   function openForm(plantRecord: PlantRecordDTO) {
        setOpen(true);
        setRecord(plantRecord);
    }

    function openDeleteForm(id: string) {
        setDeleteOpen(true);
        setRecordId(id);
    }
    function openHarvestForm(plant: PlantDTO) {
        setHarvestOpen(true);
        setPlantDTO(plant);
    }
    function onDeleteOpen() {
        setDeleteOpen(true);
    }

    function onDeleteClose() {
        setDeleteOpen(false);
    }

    function onOpen() {
        setOpen(true);
    }

    function onClose() {
        setOpen(false);
    }

    function onHarvestOpen() {
        setHarvestOpen(true);
    }

    function onHarvestClose() {
        setHarvestOpen(false);
    }

    if (store.globalStore.loading)
        return (
            <LoadingComponent />
    )

    return (
        <Container>
            <Container>
             {stats?.freezeAlert ?
                <Item>
                    <ItemContent verticalAlign='middle'>
                        <ItemHeader>
                                <Label color='red'>
                                    <FontAwesomeIcon icon={faSnowflake} />
                                </Label>
                            Hrozí mrazy! Zakryj rotliny neodolávající mrazu
                        </ItemHeader>
                    </ItemContent>
                </Item>
                : null
            }

            </Container>
            <Container>
                <Card.Group itemsPerRow='6'>
                    {
                        store.plantRecordStore.plantRecords.map((plantRecord: PlantRecordDTO) => {
                            return RenderPlantRecord(plantRecord, store.globalStore.getPlantDTO(plantRecord.plantId), openForm, openDeleteForm, openHarvestForm)
                        })
                    }

                    <PlantRecordFormComponent plant={store.globalStore.getPlantDTO(plantRecord.plantId)} isOpen={open} onClose={onClose} onOpen={onOpen} plantRecordId={plantRecord.id} />
                    <ConfirmationDeleteComponent isOpen={deleteOpen} onClose={onDeleteClose} onOpen={onDeleteOpen} plantRecordId={recordId} />
                    <HarvestComponent isOpen={harvestOpen} onClose={onHarvestClose} onOpen={onHarvestOpen} plantDTO={plantDTO} />
                </Card.Group>
            </Container>

        </Container>
       
    )
})

export default PlantRecordsListComponent;