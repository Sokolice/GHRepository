import { observer } from "mobx-react-lite";
import { store, useStore } from "../../app/stores/store";
import { Button, Divider, Form, Header, Label } from "semantic-ui-react";

interface Props {
    plantRecordId: string
}

const ConfirmationDeleteComponent = observer(function ConfirmationDelete({ plantRecordId }: Props) {
    const { modalStore } = useStore();
    function handleSubmit() {
        //console.log("submit");
        //e.preventDefault();
        if (plantRecordId != '') {
            store.plantRecordStore.deletePlantRecord(plantRecordId);
        }
    }

    return (
        <Form            
            onSubmit={handleSubmit}>
            <Header>Smazání záznamu</Header>
            <Divider/>
            <Header>
                Určitě chcete smazat tento záznam?
            </Header>
            <Divider />
            <Button
                onClick={() => { modalStore.closeModal() }}
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
        </Form>
    )





})

export default ConfirmationDeleteComponent;