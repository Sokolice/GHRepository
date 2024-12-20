import { observer } from "mobx-react-lite";
import { Button, Form, Image, Header, Rating, Divider, Grid, GridRow, GridColumn, List, ListItem } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { ChangeEvent, useState } from "react";
import { store, useStore } from "../../app/stores/store";
import { unitOptions } from "../../app/options/unitOptions";

interface Props {
    plantDTO: PlantDTO |undefined
}

const HarvestComponent = observer(function Harvest({ plantDTO }: Props) {
    const { modalStore, globalStore, plantStore } = useStore();
    const [harvest, setHarvest] = useState({
        id: '',
        plantId: '',
        date: '',
        amount: 0,
        rating: 0,
        note: '',
        unit:0
    });


    const posibleNextPlants = Array.from(plantStore.plantDTOList).filter(item =>  item[1].cropRotation != plantDTO?.cropRotation);
    /* function handleChangeOnRate(event:React.MouseEvent<HTMLDivElement>, data:RatingProps) {
        setHarvest({ ...harvest, rating: data. });
    } */
    function handleSubmit() {
        harvest.plantId = plantDTO?.id ?? '';
        store.globalStore.saveHarvest(harvest);
    }
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setHarvest({ ...harvest, [name]: value });
    }
    
    const handleSelectChange = (data:any) => {
        const { name, value } = data;
        setHarvest({ ...harvest, [name]: value });
    }
    return (
        <Form onSubmit={handleSubmit}>
            <Header>Sklizeň</Header>
            <Divider />
            <Grid columns={2}>

                <GridRow>
                    <GridColumn width={6}>
                        <Image size='medium' src={`/src/assets/plants/${plantDTO?.imageSrc}`} wrapped />
                    </GridColumn>

                    <GridColumn width={10}>
                    <Form.Group>
                            <Form.Input name='amount' placeholder='mnozstvi' id='amount' label='Množství' onChange={handleInputChange} width={7} />
                            <Form.Select name='unit' placeholder='jednotka' id='unit' label='Jednotka' onChange={handleSelectChange} defaultValue={unitOptions[0].value} options={unitOptions} width={7} />
                        </Form.Group>
                        <Form.Input name='date' placeholder='Datum' id='date' type='date' onChange={handleInputChange}></Form.Input>
                        <Form.TextArea placeholder='Poznámka' id="note" name="note" label="Poznámka" onChange={handleInputChange} />
                        <Rating name='rating' id='rating' maxRating={5} defaultRating={0} icon='star' size='huge' />
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