import { ChangeEvent, SyntheticEvent, useState } from "react";
import { Button, Card, CardGroup, Checkbox, Dropdown, Form, FormField, Label, List, ListItem, Segment } from "semantic-ui-react";
import { store } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import LoadingComponent from "../layout/LoadingComponent";
import { BedRelation } from "../../models/BedRelation";
import { PlantDTO } from "../../models/PlantDTO";



const BedsComponent = observer(function BedsList() {

   


    const [bed, setBed] = useState({
        name: "",
        length: 0,
        width: 0,
        isDesign: false,
        cropRotation: 0,
        note:""
    })

    const [isRotationDisabled, setIsRotationDisabled] = useState(true);

    function AddBed() {
        store.bedsStore.createBed(bed.width, bed.length, bed.name, bed.isDesign, bed.cropRotation, bed.note);
    }

    function handleChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        console.log(event.target.value);
        const { name, value } = event.target;
        setBed({ ...bed, [name]: value })
    }

    const checkedChange = (e) => {
        setBed({ ...bed, isDesign: e.target.checked })
    }

    function handleBedDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        store.bedsStore.deleteBed(id);
    }
    const cropRotationChange = (e) => {
        setIsRotationDisabled(!isRotationDisabled);
    }

    function listPlantsInBed(plants: PlantDTO[]) {
        return (
            <List>
                {
                    plants.map(item => {
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

    function handleDropChange(e: SyntheticEvent<HTMLElement, Event>, data) {
        setBed({ ...bed, cropRotation: data.value });
    }

    const options = [
        { key: 1, text: '1. trať', value: 1 },
        { key: 2, text: '2. trať', value: 2 },
        { key: 3, text: '3. trať', value: 3 },
    ]

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
                                <Form.Input type="number" label='Délka[m]' placeholder='Délka' id='length' name='length' onChange={handleChange} />
                            </Form.Field>
                            <Form.Field>
                                <Form.Input type="number" label='Šířka[m]' placeholder='Šířka' id='width' name='width' onChange={handleChange} />
                            </Form.Field>
                            <Form.Field>
                                <Form.TextArea placeholder='Poznámka' id="note" name="note" label="Poznámka" onChange={handleChange}/>
                            </Form.Field>
                        </Form.Group>
                        <FormField>
                            <Checkbox label='Tvorba návrhu' id='isDesign' name='isDesign' onClick={checkedChange}/>
                        </FormField>
                        <FormField>
                            <Checkbox label='Pěstování v tratích ' id='isCropRotation' name='isCropRotation' onClick={cropRotationChange} />
                        </FormField>
                        <FormField>
                            <Dropdown placeholder='Trať' options={options} scrolling disabled={isRotationDisabled} id='cropRotation' onChange={handleDropChange } />
                        </FormField>
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
                    {store.bedsStore.beds.map((bedRelation: BedRelation) => (
                        <Card key={bedRelation.bed.id}>
                            
                            <Card.Content>
                                {bedRelation.bed.cropRotation > 0 || bedRelation.bed.isDesign ? (

                                    <Label attached='top' color='blue'>{bedRelation.bed.cropRotation > 0 ? bedRelation.bed.cropRotation + " trať" : null}  {bedRelation.bed.isDesign ? "Návrh" : null}</Label>
                                        ) : null
                                }
                                
                                <Card.Header>{bedRelation.bed.name}</Card.Header>
                                <Card.Meta>
                                    <Card.Header>šířka: {bedRelation.bed.width}m</Card.Header>
                                    <Card.Header>délka: {bedRelation.bed.length}m</Card.Header>
                                </Card.Meta>
                                {bedRelation.bed.note != "" ?
                                    <Card.Description>
                                        Poznámka: {bedRelation.bed.note}
                                    </Card.Description>
                                    : null
                                } 


                                
                                {listPlantsInBed(bedRelation.plants)}
                                <Button icon='info' color='blue' as={Link} to={`/beds/${bedRelation.bed.id}`} content="Detail" />
                                <Button icon='minus' color='red' content='Smazat' onClick={(e) => handleBedDelete(e, bedRelation.bed.id)} />
                                                    
                            </Card.Content>
                        </Card>
                    ))}
                </CardGroup>
            </div>
        </div>
    )
})

export default BedsComponent;