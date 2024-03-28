
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoginComponent from "../users/login";
import MainDashboard from "../dashboards/MainDashboard";

const HomePageComponent = observer(function HomePage() {

    const {userStore } = useStore();
    
    return (
        <>
            {userStore.isLoggedIn ? (
                <MainDashboard />
            ) : (
                <LoginComponent/>
            )}
        </>
        )
})

export default HomePageComponent;