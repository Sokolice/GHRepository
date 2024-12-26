import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { Button, Divider, Form, Header } from "semantic-ui-react";

interface Props {
    handleSubmit: () => void;
    message?:string;
}

const ConfirmationDeleteComponent = observer(function ConfirmationDelete({ handleSubmit }: Props) {
    const { modalStore, globalStore } = useStore();
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
                loading={globalStore.loading}
                type='submit'
                content="Ano"
                labelPosition='right'
                icon='remove'
                positive
            />
            <Button
                onClick={() => { modalStore.closeModal() }}
                    content="Ne"
                    labelPosition='right'
                    icon='checkmark'
                    negative
                />
        </Form>
    )





})

export default ConfirmationDeleteComponent;