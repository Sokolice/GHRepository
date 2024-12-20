import { Container } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import BedsFormComponent from "./BedsForm";
import BedsListComponent from "./BedsList";
import LoadingComponent from "../layout/LoadingComponent";
import { store } from "../../app/stores/store";



const BedsPage = observer(function BedsPage() {

    if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )
    return (
        <Container >
            <BedsFormComponent/>
            <BedsListComponent/>
        </Container>
    )
})

export default BedsPage;