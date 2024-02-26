import { observer } from "mobx-react-lite";
import { Button, Form, Modal, Image, Header, Rating, Label } from "semantic-ui-react";
import { PlantDTO } from "../../models/PlantDTO";
import { ChangeEvent, useState } from "react";
import { store } from "../../app/stores/store";

interface Props {
    plantDTO: PlantDTO,
    isOpen: boolean,
    onOpen: () => void,
    onClose: () => void
}

const HarvestComponent = observer(function Harvest({ plantDTO, onOpen, onClose, isOpen }: Props) {
    const [harvest, setHarvest] = useState({
        id: '',
        plantId: '',
        date: '',
        amount: 0,
        rating: 0,
        note: ''
    });

    function handleChangeOnRate(e, {rating}) {
        setHarvest({ ...harvest, rating: rating});
    }
    function handleSubmit() {
        harvest.plantId = plantDTO.id;
        store.globalStore.saveHarvest(harvest);

        onClose();
    }
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setHarvest({ ...harvest, [name]: value });
    }
    return (
        <Modal
            dimmer='blurring'
            as={Form}
            onSubmit={handleSubmit}
            onClose={onClose}
            onOpen={onOpen}
            open={isOpen}>
            <Modal.Header>Sklizen</Modal.Header>
            <Modal.Content image>
                <Image size='medium' src={`/src/assets/plants/${plantDTO.imageSrc}`} wrapped />
                <Modal.Description>
                    <Form.Input name='amount' placeholder='gramy' id='amount' label='Množství' onChange={handleInputChange}></Form.Input>
                    <Form.Input name='date' placeholder='Datum' id='date' label='Datum' type='date' onChange={handleInputChange}></Form.Input>
                    <Form.TextArea placeholder='Poznámka' id="note" name="note" label="Poznámka" onChange={handleInputChange} />
                    <Rating name='rating' id='rating' maxRating={5} defaultRating={0} icon='star' size='huge' onRate={handleChangeOnRate} />
                </Modal.Description>
            </Modal.Content>
            <Modal.Actions>
                <Button
                    onClick={onClose}
                    content="Ne"
                    labelPosition='right'
                    icon='checkmark'
                    negative
                />
                <Button
                    type='submit'
                    content="Ano"
                    labelPosition='right'
                    icon='remove'
                    positive
                />
            </Modal.Actions>
        </Modal>
    )





})

export default HarvestComponent;