import {
  Button,
  Card,
  CardGroup,
  Label,
  List,
  ListItem,
} from "semantic-ui-react";
import { store } from "../../app/stores/store";
import { BedRelation } from "../../models/BedRelation";
import { Link } from "react-router-dom";
import { PlantDTO } from "../../models/PlantDTO";
import { observer } from "mobx-react-lite";
import ConfirmationDeleteComponent from "../details/ConfirmationDelete";

const renderBed = (bedRelation: BedRelation) => {
  function listPlantsInBed(plants: PlantDTO[]) {
    return (
      <List>
        {plants.map((item) => {
          return (
            <ListItem key={bedRelation.bed.id + "_" + item.id}>
              {item.name}
            </ListItem>
          );
        })}
      </List>
    );
  }
  function deleteBed() {
    store.bedsStore.deleteBed(bedRelation.bed.id);
  }
  return (
    <Card key={"b_" + bedRelation.bed.id}>
      <Card.Content>
        {bedRelation.bed.cropRotation > 0 || bedRelation.bed.isDesign ? (
          <Label attached="top" color="blue">
            {bedRelation.bed.cropRotation > 0
              ? bedRelation.bed.cropRotation + " trať"
              : null}{" "}
            {bedRelation.bed.isDesign ? "Návrh" : null}
          </Label>
        ) : null}

        <Card.Header>{bedRelation.bed.name}</Card.Header>
        <Card.Meta>
          <Card.Header>šířka: {bedRelation.bed.width}m</Card.Header>
          <Card.Header>délka: {bedRelation.bed.length}m</Card.Header>
        </Card.Meta>
        {bedRelation.bed.note != "" ? (
          <Card.Description>Poznámka: {bedRelation.bed.note}</Card.Description>
        ) : null}
        {listPlantsInBed(bedRelation.plants)}
        <Button
          icon="info"
          color="blue"
          as={Link}
          to={`/beds/${bedRelation.bed.id}`}
          content="Detail"
        />
        <Button
          icon="minus"
          color="red"
          content="Smazat"
          onClick={() =>
            store.modalStore.openModal(
              <ConfirmationDeleteComponent handleSubmit={deleteBed} />,
            )
          }
        />
      </Card.Content>
    </Card>
  );
};
const BedsListComponent = observer(function BedsList() {
  return (
    <div id="beds">
      <CardGroup>
        {store.bedsStore.beds.map((bedRelation: BedRelation) => {
          return renderBed(bedRelation);
        })}
      </CardGroup>
    </div>
  );
});

export default BedsListComponent;
