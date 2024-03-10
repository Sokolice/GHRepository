import { ChangeEvent, SyntheticEvent, useState } from "react";
import { Button, Card, CardGroup, Checkbox, Container, Dropdown, FormField, Grid, GridColumn, GridRow, Header, Label, List, ListItem, Segment } from "semantic-ui-react";
import { store } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import LoadingComponent from "../layout/LoadingComponent";
import { BedRelation } from "../../models/BedRelation";
import { PlantDTO } from "../../models/PlantDTO";
import { Formik, Form } from "formik";
import * as Yup from 'yup';
import MyTextInput from "../../app/common/form/MyInput";
import MyTextArea from "../../app/common/form/MyTextArea";
import { BedDTO } from "../../models/BedDTO";
import MyInput from "../../app/common/form/MyInput";
import MySelectInput from "../../app/common/form/MySelectInput";



const BedsFormComponent = observer(function BedsForm() {




    const [selectedBed, setBed] = useState<BedDTO>({
        id: "",
        name: "",
        length: 0,
        width: 0,
        isDesign: true,
        cropRotation: 0,
        note: "",
        numOfColumns: 0,
        numOfRows: 0
    })

    const [isRotationDisabled, setIsRotationDisabled] = useState(true);

    function handleFormSubmit(bed: BedDTO) {
        store.bedsStore.createBed(bed.width, bed.length, bed.name, bed.isDesign, bed.cropRotation, bed.note);
    }

    const cropRotationChange = () => {
        setIsRotationDisabled(!isRotationDisabled);
    }

    const options = [
        { key: 1, text: '1. trať', value: 1 },
        { key: 2, text: '2. trať', value: 2 },
        { key: 3, text: '3. trať', value: 3 },
    ]


    const validationSchema = Yup.object({
        name: Yup.string().required(),
        length: Yup.number()
            .min(1, "Délka musí být vetší než 0")
            .required('Délka musí být zadána'),
        width: Yup.number()
            .min(1, "Šířka musí být vetší než 0")
            .required('Šířka musí být zadána')
    })

    return (
        <Segment>
        <Header>Přidání záhonu</Header>
        <Formik
            validationSchema={validationSchema}
            enableReinitialize
            initialValues={selectedBed}
            onSubmit={values => handleFormSubmit(values)}>
            {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                <Form onSubmit={handleSubmit} className='ui form'>
                    <Grid columns={2}>
                        <GridRow>
                            <GridColumn >
                                <MyInput name='name' placeholder='Název' type='text' label='Název' />
                                <MyInput name='length' placeholder='Délka' type='number' label='Délka' />
                                <MyInput name='width' placeholder='Šířka' type='number' label='Šířka' />
                                <MyTextArea name='note' placeholder='Poznamka' rows={3} />
                            </GridColumn>
                            <GridColumn >
                                <MyInput name='isDesign' type='checkbox' label='Tvorba návrhu' />
                                <MyInput name='isRotation' type='checkbox' label='Pěstování v tratích' onClick={cropRotationChange} />
                                <MySelectInput name='cropRotation' options={options} placeholder='Trať' label='Trať' disabled={isRotationDisabled} />
                            </GridColumn>
                        </GridRow>

                        <GridRow>
                                <GridColumn>
                                    <Button
                                        disabled={isSubmitting || !dirty || !isValid}
                                        type='submit'
                                        content="Přidat záhon"
                                        labelPosition='right'
                                        icon='checkmark'
                                        positive
                                    />
                            </GridColumn>
                        </GridRow>
                    </Grid>
                </Form>
            )}
            </Formik>
        </Segment>
    )
})

export default BedsFormComponent;