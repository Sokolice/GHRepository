import { Card, Container, Image, Label, Icon, Popup, Button, Divider, Header} from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { observer } from "mobx-react-lite";
import { store } from "../../app/stores/store";
import { useEffect, useState } from "react";
import { MonthSewedRelation } from "../../models/MonthSewedRelation";
import PlantRecordFormComponent from "./PlantRecordForm";
import { Link } from "react-router-dom";
import LoadingComponent from "../layout/LoadingComponent";
import MyMapping from "../../app/MyMapping";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSeedling, faRepeat } from "@fortawesome/free-solid-svg-icons";

const RenderPlant = (plant: PlantDTO, toSowMonth: boolean) => {
   
    return (
            <Card key={plant.id}>
                <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
                <Card.Content>
                <Card.Header>
                    {plant.name} &nbsp;
                    {toSowMonth && store.globalStore.stats?.canBeSowedThisWeek.includes(plant.id)
                        ?
                        <Popup content='Zbývá vysadit tento týden' trigger={
                            <Label color='red'>
                                <FontAwesomeIcon icon={faSeedling} />
                            </Label>
                        } />
                        : null
                    }
                    {store.globalStore.stats?.canBeSowedRepeatedly.includes(plant.id)
                        ?
                        <Popup content='Opakovaný výsev' trigger={
                            <Label color='red'>
                                <FontAwesomeIcon icon={faRepeat} />
                            </Label>
                        } />
                        : null
                    }
                </Card.Header>
                </Card.Content>
                <Card.Content extra>
                {
                    plant.directSewing ?
                        <Popup content='Přímý výsev' trigger={<Icon name='tree' size='large' color='green' />} /> :
                        <Popup content='Předpěstování' trigger={<Icon name='home' size='large' color='green' />} />
                }

                {plant.isHybrid ?
                    <Popup content='Hybridní odrůda' trigger={<Icon name='pagelines' size='large' color='brown' />} /> :
                    null
                }
                <Divider horizontal />
                <Button icon='angle double down' onClick={() => store.modalStore.openModal(<PlantRecordFormComponent plant={plant } plantRecordId = { ''} /> )} content="Zasaď mě" key={plant.id} />
                    <Divider hidden/>
                    <Button icon='info' as={Link} to={`/plants/${plant.id}/sewingplan`} content="Detail" /> 
                
                </Card.Content>
        </Card>
    )
}

const RenderMonthWeek = (monthSewed: MonthSewedRelation) => {

    const thisMonth = new Date().getMonth() + 1;


    return (

        <Container key={`${monthSewed.month}`} id={`month_${MyMapping.mapMonthIndex(monthSewed.month)}`} textAlign="center">

            <Divider horizontal />
            
                <Label color="olive" >
                    <Header as='h2'>{monthSewed.month}
                </Header>
                </Label>
            <Divider horizontal />
                <Card.Group itemsPerRow={6} >
                {
                    monthSewed.sewedPlants.map((plant: PlantDTO) => RenderPlant(plant, thisMonth == MyMapping.mapMonthIndex(monthSewed.month)))
                }
                </Card.Group>
            </Container>
    );
}

const SewingPlanComponent = observer(function SewingPlan() {

    const thisMonth = new Date().getMonth() + 1;

    const [active, setActive] = useState(false);
    const [planted, setPlanted] = useState(false);


    useEffect(() => {
        const element = document.getElementById("month_" + thisMonth)
        if (element)
            element.scrollIntoView({ behavior: 'smooth' })
    }, [])

    function switchToCurrentMonth() {
        setActive(!active);

        store.monthWeekStore.isCurrentMonthActive = !store.monthWeekStore.isCurrentMonthActive;
        store.monthWeekStore.filterMonthWeeks();
    }

    function hidePlanted() {
        setPlanted(!planted);

        store.monthWeekStore.hidePlanted = !store.monthWeekStore.hidePlanted;
        store.monthWeekStore.filterPlanted();
    }
    if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )
    return (
        <Container>
            <Container textAlign='center'>
                <Button toggle active={active} onClick={switchToCurrentMonth}>Aktuální výsev</Button>
                <Button toggle active={planted} onClick={hidePlanted}>Skrýt vyseté</Button>
            </Container>

            <Container>
                {
                    store.monthWeekStore.currentMonthRelationList.map((m: MonthSewedRelation) => {
                        return RenderMonthWeek(m);
                    })
                }
                </Container>
        </Container>
        )
    }
)

export default SewingPlanComponent;