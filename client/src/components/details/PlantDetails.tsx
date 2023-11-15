/* eslint-disable react-refresh/only-export-components */
import { Link, useParams } from "react-router-dom";
import { Button, Header, Icon, Item, ItemExtra, Label, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { useEffect } from "react";
import { observer } from "mobx-react-lite";

export default observer(function PlantDetails() {
    const { globalStore } = useStore();
    const { selectedPlant, loadPlant } = globalStore;
    const { id } = useParams();

    useEffect(() => {
        if (id)
            loadPlant(id);
    }, [id, loadPlant])

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
                        </Item.Extra>
                    </Item.Content>
                </Item>

            </Item.Group>
            <Button as={Link} to={'/sewingplan'} content="Zpet" icon='pointing left' />
        </Segment>
    )
}
)