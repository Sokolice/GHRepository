import { Card, Container, Image, Label, Icon } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/store";
import { useEffect } from "react";
import { MonthSewedRelation } from "../../models/MonthSewedRelation";

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
                    </Label>}

                {plant.isHybrid ? null :
                    <Label color="yellow">
                        <Icon name='pagelines' />
                        Hybrid
                    </Label>}
            </Card>
    )
}

const RenderMonthWeek = (monthSewed: MonthSewedRelation) => {
    return (

        <div key={`${monthSewed.month}`}>
                <Label color="olive" >
                {monthSewed.month}
                </Label>
                <Card.Group itemsPerRow={6} >
                    {

                    monthSewed.sewedPlants.map((plant: PlantDTO) => RenderPlant(plant))


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

const SewingPlanComponent = observer(function SewingPlan() {
    const { monthWeekStore } = useStore();
    const { monthWeekList, loadMonthWeeeks } = monthWeekStore;

    /*useEffect(() => {
        if (monthWeekList.length <= 1)
            loadMonthWeeeks();
    }, [loadMonthWeeeks])*/

    useEffect(() => {
        if (monthWeekList.length <= 1)
            loadMonthWeeeks();
    }, [monthWeekList])

    //const { groupedMonthWeeks } = monthWeekStore;

    //groupedMonthWeeks.forEach(a => console.log(a[0], a[1].values));
    console.log(monthWeekList)

    return (
        <Container>
            {
                (
                monthWeekList.map((m: MonthSewedRelation) => {
                    return RenderMonthWeek(m);
                })       
                )
            }
        </Container>
    )
}
)

export default SewingPlanComponent;