import { ErrorMessage, Form, Formik } from "formik";
import MyInput from "../../app/common/form/MyInput";
import { Button, Container, Label, Segment } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";

const LoginComponent = observer(function LoginForm() {
    const { userStore } = useStore();
    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container>
                <Formik
                initialValues={{ email: '', password: '', error: null }}
                onSubmit={(values, { setErrors }) => userStore.login(values).catch(error =>
                    setErrors({ error: 'Uživatel se zadaným emailem a heslsem neexistuje' }))}    >
                {({ handleSubmit, isSubmitting, errors }) => (
                    <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                        <MyInput placeholder="Email" name="email" type='text' />
                        <MyInput placeholder="Password" name="password" type='password' />
                        <ErrorMessage name='error' render={() =>
                            <Label style={{ marginBottom: 10 }} basic color='red' content={errors.error} />
                            } />
                        <Button loading={isSubmitting} positive content="Login" type="submit" fluid />
                    </Form>
                )}
                </Formik>
            </Container>
        </Segment>
    )
})

export default LoginComponent;