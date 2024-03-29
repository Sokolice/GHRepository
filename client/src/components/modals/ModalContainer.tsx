import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { Modal } from "semantic-ui-react";

const ModalContainer = observer(function ModalContainer() {
    const { modalStore } = useStore();
    return (
        <Modal open={modalStore.modal.open}
            onClose={modalStore.closeModal}
            dimmer='blurring'>
            <Modal.Content>
                {modalStore.modal.body}
            </Modal.Content>
        </Modal>
    )

})
export default ModalContainer;