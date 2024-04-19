
import { observer } from "mobx-react-lite";
import { Header, Select, Form, FormField, FormCheckbox, FormInput, FormTextArea, FormGroup, Divider, Grid, GridRow, GridColumn, Button, FormButton, CheckboxProps } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { ChangeEvent, SyntheticEvent, useState } from "react";
import MonthWeekSelect from "../../app/common/form/MonthWeekSelect";
import { PlantDTO } from "../../models/PlantDTO";
import { runInAction } from "mobx";

const NewPlantForm = observer(function NewPlantForm() {
    const [disabled, setDisabled] = useState(true);
    const [differentPlanting, setDifferentPlanting] = useState(false);
    const { plantStore } = useStore();
    const { allPLantTypesOptions, allPlantTypes} = plantStore;

    const [initialValue, setInitialValue] = useState({
        name: "",
        isHybrid: false,
        directSewing: false,
        preCultivation: false,
        germinationTemp: 0,
        description: "",
        repeatedPlanting: 0,
        plantTypeId:""
    } as PlantDTO);

    const [plantTypeId, setPlantTypeId] = useState("");

    const handlePlantTypeChangeClick = (e: SyntheticEvent<HTMLElement, Event>, data) => {
        const plantType = allPlantTypes.get(data.value);
        setDisabled(false);
        if (plantType) {
            setPlantTypeId(plantType.id)
            setInitialValue({ ...initialValue, ...plantType });
            runInAction(() => {
                plantStore.newPlantSowingFrom = plantType.sowingFrom;
                plantStore.newPlantSowingTo = plantType.sowingTo;
                plantStore.newPlantHarvestFrom = plantType.harvestFrom;
                plantStore.newPlantHarvestTo = plantType.harvestTo;
            })
        }
    }

    const handleChange = (e, data) => {
        //console.log(data);
        const { name, value } = e.target;
            setInitialValue({ ...initialValue, [name]: value });
    }

    const handleCheckBoxChange = (e, data) => {
        const { name, checked } = data;
        setInitialValue({ ...initialValue, [name]: checked });
    }

    
    return (
        <>
            <Form onSubmit={() => plantStore.createNewPlant(initialValue, plantTypeId)} >
                <Header>
                    Přidání nové rostliny
                </Header>
                <Select name='plantType' placeholder='Typ' options={allPLantTypesOptions} disabled={false} onChange={handlePlantTypeChangeClick} />
                <FormField name='name' placeholder='Název' label='Název' control='input' disabled={disabled} onChange={handleChange} />
                <FormCheckbox name='isHybrid' label='Hybridní odrůda' disabled={disabled} onChange={handleCheckBoxChange} />
                <FormCheckbox name='directSewing' label='Přímý výsev' checked={initialValue.directSewing} disabled={disabled} onChange={handleCheckBoxChange} />
                <FormCheckbox name='preCultivation' label='Předpěstovíní' checked={initialValue.preCultivation} disabled={disabled} onChange={handleCheckBoxChange} />
                <FormInput name='germinationTemp' type='number' label='Teplota klíčení' value={initialValue.germinationTemp} disabled={disabled} onChange={handleChange} />
                <FormTextArea name='description' rows='3' label='Popis' placeholder='Popis' value={initialValue.description} disabled={disabled} onChange={handleChange} />
                <FormInput name='repeatedPlanting' label='Opakovaný výsev po dnech' placeholder='Opakovaný výsev po dnech' value={initialValue.repeatedPlanting} disabled={disabled} onChange={handleChange} />
                <FormCheckbox name='differentPlantingMonths' label='Upravit data výsadby a sklizně' checked={differentPlanting} disabled={disabled} onChange={() => setDifferentPlanting(!differentPlanting)} />
                <Grid columns={2}>
                    <GridRow>
                        <GridColumn>
                            <Header size='small'>Výsev od </Header>
                        </GridColumn>
                        <GridColumn>
                            <Header size='small'>Výsev do </Header>
                        </GridColumn>
                    </GridRow>
                    <GridRow>
                        <GridColumn>
                            <MonthWeekSelect disabled={!differentPlanting} key="sowingFrom" value={plantStore.newPlantSowingFrom}  />
                        </GridColumn>
                        <GridColumn>
                            <MonthWeekSelect disabled={!differentPlanting} key="sowingTo" value={plantStore.newPlantSowingTo} />
                        </GridColumn>
                    </GridRow>
                </Grid>
                <Grid columns={2}>
                    <GridRow>
                        <GridColumn>
                            <Header size='small'>Sklizeň od </Header>
                        </GridColumn>
                        <GridColumn>
                            <Header size='small'>Sklizeň do </Header>
                        </GridColumn>
                    </GridRow>
                    <GridRow>
                        <GridColumn>
                            <MonthWeekSelect disabled={!differentPlanting} value={plantStore.newPlantHarvestFrom} />
                        </GridColumn>
                        <GridColumn>
                            <MonthWeekSelect disabled={!differentPlanting} value={plantStore.newPlantHarvestTo} />
                        </GridColumn>
                    </GridRow>
                </Grid>
                <Divider hidden />
                <FormButton positive content='Ulozit' disabled={disabled} />
            </Form>
        </>
    )
})

export default NewPlantForm;