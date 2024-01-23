import { Card, Container, Image, Label, Icon, Popup, Button, Divider, Header} from "semantic-ui-react";
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
                    <Button icon='angle double down' onClick={() => openForm(plant)} content="Zasaď mě" key={plant.id} />
                    <Divider hidden/>
                    <Button icon='info' as={Link} to={`/plants/${plant.id}`} content="Detail" /> 
                
                </Card.Content>
        </Card>
    )
}

const RenderMonthWeek = (monthSewed: MonthSewedRelation, openForm: (plant: PlantDTO) => void) => {
    return (

        <Container key={`${monthSewed.month}`} textAlign="center">

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
            </Container>
    );
}

const SewingPlanComponent = observer(function SewingPlan() {
    const { monthWeekStore, globalStore, pestsStore } = useStore();
    const { currentMonthRelationList, loadMonthWeeeks, monthWeekRelationList } = monthWeekStore;

    const { pestsList, loadPests } = pestsStore;

    const { loadPlantDTO, plantDTOList } = globalStore;

    const [open, setOpen] = useState(false);
    const [active, setActive] = useState(false);
    const [planted, setPlanted] = useState(false);

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

    useEffect(() => {
        if (pestsList.length <= 0)
            loadPests();
        if (monthWeekRelationList.length <= 0)
            loadMonthWeeeks();
        if (plantDTOList.size <= 0)
            loadPlantDTO();
    }, [pestsList, loadPests, loadPlantDTO, plantDTOList.size, monthWeekRelationList.length, loadMonthWeeeks])

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
                <Button toggle active={active} onClick={switchToCurrentMonth}>Aktualni vysev</Button>
                <Button toggle active={planted} onClick={hidePlanted}>Skryt vysete</Button>
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