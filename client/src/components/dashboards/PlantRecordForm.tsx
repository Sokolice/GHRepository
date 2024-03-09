import { observer } from "mobx-react-lite";
import { PlantDTO } from "../../models/PlantDTO";
import { Button, Image, Modal } from "semantic-ui-react";
import { useEffect, useState } from "react";
import { v4 as uuid } from 'uuid'
import { store } from "../../app/stores/store";
import { Formik, Form } from "formik";
import LoadingComponent from "../layout/LoadingComponent";
import * as Yup from 'yup';
import MyTextInput from "../../app/common/form/MyInput";
import MyTextArea from "../../app/common/form/MyTextArea";
import MyDateInput from "../../app/common/form/MyDateInput";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";

interface Props {
    plant: PlantDTO | undefined,
    plantRecordId: string | undefined,
    isOpen: boolean,
    onOpen: () => void,
    onClose: () => void
}

const PlantRecordFormComponent = observer(function PlantRecordForm({ plant, plantRecordId, onOpen, onClose, isOpen }: Props) {
    const [plantRecord, setRecord] = useState<PlantRecordDTO>({
        id: '',
        plantId: '',
        datePlanted: null,
        amountPlanted: 0,
        progress: 0,
        presumedHarvest: '0001-01-01',
        note: ''
    });

    const [selectedPlant, setPlant] = useState<PlantDTO>({
        id: '',
        name: '',
        isHybrid: false,
        directSewing: false,
        germinationTemp: 0,
        cropRotation: 0,
        description: '',
        imageSrc: '',
        repeatedPlanting: 0
    });

    const validationSchema = Yup.object({
        note: Yup.string().notRequired(),
        amountPlanted: Yup.number().integer().min(0, "Množství nesmí být záporné"),
        datePlanted: Yup.date().required("Datum musí být vybráno")
    })

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
    

    

    function handleFormSubmit(plantRecord: PlantRecordDTO) {
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

    /*function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setRecord({ ...plantRecord, [name]: value });
    }*/

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
                <Form >
                <Modal
                dimmer='blurring' 
                as={Form}
                onSubmit={handleSubmit}
                onClose={onClose}
                onOpen={onOpen}
                        open={isOpen} className='ui form'>
                <Modal.Header>{selectedPlant.name}</Modal.Header>
                <Modal.Content image>
                    <Image size='medium' src={`/src/assets/plants/${selectedPlant.imageSrc}`} wrapped />
                            <Modal.Description>
                                <MyDateInput
                                    name='datePlanted'
                                    placeholderText='Datum vysadby'
                                    dateFormat='dd.MM.yyyy'
                                />
                                <MyTextInput name='amountPlanted' placeholder='Množství' type='number' label='Množství' />
                               <MyTextArea name='note' placeholder='Poznamka' rows={3} />
                            </Modal.Description>
                        </Modal.Content>
                        <Modal.Actions>
                            <Button
                                disabled={isSubmitting || !dirty || !isValid}
                                type='submit'
                                content="Uložit"
                                labelPosition='right'
                                icon='checkmark'
                                positive
                            />
                            <Button
                                onClick={onClose}
                                content="Zrušit"
                                labelPosition='right'
                                icon='remove'
                                negative
                            />
                        </Modal.Actions>
                    </Modal>
                </Form>
            ) }
        </Formik>
                    
    )
})
export default PlantRecordFormComponent;