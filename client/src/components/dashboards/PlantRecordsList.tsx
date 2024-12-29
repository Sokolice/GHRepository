import { observer } from "mobx-react-lite";
import {
  Button,
  Card,
  Container,
  Divider,
  Image,
  Popup,
  Progress,
  Label,
  Checkbox,
  Grid,
} from "semantic-ui-react";
import { store, useStore } from "../../app/stores/store";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import { ChangeEvent, useEffect, useState } from "react";
import { PlantDTO } from "../../models/PlantDTO";
import LoadingComponent from "../layout/LoadingComponent";
import PlantRecordFormComponent from "./PlantRecordForm";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faWheatAwn } from "@fortawesome/free-solid-svg-icons";
import HarvestComponent from "../details/HarvestComponent";
import { dateOptions } from "../../app/options/dateOptions";
import ConfirmationDeleteComponent from "../details/ConfirmationDelete";

const PlantRecordsListComponent = observer(function PlantRecordsList() {
  const [selectedItems, setSelectedItems] = useState<string[]>([]);

  function deleteSelected() {
    selectedItems.forEach((id) => deleteRecord(id));
    setSelectedItems([]);
  }

  function deleteRecord(id: string) {
    if (id != "") {
      store.plantRecordStore.deletePlantRecord(id);
    }
  }

  function deleteCheckBoxChange(id: string) {
    if (selectedItems.includes(id)) {
      setSelectedItems(selectedItems.filter((item) => item !== id));
    } else {
      setSelectedItems([...selectedItems, id]);
    }
  }
  const RenderPlantRecord = (
    plantRecord: PlantRecordDTO,
    plant: PlantDTO | undefined,
  ) => {
    if (!plant || store.globalStore.loading) {
      return <LoadingComponent />;
    }

    return (
      <Card key={plantRecord.id}>
        <Checkbox
          className="plant-record-checkbox"
          onChange={() => deleteCheckBoxChange(plantRecord.id)}
        />
        <Image
          src={`/src/assets/plants/${plant.imageSrc}`}
          wrapped
          ui={false}
        />
        <Card.Content>
          <Card.Header>{plant.name}</Card.Header>
          {plantRecord.mark != "" ? (
            <Label color="red" tag>
              {plantRecord.mark}
            </Label>
          ) : null}
        </Card.Content>
        <Card.Content extra>
          <Card.Header>Datum výsadby: </Card.Header>
          {plantRecord.datePlanted?.toLocaleString("cs-CZ", dateOptions)}
          <Divider />
          <Card.Header>Množství: </Card.Header>
          {plantRecord.amountPlanted}
          <Divider />
          {plantRecord.progress >= 100 ? (
            <Progress percent={plantRecord.progress} progress success />
          ) : (
            <Progress percent={plantRecord.progress} progress />
          )}
          <Popup
            content="Smazat"
            trigger={
              <Button
                icon="minus"
                color="red"
                onClick={() =>
                  store.modalStore.openModal(
                    <ConfirmationDeleteComponent
                      handleSubmit={() => deleteRecord(plantRecord.id)}
                    />,
                  )
                }
              />
            }
          />
          <Popup
            content="Recepty"
            trigger={
              <Button
                icon="utensils"
                color="blue"
                as={Link}
                to={`/recipeHints/${plant.name}`}
              />
            }
          />
          {plantRecord.note != "" ? (
            <Popup
              content={plantRecord.note}
              trigger={<Button icon="comment" color="teal" />}
            />
          ) : null}
          <Divider hidden />
          <Button
            icon="undo"
            onClick={() =>
              store.modalStore.openModal(
                <PlantRecordFormComponent
                  plant={plant}
                  plantRecordId={plantRecord.id}
                />,
              )
            }
            content="Uprav mne"
            key={plantRecord.id}
          />
          <Divider hidden />
          <Popup
            content="Detail"
            trigger={
              <Button
                icon="info"
                as={Link}
                to={`/plants/${plant.id}/plantrecords`}
              />
            }
          />
          <Popup
            content="Sklidit"
            trigger={
              <Button
                onClick={() =>
                  store.modalStore.openModal(
                    <HarvestComponent plantDTO={plant} />,
                  )
                }
              >
                <FontAwesomeIcon icon={faWheatAwn} />{" "}
              </Button>
            }
          />
        </Card.Content>
      </Card>
    );
  };

  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);
  const { plantStore, plantRecordStore } = useStore();
  const[plantRecordList, setPlantRecordList]=useState(store.plantRecordStore.plantRecords);

  function handleChange(event: ChangeEvent<HTMLInputElement>): void {
    const inputValue = event.target.value;
    if(inputValue.length >= 3){
      setPlantRecordList(plantRecordStore.searchPlantRecords(inputValue));
    }
  }

  return (
    <Grid> 
      <Grid.Row>
      <input type="text" placeholder="Hledat..." onChange={handleChange}/> 
      <Button
        icon="times"
        color="red"
        onClick={()=>setPlantRecordList(store.plantRecordStore.plantRecords)}
        />
      <Button
        icon="minus"
        color="red"
        content="Smazat oznacene"
        disabled={!selectedItems.length}
        onClick={() =>
          store.modalStore.openModal(
            <ConfirmationDeleteComponent handleSubmit={deleteSelected} />,
          )
        }
        />
        <Button
        color="blue"
        disabled={!selectedItems.length}
        onClick={() =>{}}      
      ><FontAwesomeIcon icon={faWheatAwn} />{" Sklidit oznacene"}
</Button>
      </Grid.Row>
      <Grid.Row>
      <Container>
        <Card.Group itemsPerRow="6">
          {plantRecordList.map(
            (plantRecord: PlantRecordDTO) => {
              return RenderPlantRecord(
                plantRecord,
                plantStore.getPlantDTO(plantRecord.plantId),
              );
            },
          )}
        </Card.Group>
      </Container>
      </Grid.Row>
    </Grid>
  );
});

export default PlantRecordsListComponent;
