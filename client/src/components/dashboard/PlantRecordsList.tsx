/* eslint-disable @typescript-eslint/no-unused-vars */
import { observer } from "mobx-react-lite";
import { Button, Card, Divider, Header, Image, Progress } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { SyntheticEvent, useEffect } from "react";
import { PlantDTO } from "../../models/PlantDTO";

const RenderPlantRecord = (plantRecord: PlantRecordDTO, plant: PlantDTO, handleActivityDelete: (e: SyntheticEvent<HTMLButtonElement>, id: string)=>void) => {
   
    return (
        <Card key={plantRecord.id}>
            <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
            <Card.Content>
                <Card.Header>{plant.name}</Card.Header>
            </Card.Content>
            <Card.Content extra>
                <Card.Header>Datum vysadby: </Card.Header>{plantRecord.datePlanted}
                <Divider />
                <Card.Header>Mnozstni: </Card.Header>{plantRecord.amountPlanted}
                <Divider />
                <Progress percent={plantRecord.progress} progress />
                <Button icon='minus' color='red' onClick={(e) => handleActivityDelete(e, plantRecord.id)} />
            </Card.Content>
        </Card>
    )
}


const PlantRecordsListComponent = observer(function PlantRecordsList() {
    const { plantRecordStore, globalStore } = useStore();
    const { getPlantDTO} = globalStore;
    const { deletePlantRecord, plantRecords } = plantRecordStore;

    
    function handleActivityDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        deletePlantRecord(id);
    }

    return (
        <Card.Group itemsPerRow='6'>
            {
                plantRecords.map((plantRecord: PlantRecordDTO) =>
                {
                    return RenderPlantRecord(plantRecord, getPlantDTO(plantRecord.plantId), handleActivityDelete)
                })
            }
        </Card.Group>
    )
})

export default PlantRecordsListComponent;