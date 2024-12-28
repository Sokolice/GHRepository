import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoginComponent from "../users/login";
import MainDashboard from "../dashboards/MainDashboard";
import { Button, Container, Header, Segment } from "semantic-ui-react";
import RegisterForm from "../users/RegisterForm";

const HomePageComponent = observer(function HomePage() {
  const { userStore, modalStore } = useStore();

  return (
    <>
      <Segment inverted textAlign="center" vertical className="masthead">
        <Container>
          <Header as="h1" inverted>
            Zahradníkův pomocník
          </Header>
          {userStore.isLoggedIn ? (
            <MainDashboard />
          ) : (
            <>
              <Button
                content="Prihlasit"
                onClick={() => modalStore.openModal(<LoginComponent />)}
              />
              <Button
                content="Registrovat"
                onClick={() => modalStore.openModal(<RegisterForm />)}
              />
            </>
          )}
        </Container>
      </Segment>
    </>
  );
});

export default HomePageComponent;
