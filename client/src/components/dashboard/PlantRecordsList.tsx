/* eslint-disable @typescript-eslint/no-unused-vars */
import { observer } from "mobx-react-lite";
import { Card, Divider, Header, Image, Progress } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { useEffect } from "react";
import { PlantDTO } from "../../models/PlantDTO";

const RenderPlantRecord = (plantRecord: PlantRecordDTO, plant: PlantDTO) => {
    const { monthWeekStore } = useStore()
    const { monthWeekRelationList } = monthWeekStore;

    function calculateProgress(plant: PlantDTO, plantRecord: PlantRecordDTO) {

        const sewedMonthRelation = monthWeekRelationList.find(a => (a.sewedPlants.find(b => (b.id === plant.id))));
        const harvestedMonthRelation = monthWeekRelationList.find(a => (a.harvestedPlants.find(b => (b.id === plant.id))));


        const firstSewingtMonth = sewedMonthRelation?.monthWeekDTO.monthIndex;
        const firstHarvestedMonth = harvestedMonthRelation?.monthWeekDTO.monthIndex;

        const vegetationPeriod = firstHarvestedMonth - firstSewingtMonth;

        const now = new Date(Date.now());
        const planted = new Date(plantRecord.datePlanted);
        console.log(planted);
        const PlantedMonth = planted.getMonth() + 1;
        console.log(PlantedMonth + " - " + vegetationPeriod);
        const finalMonth = PlantedMonth + vegetationPeriod;
        console.log(finalMonth);

        return Math.round(((now.getMonth()+1) * 100) / finalMonth);
    }

    return (
        <Card key={plantRecord.id}>
            <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
            <Card.Content>
                <Card.Header>{plant.name}</Card.Header>
            </Card.Content>
            <Card.Content extra>                
                <Card.Header>Datum vysadby: </Card.Header>{plantRecord.datePlanted}
                <Divider/>
                <Card.Header>Mnozstni: </Card.Header>{plantRecord.amountPlanted}
                <Divider />
                <Progress percent={calculateProgress(plant, plantRecord)} progress />
            </Card.Content>               
        </Card>
    )
}
const PlantRecordsListComponent = observer(function PlantRecordsList() {
    const { plantRecordStore, globalStore } = useStore();
    const { loadPlantDTO, getPlantDTO, plantDTOList } = globalStore;

    //nacist nekde v nadrazene komponente asi v app
    useEffect(() => {
        if (plantDTOList.size <= 1)
            loadPlantDTO();
    }, [loadPlantDTO, plantDTOList.size])

    return (
        <Card.Group itemsPerRow='6'>
            {
                plantRecordStore.plantRecordsList.map((plantRecord: PlantRecordDTO) =>
                {
                    return RenderPlantRecord(plantRecord, getPlantDTO(plantRecord.plantId))
                })
            }
        </Card.Group>
    )
})

export default PlantRecordsListComponent;