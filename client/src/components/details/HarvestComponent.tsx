import { observer } from "mobx-react-lite";
import { Button, Form, Image, Header, Rating, Divider, Grid, GridRow, GridColumn, List, ListItem } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { ChangeEvent, useState } from "react";
import { store, useStore } from "../../app/stores/store";
import DatePicker, { ReactDatePickerProps } from 'react-datepicker';

interface Props {
    plantDTO: PlantDTO
}

const HarvestComponent = observer(function Harvest({ plantDTO }: Props) {
    const { modalStore, globalStore, plantStore } = useStore();
    const [harvest, setHarvest] = useState({
        id: '',
        plantId: '',
        date: '',
        amount: 0,
        rating: 0,
        note: ''
    });

    const posibleNextPlants = Array.from(plantStore.plantDTOList).filter(item =>  item[1].cropRotation != plantDTO.cropRotation);
    console.log(posibleNextPlants);
    function handleChangeOnRate(e, { rating }) {
        setHarvest({ ...harvest, rating: rating });
    }
    function handleSubmit() {
        harvest.plantId = plantDTO.id;
        store.globalStore.saveHarvest(harvest);
    }
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setHarvest({ ...harvest, [name]: value });
    }
    return (
        <Form onSubmit={handleSubmit}>
            <Header>Sklizeň</Header>
            <Divider />
            <Grid columns={2}>

                <GridRow>
                    <GridColumn width={6}>
                        <Image size='medium' src={`/src/assets/plants/${plantDTO.imageSrc}`} wrapped />
                    </GridColumn>

                    <GridColumn width={10}>
                        <Form.Input name='amount' placeholder='gramy' id='amount' label='Množství' onChange={handleInputChange}></Form.Input>
                        <Form.Input name='date' placeholder='Datum' id='date' type='date' onChange={handleInputChange}></Form.Input>
                        <Form.TextArea placeholder='Poznámka' id="note" name="note" label="Poznámka" onChange={handleInputChange} />
                        <Rating name='rating' id='rating' maxRating={5} defaultRating={0} icon='star' size='huge' onRate={handleChangeOnRate} />
                        <Header as='h3'> Následné plodiny</Header>
                            <List>
                                {
                                    posibleNextPlants.map(plant => {
                                        return (
                                            <ListItem key={plant[0]}>
                                                <Image avatar src={`/src/assets/plants/${plant[1].imageSrc}`} /> {plant[1].name}
                                            </ListItem>
                                        )
                                    })
                                }
                            </List>
                    </GridColumn>                   
                </GridRow>
                <GridRow>
                    <GridColumn width={16}>

                        <Button
                            loading={globalStore.loading}
                            type='submit'
                            content="Uložit"
                            labelPosition='right'
                            icon='remove'
                            positive
                        />
                        <Button
                            onClick={() => { modalStore.closeModal() }}
                            content="Zrušit"
                            labelPosition='right'
                            icon='checkmark'
                            negative
                        />

                    </GridColumn>

                </GridRow>
            </Grid>
        </Form>
    )





})

export default HarvestComponent;