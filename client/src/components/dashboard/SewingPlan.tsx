import { Card, Container, Image, Label, Icon, Popup, Button, Divider, Header, ButtonGroup, Segment } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { observer } from "mobx-react-lite";
import { store, useStore } from "../../app/stores/store";
import { useEffect, useState } from "react";
import { MonthSewedRelation } from "../../models/MonthSewedRelation";
import PlantRecordFormComponent from "./PlantRecordForm";
import { Link } from "react-router-dom";
import LoadingComponent from "../layout/LoadingComponent";

const RenderPlant = (plant: PlantDTO, openForm: (plant: PlantDTO) => void) => {
    return (
            <Card key={plant.id}>
                <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
                <Card.Content>
                    <Card.Header>{plant.name}</Card.Header>
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
                <ButtonGroup vertical labeled icon>
                    <Button icon='angle double down' onClick={() => openForm(plant)} content="Zasaď mě" key={plant.id} />
                    <Button icon='info' as={Link} to={`/plants/${plant.id}`} content="Detail" /> 
                </ButtonGroup>
                </Card.Content>
        </Card>
    )
}

const RenderMonthWeek = (monthSewed: MonthSewedRelation, openForm: (plant: PlantDTO) => void) => {
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
                    monthSewed.sewedPlants.map((plant: PlantDTO) => RenderPlant(plant, openForm))
                }
                </Card.Group>
            </div>
    );
}

const SewingPlanComponent = observer(function SewingPlan() {
    const { monthWeekStore } = useStore();
    const { currentMonthRelationList } = monthWeekStore;

    const [open, setOpen] = useState(false);
    const [active, setActive] = useState(false);

    const [selectedPlant, setPlant] = useState({
        id: '',
        name: '',
        isHybrid: false,
        directSewing: false,
        germinationTemp: 0,
        cropRotatoin: 0,
        description: '',
        imageSrc: '',
        repeatedPlanting: 0
    });

    /*useEffect(() => {
        if (monthWeekList.length <= 1)
            loadMonthWeeeks();
    }, [loadMonthWeeeks, monthWeekList])*/

    function openForm(plant: PlantDTO) {
        setOpen(true);
        setPlant(plant);
    }

    function onOpen() {
        setOpen(true);
    }

    function onClose() {
        setOpen(false);
    }

    function switchToCurrentMonth() {
        setActive(!active);

        store.monthWeekStore.isCurrentMonthActive = !store.monthWeekStore.isCurrentMonthActive;
        store.monthWeekStore.filterMonthWeeks();
    }
    if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )
    return (
        <Container>
            <Container textAlign='center'>
                <Button toggle active={active} onClick={switchToCurrentMonth}>Aktualni vysev</Button>
            </Container>

            <Container>
                {
                    currentMonthRelationList.map((m: MonthSewedRelation) => {
                        return RenderMonthWeek(m, openForm);
                    })
                }
                <PlantRecordFormComponent plant={selectedPlant} isOpen={open} onClose={onClose} onOpen={onOpen} plantRecordId={''} />
            </Container>
        </Container>
        )
    }
)

export default SewingPlanComponent;