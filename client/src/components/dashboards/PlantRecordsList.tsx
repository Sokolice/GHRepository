/* eslint-disable @typescript-eslint/no-unused-vars */
import { observer } from "mobx-react-lite";
import { Button, Card, Divider, Header, Image, Progress } from "semantic-ui-react";
import { store, useStore } from "../../app/stores/store";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { SyntheticEvent, useEffect, useState } from "react";
import { PlantDTO } from "../../models/PlantDTO";
import LoadingComponent from "../layout/LoadingComponent";
import PlantRecordFormComponent from "./PlantRecordForm";

const RenderPlantRecord = (plantRecord: PlantRecordDTO, plant: PlantDTO,
    handleActivityDelete: (e: SyntheticEvent<HTMLButtonElement>, id: string) => void, openForm: (plantRecord: PlantRecordDTO) => void) => {

    const options = {
        year: "numeric",
        month: "long",
        day: "numeric",
    };

    return (
        <Card key={plantRecord.id}>
            <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
            <Card.Content>
                <Card.Header>{plant.name}</Card.Header>
            </Card.Content>
            <Card.Content extra>
                <Card.Header>Datum vysadby: </Card.Header>{new Date(plantRecord.datePlanted).toLocaleString('cs-CZ', options)}
                <Divider />
                <Card.Header>Mnozstni: </Card.Header>{plantRecord.amountPlanted}
                <Divider />
                <Progress percent={plantRecord.progress} progress />
                <Button icon='minus' color='red' onClick={(e) => handleActivityDelete(e, plantRecord.id)} />
                <Button icon='undo' onClick={() => openForm(plantRecord)} content="Uprav me" key={plantRecord.id} /> 
            </Card.Content>
        </Card>
    )
}


const PlantRecordsListComponent = observer(function PlantRecordsList() {

    const [open, setOpen] = useState(false);
    const [plantRecord, setRecord] = useState({
        id: '',
        plantId: '',
        datePlanted: '',
        amountPlanted: 0,
        progress: 0
    });
    
    function handleActivityDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        store.plantRecordStore.deletePlantRecord(id);
    }

    function openForm(plantRecord: PlantRecordDTO) {
        setOpen(true);
        setRecord(plantRecord);
    }

    function onOpen() {
        setOpen(true);
    }

    function onClose() {
        setOpen(false);
    }

    if (store.globalStore.loading)
        return (
            <LoadingComponent />
    )

    return (
        <Card.Group itemsPerRow='6'>
            {
                store.plantRecordStore.plantRecords.map((plantRecord: PlantRecordDTO) =>
                {
                    return RenderPlantRecord(plantRecord, store.globalStore.getPlantDTO(plantRecord.plantId), handleActivityDelete, openForm)
                })
            }

            <PlantRecordFormComponent plant={store.globalStore.getPlantDTO(plantRecord.plantId)} isOpen={open} onClose={onClose} onOpen={onOpen} plantRecordId={plantRecord.id} />
        </Card.Group>
    )
})

export default PlantRecordsListComponent;