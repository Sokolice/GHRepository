import { Container, Segment } from "semantic-ui-react";
import { store } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../layout/LoadingComponent";
import BedsFormComponent from "./BedsForm";
import BedsListComponent from "./BedsList";



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