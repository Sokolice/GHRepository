import { observer } from "mobx-react-lite";
import { PlantDTO } from "../../models/PlantDTO";
import { Button, Form, Image, Modal} from "semantic-ui-react";
import { ChangeEvent, useEffect, useState } from "react";
import { v4 as uuid } from 'uuid'
import { store} from "../../app/stores/store";


interface Props {
    plant: PlantDTO | undefined,
    plantRecordId: string | undefined,
    isOpen: boolean,
    onOpen: () => void,
    onClose: () => void
}

const PlantRecordFormComponent = observer(function PlantRecordForm({ plant, plantRecordId, onOpen, onClose, isOpen }: Props) {
    //const [open, setOpen] = useState(openForm);

    const [plantRecord, setRecord] = useState({
        id: '',
        plantId: '',
        datePlanted: '',
        amountPlanted: 0,
        progress:0
    });

    const [selectedPlant, setPlant] = useState({
        id: '',
        name: '',
        isHybrid: false,
        directSewing: false,
        germinationTemp: 0,
        cropRotatoin: 0,
        description: '',
        imageSrc: '',
        repeatedPlanting: 0
    });

    useEffect(() => {
        if (plant != undefined) {
            setPlant(plant);
        }
    }, [plant])

    useEffect(() => {
        if (plantRecordId != '') {
            store.plantRecordStore.loadPlantRecord(plantRecordId!).then(plantRecord => setRecord(plantRecord!));
        }
    }, [plantRecordId])
    

    

    function handleSubmit() {
        //console.log("submit");
        //e.preventDefault();
        if (plantRecord.id == '') {
            plantRecord.id = uuid();
            plantRecord.plantId = selectedPlant.id;
            store.plantRecordStore.createPlantRecord(plantRecord);
        }
        else {
            store.plantRecordStore.updatePlantRecord(plantRecord);
        }
        onClose();
    }

    function handleInputCHhange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setRecord({ ...plantRecord, [name]: value });
    }
    return (

        <Modal as={Form}
            onSubmit={handleSubmit}
            onClose={onClose}
            onOpen={onOpen}
            open={isOpen}>
            <Modal.Header>{selectedPlant.name}</Modal.Header>
            <Modal.Content image>
                <Image size='medium' src={`/src/assets/plants/${selectedPlant.imageSrc}`} wrapped />
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
                <Button
                    onClick={onClose}
                    content="Zrusit"
                    labelPosition='right'
                    icon='remove'
                    negative
                />
            </Modal.Actions>
            </Modal>
    )
})
export default PlantRecordFormComponent;