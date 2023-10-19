import { observer } from "mobx-react-lite";
import { PlantDTO } from "../../models/PlantDTO";
import { Button, Form, Header, Segment, Image, Modal, Popup, Input, Divider } from "semantic-ui-react";
import { ChangeEvent, useState } from "react";
import { v4 as uuid } from 'uuid'
import { useStore } from "../../app/stores/store";


interface Props {
    plant: PlantDTO
}

const PlantRecordFormComponent = observer(function PlantRecordForm({ plant }: Props) {

    const { plantRecordStore } = useStore();
    const { createPlantRecord } = plantRecordStore;
    const [open, setOpen] = useState(false);

    const [plantRecord, setRecord] = useState({
        id: '',
        plantId: '',
        datePlanted: '',
        amountPlanted: 0,
    });

    function handleSubmit() {
        //console.log("submit");
        //e.preventDefault();
        if (!plantRecord.id) {
            plantRecord.id = uuid();
            plantRecord.plantId = plant.id;
            //console.log(plantRecord);
        }
        else {
            //updateActivity(activity).then(() => navigate(`/activities/${activity.id}`));
        }
        setOpen(false);
        createPlantRecord(plantRecord);
    }

    function handleInputCHhange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        //console.log(plantRecord);
        const { name, value } = event.target;
        setRecord({ ...plantRecord, [name]: value });
        //console.log(plantRecord);
    }
    return (

        <Modal as={Form}
            onSubmit={handleSubmit}
            onClose={() => setOpen(false)}
            onOpen={() => setOpen(true)}
            open={open}
            
            trigger={<Button key={plant.id}> Zasad me</Button>}>
            <Modal.Header>{plant.name}</Modal.Header>
            <Modal.Content image>
                <Image size='medium' src={`/src/assets/plants/${plant.imageSrc}`} wrapped />
                <Modal.Description>
                    <Form.Input type='date' placeholder='Datum sadby' name='datePlanted' label='Datum sadby' value={plantRecord.datePlanted} onChange={handleInputCHhange} />
                    <Form.Input placeholder='Mnozstvi' name='amountPlanted' type='number' value={plantRecord.amountPlanted} onChange={handleInputCHhange} />                              
                </Modal.Description>
              </Modal.Content>
            <Modal.Actions>
                <Button
                    type='submit'
                    content="Ulozit"
                    labelPosition='right'
                    icon='checkmark'
                    positive
                />
            </Modal.Actions>
            </Modal>

        /*<Segment clearing>
            <Form  autoComplete='off'>
                <Header>{plant.name}</Header>
                <Image src={plant.imageSrc} size='small' />
                <Form.Input placeholder='Mnozstvi' name='amount' />
                <Form.Input type="date" placeholder='Datum vysevu' name='date' />
                <Button floated="right" positive type='submit' content='Submit' />
            </Form>
        </Segment>*/
    )
})
export default PlantRecordFormComponent;