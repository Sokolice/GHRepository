import { Card, Container, Image, Label, Icon, Popup, Button, Divider, Header } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { useEffect } from "react";
import { MonthSewedRelation } from "../../models/MonthSewedRelation";
import PlantRecordFormComponent from "./PlantRecordForm";

const RenderPlant = (plant: PlantDTO) => {
    return (
            <Card key={plant.id}>
                <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
                <Card.Content>
                    <Card.Header>{plant.name}</Card.Header>
                </Card.Content>
                <Card.Content extra>
                {
                    plant.directSewing ?
                        <Popup content='Primy vysev' trigger={<Icon name='tree' size='large' color='green' />} /> :
                        <Popup content='Pøedpìstovaní' trigger={<Icon name='home' size='large' color='green' />} />
                }

                {plant.isHybrid ?
                    <Popup content='Hybridní odrùda' trigger={<Icon name='pagelines' size='large' color='brown' />} /> :
                    null
                }
                <Divider horizontal/>
                <PlantRecordFormComponent plant={plant} />
                </Card.Content>
        </Card>
    )
}

const RenderMonthWeek = (monthSewed: MonthSewedRelation) => {
    return (

        <div key={`${monthSewed.month}`}>

            <Divider horizontal />
            
                <Label color="olive" >
                    <Header as='h2'>{monthSewed.month}
                </Header>
                </Label>
            <Divider horizontal />
                <Card.Group itemsPerRow={6} >
                {
                    monthSewed.sewedPlants.map((plant: PlantDTO) => RenderPlant(plant))
                }
                </Card.Group>
            </div>
    );
}

const SewingPlanComponent = observer(function SewingPlan() {
    const { monthWeekStore } = useStore();
    const { monthWeekList, loadMonthWeeeks } = monthWeekStore;

    useEffect(() => {
        if (monthWeekList.length <= 1)
            loadMonthWeeeks();
    }, [loadMonthWeeeks, monthWeekList])

    return (
        <Container>
            {
             monthWeekList.map((m: MonthSewedRelation) => {
                    return RenderMonthWeek(m);
             })
            }
        </Container>
    )
}
)

export default SewingPlanComponent;