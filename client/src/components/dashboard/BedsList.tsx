import { ChangeEvent, SyntheticEvent, useEffect, useState } from "react";
import { Button, Card, CardGroup, Form, List, ListItem, Segment } from "semantic-ui-react";
import { store, useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import LoadingComponent from "../layout/LoadingComponent";
import { PlantDTO } from "../../models/PlantDTO";
import { Bed } from "../../models/Bed";



const BedsComponent = observer(function BedsList() {


    const [bed, setBed] = useState({
        name: "",
        length: 0,
        width: 0
    })

    const { bedsStore } = useStore();
    const { loadBeds, beds } = bedsStore;

    useEffect(() => {
            if (beds.length == 0)
                loadBeds();
    }, [beds, loadBeds])

    function AddBed() {

        store.bedsStore.createBed(bed.width, bed.length, bed.name);
    }


    
    function handleChange(event: ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setBed({ ...bed, [name]: value })
    }

    function handleBedDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        store.bedsStore.deleteBed(id);
    }

    function listPlantsInBed(bed: Bed) {

        const listItems = new Map<string, PlantDTO>();

        bed.cells.forEach(cell => {
            if (cell.plantRecordId != "") {

                const plant: PlantDTO = store.globalStore.getPlantDTO(store.plantRecordStore.getPlantRecord(cell.plantRecordId)?.plantId ?? "");
                listItems.set(plant.id,plant);
            }
        })

        return (
            <List>
                {
                    Array.from(listItems.values()).map(item => {
                        return (
                            <ListItem key={item.id}>
                                {item.name}
                            </ListItem>
                        )
                    })
                }
            </List>
        )
        
    }

    if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )
    return (
        <div >
            <Segment.Group horizontal>
                <Segment>
                    <Form onSubmit={AddBed}>
                        <Form.Group>
                            <Form.Field>
                                <Form.Input label='Název' placeholder='Název' id='name' name='name' onChange={handleChange} />
                            </Form.Field>
                            <Form.Field>
                                <Form.Input label='Délka[m]' placeholder='Délka' id='length' name='length' onChange={handleChange} />
                            </Form.Field>
                            <Form.Field>
                                <Form.Input label='Šířka[m]' placeholder='Šířka' id='width' name='width' onChange={handleChange} />
                            </Form.Field>
                        </Form.Group>
                        <Form.Button type='submit'>
                            Přidat záhon
                        </Form.Button>
                    </Form>
                </Segment>    
            </Segment.Group>
            <br />
            <br />
            <div id="beds">
                <CardGroup>
                    {beds.map((bed: Bed) => (
                        <Card key={bed.id}>
                            <Card.Content>
                                <Card.Header>{bed.name}</Card.Header>
                                <Card.Header>sirka: {bed.width}</Card.Header>
                                <Card.Header>delka: {bed.length}</Card.Header>
                                {listPlantsInBed(bed)}
                                <Button icon='info' color='blue' as={Link} to={`/beds/${bed.id}`} content="Detail" />
                                <Button icon='minus' color='red' content='Smazat' onClick={(e) => handleBedDelete(e, bed.id)} />
                            </Card.Content>
                        </Card>
                    ))}
                </CardGroup>
            </div>
        </div>
    )
})

export default BedsComponent;