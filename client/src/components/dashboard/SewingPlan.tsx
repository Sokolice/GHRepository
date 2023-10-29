import { Card, Container, Image, Label, Icon, Popup, Button, Divider, Header } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { observer } from "mobx-react-lite";
import { store, useStore } from "../../app/stores/store";
import { useEffect, useState } from "react";
import { MonthSewedRelation } from "../../models/MonthSewedRelation";
import PlantRecordFormComponent from "./PlantRecordForm";

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
                        <Popup content='Primy vysev' trigger={<Icon name='tree' size='large' color='green' />} /> :
                        <Popup content='Pøedpìstovaní' trigger={<Icon name='home' size='large' color='green' />} />
                }

                {plant.isHybrid ?
                    <Popup content='Hybridní odrùda' trigger={<Icon name='pagelines' size='large' color='brown' />} /> :
                    null
                }
                <Divider horizontal />

                <Button  onClick={() => openForm(plant)} content="Zasad me" key={plant.id} /> 
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
    const { monthWeekList, loadMonthWeeeks } = monthWeekStore;

    const [open, setOpen] = useState(false);

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
        if (monthWeekList.length <= 1)
            loadMonthWeeeks();
    }, [loadMonthWeeeks, monthWeekList])

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

    return (
        <Container>
            {
                monthWeekList.map((m: MonthSewedRelation) => {
                    return RenderMonthWeek(m, openForm);
             })
            }
            <PlantRecordFormComponent plant={selectedPlant} isOpen={open} onClose={onClose} onOpen={onOpen} plantRecordId={''} />

        </Container>
    )
}
)

export default SewingPlanComponent;