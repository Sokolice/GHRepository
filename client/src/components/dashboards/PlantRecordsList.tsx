/* eslint-disable @typescript-eslint/no-unused-vars */
import { observer } from "mobx-react-lite";
import { Button, Card, Container, Divider, Image, Popup, Progress, Item, ItemContent, ItemHeader, Label } from "semantic-ui-react";
import { store, useStore } from "../../app/stores/store";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { SyntheticEvent, useState } from "react";
import { PlantDTO } from "../../models/PlantDTO";
import LoadingComponent from "../layout/LoadingComponent";
import PlantRecordFormComponent from "./PlantRecordForm";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSnowflake } from "@fortawesome/free-solid-svg-icons";

const RenderPlantRecord = (plantRecord: PlantRecordDTO, plant: PlantDTO,
    handlePlantRecordDelete: (e: SyntheticEvent<HTMLButtonElement>, id: string) => void, openForm: (plantRecord: PlantRecordDTO) => void) => {

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
                <Card.Header>Datum vsadby: </Card.Header>{new Date(plantRecord.datePlanted).toLocaleString('cs-CZ', options)}
                <Divider />
                <Card.Header>Mnozstni: </Card.Header>{plantRecord.amountPlanted}
                <Divider />
                {plantRecord.progress >= 100 ?
                    <Progress percent={plantRecord.progress} progress success />
                :
                    <Progress percent={plantRecord.progress} progress />
                }
                <Popup content='Smazat' trigger={<Button icon='minus' color='red' onClick={(e) => handlePlantRecordDelete(e, plantRecord.id)} />} />
                <Popup content='Recepty' trigger={<Button icon='utensils' color='blue' as={Link} to={`/recipeHints/${plant.name}`} />} />
                <Divider hidden />
                <Button icon='undo' onClick={() => openForm(plantRecord)} content="Uprav me" key={plantRecord.id} /> 
                <Divider hidden />
                <Button icon='info' as={Link} to={`/plants/${plant.id}/plantrecords`} content="Detail" />
            </Card.Content>
        </Card>
    )
}


const PlantRecordsListComponent = observer(function PlantRecordsList() {
    const { globalStore } = useStore();
    const { stats } = globalStore;
   
    const [open, setOpen] = useState(false);
    const [plantRecord, setRecord] = useState({
        id: '',
        plantId: '',
        datePlanted: '',
        amountPlanted: 0,
        progress: 0
    });

   
   
    function handlePlantRecordDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
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
        <Container>
            <Container>
             {stats?.freezeAlert ?
                <Item>
                    <ItemContent verticalAlign='middle'>
                        <ItemHeader>
                                <Label color='red'>
                                    <FontAwesomeIcon icon={faSnowflake} />
                                </Label>
                            Hrozi mrazy! Zakryj rotliny neodolavajici mrazu
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
                            return RenderPlantRecord(plantRecord, store.globalStore.getPlantDTO(plantRecord.plantId), handlePlantRecordDelete, openForm)
                        })
                    }

                    <PlantRecordFormComponent plant={store.globalStore.getPlantDTO(plantRecord.plantId)} isOpen={open} onClose={onClose} onOpen={onOpen} plantRecordId={plantRecord.id} />
                </Card.Group>
            </Container>

        </Container>
       
    )
})

export default PlantRecordsListComponent;