import { observer } from "mobx-react-lite";
import { PlantDTO } from "../../models/PlantDTO";
import { Button, Divider, Grid, GridColumn, GridRow, Header, Image, Modal } from "semantic-ui-react";
import { useEffect, useState } from "react";
import { v4 as uuid } from 'uuid'
import { store, useStore } from "../../app/stores/store";
import { Formik, Form } from "formik";
import LoadingComponent from "../layout/LoadingComponent";
import * as Yup from 'yup';
import MyInput from "../../app/common/form/MyInput";
import MyTextArea from "../../app/common/form/MyTextArea";
import MyDateInput from "../../app/common/form/MyDateInput";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";

interface Props {
    plant: PlantDTO,
    plantRecordId: string
}

const PlantRecordFormComponent = observer(function PlantRecordForm({ plant, plantRecordId }: Props) {
    const { modalStore } = useStore();

    const [plantRecord, setRecord] = useState<PlantRecordDTO>({
        id: '',
        plantId: '',
        datePlanted: null,
        amountPlanted: 0,
        progress: 0,
        presumedHarvest: '0001-01-01',
        note: '',
        mark:''
    });

    const validationSchema = Yup.object({
        note: Yup.string().notRequired(),
        amountPlanted: Yup.number().integer().min(0, "Množství nesmí být záporné"),
        datePlanted: Yup.date().required("Datum musí být vybráno")
    })

    useEffect(() => {
        if (plantRecordId != '') {
            store.plantRecordStore.loadPlantRecord(plantRecordId!).then(plantRecord => setRecord(plantRecord!));
        }
    }, [plantRecordId])




    function handleFormSubmit(plantRecord: PlantRecordDTO) {
        if (plantRecord.id == '') {
            plantRecord.id = uuid();
            plantRecord.plantId = plant.id;
            store.plantRecordStore.createPlantRecord(plantRecord);
        }
        else {
            store.plantRecordStore.updatePlantRecord(plantRecord);
        }
    }

    if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )
    return (


        <Formik
            validationSchema={validationSchema}
            enableReinitialize
            initialValues={plantRecord}
            onSubmit={values => handleFormSubmit(values)}>

            {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                <Form onSubmit={handleSubmit} className='ui form'>
                    <Header>{plant.name}</Header>
                    <Divider />
                    <Grid columns={2}>
                        <GridRow>
                            <GridColumn width={6}>
                                <Image size='medium' src={`/src/assets/plants/${plant.imageSrc}`} wrapped />
                            </GridColumn>

                            <GridColumn width={10}>
                                <MyDateInput
                                    name='datePlanted'
                                    placeholderText='Datum výsadby'
                                    dateFormat='dd.MM.yyyy'
                                />
                                <MyInput name='amountPlanted' placeholder='Množství' type='number' label='Množství' />
                                <MyTextArea name='note' placeholder='Poznámka' rows={3} label="Poznámka" />
                                <MyInput name='mark' placeholder='Označení' type='text' label='Označení' />

                            </GridColumn>
                        </GridRow>

                        <GridRow>
                            <GridColumn width={16}>
                            <Button
                                loading={isSubmitting}
                                disabled={!dirty || !isValid}
                                type='submit'
                                content="Uložit"
                                labelPosition='right'
                                icon='checkmark'
                                positive
                            />
                            <Button
                                onClick={() => { modalStore.closeModal() }}
                                content="Zrušit"
                                labelPosition='right'
                                icon='remove'
                                negative
                                />
                            </GridColumn>

                        </GridRow>
                    </Grid>
                </Form>
            )}
        </Formik>

    )
})
export default PlantRecordFormComponent;