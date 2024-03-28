import { ErrorMessage, Form, Formik } from "formik";
import MyInput from "../../app/common/form/MyInput";
import { Button, Header, Label } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import * as Yup from 'yup';

const RegisterForm = observer(function RegisterForm() {
    const { userStore } = useStore();
    return (
        <Formik
            initialValues={{ displayName: '', userName: '', email: '', password: '', error: null }}
            onSubmit={(values, { setErrors }) => userStore.register(values).catch(error =>
                setErrors({ error: error }))}
            validationSchema={Yup.object({
                displayName: Yup.string().required(),
                userName: Yup.string().required(),
                email: Yup.string().required(),
                password: Yup.string().required(),
            })}
        >
            {({ handleSubmit, isSubmitting, errors, isValid, dirty }) => (
                <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                    <Header as='h2'>Registrace</Header>
                    <MyInput placeholder="Jmeno" name="displayName" type='text' />
                    <MyInput placeholder="Uzivatelske jmeno" name="userName" type='text' />
                    <MyInput placeholder="Email" name="email" type='text' />
                    <MyInput placeholder="Password" name="password" type='password' />
                    <ErrorMessage name='error' render={() =>
                        <Label style={{ marginBottom: 10 }} basic color='red' content={errors.error} />
                    } />
                    <Button disabled={!isValid || !dirty || isSubmitting}
                        loading={isSubmitting}
                        positive
                        content="Register"
                        type="submit"
                        fluid />
                </Form>
            )}
        </Formik>
    )
})

export default RegisterForm;