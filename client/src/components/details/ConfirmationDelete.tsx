import { observer } from "mobx-react-lite";
import { store } from "../../app/stores/store";
import { Button, Form, Modal } from "semantic-ui-react";

interface Props {
    plantRecordId: string,
    isOpen: boolean,
    onOpen: () => void,
    onClose: () => void
}

const ConfirmationDeleteComponent = observer(function ConfirmationDelete({plantRecordId, onOpen, onClose, isOpen }: Props) { 

    function handleSubmit() {
        //console.log("submit");
        //e.preventDefault();
        if (plantRecordId != '') {
            store.plantRecordStore.deletePlantRecord(plantRecordId);
        }

        onClose();
    }

    return (
        <Modal
            dimmer='blurring'
            as={Form}
            onSubmit={handleSubmit}
            onClose={onClose}
            onOpen={onOpen}
            open={isOpen}>
            <Modal.Header>Smazání záznamu</Modal.Header>
            <Modal.Content image>
                Určitě chcete smazat tento záznam?
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

export default ConfirmationDeleteComponent;