import { Link, useParams } from "react-router-dom";
import {
  Button,
  Header,
  Item,
  Label,
  Segment,
  Divider,
  Icon,
  Grid,
  GridColumn,
  GridRow,
  ItemGroup,
} from "semantic-ui-react";
import { store, useStore } from "../../app/stores/store";
import { useEffect } from "react";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../layout/LoadingComponent";

const PlantDetails = observer(function PlantDetails() {
  const { plantStore, pestsStore } = useStore();
  const { selectedPlant, loadOtherPlants, otherPlants, loadPlant } = plantStore;
  const { getCurrentPest } = pestsStore;
  const { id } = useParams();
  const { origin } = useParams();
  const { otherId } = useParams();

  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  useEffect(() => {
    if (id) {
      loadPlant(id);
      getCurrentPest(id);
      loadOtherPlants(id);
    }
  }, [id]);
  if (store.globalStore.loading || !selectedPlant) {
    return <LoadingComponent />;
  }
  return (
    <Segment basic>
      <Grid columns={2} divided>
        <GridRow>
          <ItemGroup>
            <Item>
              <Item.Image
                size="medium"
                src={`/src/assets/plants/${selectedPlant?.imageSrc}`}
              />
              <Item.Content>
                <Header as="h2" content={selectedPlant?.name} />

                <Item.Description>
                  {selectedPlant?.description}
                </Item.Description>
                <Item.Extra>
                  {selectedPlant?.directSewing ? (
                    <Label icon="tree" content="Přímý výsev" />
                  ) : (
                    <Label icon="home" content="Předpěstování" />
                  )}
                  {selectedPlant?.isHybrid ? (
                    <Label icon="pagelines" content="Hybrid" />
                  ) : null}
                </Item.Extra>
              </Item.Content>
            </Item>
          </ItemGroup>
        </GridRow>
        <GridRow>
          <ItemGroup>
            {store.pestsStore.currentPests.length > 0 ? (
              <>
                <Header as="h3"> Skudci:</Header>
                {store.pestsStore.currentPests.map((pest) => {
                  return (
                    <Item key={pest.pestDTO.id}>
                      <Item.Image
                        size="small"
                        src={`/src/assets/pests/${pest.pestDTO.imageSrc}`}
                      />
                      <Item.Content>
                        <Item.Description>
                          <Header as="h3">{pest.pestDTO.name}</Header>
                          <Divider hidden />
                          <b>Rady: </b>

                          <p>{pest.pestDTO.advice}</p>
                        </Item.Description>
                      </Item.Content>
                    </Item>
                  );
                })}
              </>
            ) : null}
          </ItemGroup>
        </GridRow>

        <GridRow>
          <GridColumn>
            <Header as="h4">
              <Icon name="thumbs down" color="red" /> Nesnese:
            </Header>
            <Item.Group>
              {otherPlants.avoidPlants.map((plant) => {
                return (
                  <Item
                    key={plant.id}
                    as={Link}
                    to={`/plants/${plant.id}/plants/${id}`}
                  >
                    {plant.name}
                  </Item>
                );
              })}
            </Item.Group>
          </GridColumn>
          <GridColumn>
            <Header as="h4">
              <Icon name="thumbs up" color="green" /> Snese:
            </Header>
            <Item.Group>
              {otherPlants.companionPlants.map((plant) => {
                return (
                  <Item
                    key={plant.id}
                    as={Link}
                    to={`/plants/${plant.id}/plants/${id}`}
                  >
                    {plant.name}
                  </Item>
                );
              })}
            </Item.Group>
          </GridColumn>
        </GridRow>
        <GridRow>
          <Button
            as={Link}
            to={
              origin == null
                ? "/"
                : otherId == null
                  ? `/${origin}`
                  : `/${origin}/${otherId}`
            }
            content="Zpet"
            icon="pointing left"
          />
        </GridRow>
      </Grid>
    </Segment>
  );
});

export default PlantDetails;
