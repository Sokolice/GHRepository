
import { observer } from "mobx-react-lite";
import { Header, Select, Form, FormField, FormCheckbox, FormInput, FormTextArea } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { SyntheticEvent, useState } from "react";

const NewPlantForm = observer(function NewPlantForm() {
    const [ disabled, setDisabled ] = useState(true);
    const { plantStore } = useStore();
    const { allPLantTypesOptions, allPlantTypes } = plantStore;

    const [initialValue, setInitialValue] = useState({
        name: "",
        directSewing: false,
        preCultivation: false,
        germinationTemp: 0,
        description: "",
        repeatedPlanting: 0
    });
    const handleChangeClick = (e: SyntheticEvent<HTMLElement, Event>, data) => {
        const plantType = allPlantTypes.get(data.value);
        setDisabled(false);
        if (plantType && !disabled) {
            setInitialValue({ ...initialValue, ...plantType });
        }
    }
    return (
        <>
            <Form onSubmit={() => plantStore.createNewPlant()} >
                <Header>
                    Pridani nove rostliny
                </Header>
                <Select name='plantType' placeholder='Typ' options={allPLantTypesOptions} disabled={false} onChange={handleChangeClick} />
                <FormField name='name' placeholder='Nazev' label='Nazev' control='input' disabled={disabled} />
                <FormCheckbox name='isHybrid' label='Hybridni odruda' disabled={disabled} />
                <FormCheckbox name='directSewing' label='Primy vysev' checked={initialValue.directSewing} disabled={disabled} />
                <FormCheckbox name='preCultivation' label='Predpestovani' checked={initialValue.preCultivation} disabled={disabled} />
                <FormInput name='germinationTemp' type='number' label='Teplota kliceni' value={initialValue.germinationTemp} disabled={disabled} />
                <FormTextArea name='description' rows='3' label='Popis' placeholder='Popis' value={initialValue.description} disabled={disabled} />
                <FormInput name='repeatedPlanting' label='Opakovany vysev po' placeholder='Opakovany vysev po' value={initialValue.repeatedPlanting} disabled={disabled} />
            </Form>
        </>
    )
})

export default NewPlantForm;