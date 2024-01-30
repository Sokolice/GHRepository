/* eslint-disable react-refresh/only-export-components */
import { Link, useParams } from "react-router-dom";
import { Button, Header, Item, Label, Segment, Image, Divider, Icon, Grid, GridColumn } from "semantic-ui-react";
import { store, useStore } from "../../app/stores/store";
import { useEffect } from "react";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../layout/LoadingComponent";

export default observer(function PlantDetails() {
    const { globalStore } = useStore();
    const { selectedPlant, loadPlant, loadOtherPlants, otherPlants } = globalStore;
    const { id } = useParams();
    const { origin } = useParams();

    useEffect(() => {
        window.scrollTo(0, 0)
    }, [])


    useEffect(() => {
        if (id) {
            loadPlant(id);
            store.pestsStore.getCurrentPest(id);
            loadOtherPlants(id);
        }
        
    }, [id, loadPlant, loadOtherPlants])

    if (store.globalStore.loading || !selectedPlant)
        return (
            <LoadingComponent />
        )
    return (
        <Segment>
            <Item.Group>
                <Item>
                    <Item.Image size='small' src={`/src/assets/plants/${selectedPlant?.imageSrc}`} />
                    <Item.Content>
                        <Header as='h2' content={selectedPlant?.name} />

                        <Item.Description>
                            {selectedPlant?.description}
                        </Item.Description>
                        <Item.Extra>
                            {
                                selectedPlant?.directSewing ?
                                    <Label icon='tree' content='Přímý výsev' />  :
                                    <Label icon='home' content='Předpěstování' /> 
                            }
                            {selectedPlant?.isHybrid ?
                                <Label icon='pagelines' content='Hybrid' /> :
                                null
                            }
                        </Item.Extra>
                        <Item.Extra>
                            <Header as='h4'> Skudci:</Header>
                                <Item.Group>
                                {
                                store.pestsStore.currentPests.map((pest) => {
                                    return (

                                        <Item key={pest.pestDTO.id}>
                                            <Item.Image size='small' src={`/src/assets/pests/${pest.pestDTO.imageSrc}`} />
                                            <Item.Content>
                                                <Item.Description>
                                                    <b>Nazev: </b>
                                                    <p>
                                                        {pest.pestDTO.name}
                                                    </p>
                                                    <Divider hidden/>
                                                        <b>Rady: </b>

                                                    <p>
                                                        {pest.pestDTO.advice}
                                                    </p>
                                                </Item.Description>
                                            </Item.Content>
                                        </Item>
                                    )
                                })
                                
                                }
                                </Item.Group>
                        </Item.Extra>
                        <Item.Extra>
                            <Grid columns={2} divided>
                                <GridColumn>
                                    <Header as='h4'><Icon name='thumbs down' color='red' /> Nesnese:</Header>
                                    {
                                        otherPlants.avoidPlants.map((plant) => {
                                            return (
                                                <Item key={plant.id}>
                                                    {plant.name}
                                                </Item>
                                            )
                                        })
                                    }
                                </GridColumn>
                                <GridColumn>
                                    <Header as='h4'><Icon name='thumbs up' color='green' /> Snese:</Header>
                                    {
                                        otherPlants.companionPlants.map((plant) => {
                                            return (
                                                <Item key={plant.id}>
                                                    {plant.name}
                                                </Item>
                                            )
                                        })
                                    }
                                </GridColumn>
                            </Grid>                            
                        </Item.Extra>
                    </Item.Content>
                </Item>

            </Item.Group>
            <Button as={Link} to={`/${origin}`} content="Zpet" icon='pointing left' />
        </Segment>
    )
}
)