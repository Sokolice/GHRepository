import { Card, Container, Image, Label, Icon } from "semantic-ui-react";
import { PlantDTO } from "../models/PlantDTO";
import { observer } from "mobx-react-lite";
import { useStore } from "../app/store";
import { useEffect } from "react";

const RenderPlant = (plant: PlantDTO) => {
    return (
            <Card key={plant.id}>
                <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
                <Card.Content>
                    <Card.Header>{plant.name}</Card.Header>
                </Card.Content>
                {plant.directSewing ? null :
                    <Label color="grey">
                        <Icon name='home' />
                        Pøedpìstování
                    </Label>}

                {plant.isHybrid ? null :
                    <Label color="yellow">
                        <Icon name='pagelines' />
                        Hybrid
                    </Label>}
            </Card>
    )
}

const RenderMonthWeek = (month: [string,PlantDTO[]]) => {
    return (
        <div key={`${month}`}>
            <Label color="olive" >
                {month[0]}
            </Label>
            <Card.Group itemsPerRow={6} >
            {

                    month[1].map((plant: PlantDTO) => RenderPlant(plant))


                }
            </Card.Group>
        </div>
    );
}

/*const RenderItems* = (groupedMonthWeeksList: Map<string, PlantDTO[]>): React.Component* => {
    for (let key of groupedMonthWeeksList.keys()) {
        yield RenderMonthWeek(key, groupedMonthWeeksList.get(key))
    }
}*/

const SewingPlantComponent = observer(function SewingPlan() {
    const { monthWeekStore } = useStore();
    const {groupedMonthWeeksList, groupSewedPlantsByMonth } = monthWeekStore;

    /*useEffect(() => {
        if (monthWeekList.length <= 1)
            loadMonthWeeeks();
    }, [loadMonthWeeeks])*/

    useEffect(() => {
        if (groupedMonthWeeksList.size <= 1)
            groupSewedPlantsByMonth();
    }, [groupSewedPlantsByMonth])

    const { groupedMonthWeeks } = monthWeekStore;

    //groupedMonthWeeks.forEach(a => console.log(a[0], a[1].values));
    //console.log(groupedMonthWeeks)

    return (
        <Container>
            {
               
                groupedMonthWeeks.map((month) => {
                    return RenderMonthWeek(month);
                })
            }
        </Container>
    )
}
)

export default SewingPlantComponent;