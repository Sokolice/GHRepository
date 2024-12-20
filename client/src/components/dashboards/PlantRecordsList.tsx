/* eslint-disable @typescript-eslint/no-unused-vars */
import { observer } from "mobx-react-lite";
import { Button, Card, Container, Divider, Image, Popup, Progress, Item, ItemContent, ItemHeader, Label, Checkbox } from "semantic-ui-react";
import { store, useStore } from "../../app/stores/store";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { useEffect } from "react";
import { PlantDTO } from "../../models/PlantDTO";
import LoadingComponent from "../layout/LoadingComponent";
import PlantRecordFormComponent from "./PlantRecordForm";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSnowflake, faWheatAwn } from "@fortawesome/free-solid-svg-icons";
import HarvestComponent from "../details/HarvestComponent";
import { dateOptions } from "../../app/options/dateOptions";
import ConfirmationDeleteComponent from "../details/ConfirmationDelete";

const RenderPlantRecord = (plantRecord: PlantRecordDTO, plant: PlantDTO | undefined) => {

    function deleteRecord() {
        if (plantRecord.id != '') {
            store.plantRecordStore.deletePlantRecord(plantRecord.id);
        }
    }

    if (!plant || store.globalStore.loading)
        return (
            <LoadingComponent />
        )

    return (
        <Card key={plantRecord.id}>  
        <Checkbox className="plant-record-checkbox"/>         
            <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
            <Card.Content>
                <Card.Header >{plant.name}</Card.Header>
                {(plantRecord.mark != "") ?

                    <Label color='red' tag>
                        {plantRecord.mark}
                    </Label>
                    :
                    null
                }
            </Card.Content>
            <Card.Content extra>
                <Card.Header>Datum výsadby: </Card.Header>{plantRecord.datePlanted?.toLocaleString('cs-CZ', dateOptions)}
                <Divider />
                <Card.Header>Množství: </Card.Header>{plantRecord.amountPlanted}
                <Divider />
                {plantRecord.progress >= 100 ?
                    <Progress percent={plantRecord.progress} progress success />
                    :
                    <Progress percent={plantRecord.progress} progress />
                }
                <Popup content='Smazat' trigger={
                    <Button icon='minus'
                        color='red'
                        onClick={() => store.modalStore.openModal(<ConfirmationDeleteComponent handleSubmit={deleteRecord} />)}
                    />}
                />
                <Popup content='Recepty' trigger={
                    <Button icon='utensils'
                        color='blue'
                        as={Link} to={`/recipeHints/${plant.name}`}
                    />}
                />
                {plantRecord.note != "" ?
                    <Popup content={plantRecord.note} trigger={<Button icon='comment' color='teal' />} />

                    :
                    null}
                <Divider hidden />
                <Button icon='undo' onClick={() => store.modalStore.openModal(<PlantRecordFormComponent plant={plant} plantRecordId={plantRecord.id} />)} content="Uprav mne" key={plantRecord.id} />
                <Divider hidden />
                <Popup content="Detail" trigger={<Button icon='info' as={Link} to={`/plants/${plant.id}/plantrecords`} />} />
                <Popup content="Sklidit" trigger={<Button onClick={() => store.modalStore.openModal(<HarvestComponent plantDTO={plant} />)} ><FontAwesomeIcon icon={faWheatAwn} /> </Button>} />
            </Card.Content>
        </Card>
    )
}


const PlantRecordsListComponent = observer(function PlantRecordsList() {

    useEffect(() => {
        window.scrollTo(0, 0)
    }, [])
    const { globalStore, plantStore } = useStore();
    const { stats } = globalStore;

    /*if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )*/

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
                            return RenderPlantRecord(plantRecord, plantStore.getPlantDTO(plantRecord.plantId))
                        })
                    }
                    </Card.Group>
            </Container>

        </Container>

    )
})

export default PlantRecordsListComponent;