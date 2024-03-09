import { Button, Card, CardGroup, Label, List, ListItem } from "semantic-ui-react"
import { store } from "../../app/stores/store"
import { BedRelation } from "../../models/BedRelation"
import { Link } from "react-router-dom"
import { SyntheticEvent } from "react"
import { PlantDTO } from "../../models/PlantDTO"
import { observer } from "mobx-react-lite"

const BedsListComponent = observer(function BedsList() {


    function listPlantsInBed(plants: PlantDTO[]) {
        return (
            <List>
                {
                    plants.map(item => {
                        return (
                            <ListItem key={item.id}>
                                {item.name}
                            </ListItem>
                        )
                    })
                }
            </List>
        )

    }

    function handleBedDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        store.bedsStore.deleteBed(id);
    }
    return(
    <div id="beds">
        <CardGroup>
            {store.bedsStore.beds.map((bedRelation: BedRelation) => (
                <Card key={bedRelation.bed.id}>

                    <Card.Content>
                        {bedRelation.bed.cropRotation > 0 || bedRelation.bed.isDesign ? (

                            <Label attached='top' color='blue'>{bedRelation.bed.cropRotation > 0 ? bedRelation.bed.cropRotation + " trať" : null}  {bedRelation.bed.isDesign ? "Návrh" : null}</Label>
                        ) : null
                        }

                        <Card.Header>{bedRelation.bed.name}</Card.Header>
                        <Card.Meta>
                            <Card.Header>šířka: {bedRelation.bed.width}m</Card.Header>
                            <Card.Header>délka: {bedRelation.bed.length}m</Card.Header>
                        </Card.Meta>
                        {bedRelation.bed.note != "" ?
                            <Card.Description>
                                Poznámka: {bedRelation.bed.note}
                            </Card.Description>
                            : null
                        }
                        {listPlantsInBed(bedRelation.plants)}
                        <Button icon='info' color='blue' as={Link} to={`/beds/${bedRelation.bed.id}`} content="Detail" />
                        <Button icon='minus' color='red' content='Smazat' onClick={(e) => handleBedDelete(e, bedRelation.bed.id)} />

                    </Card.Content>
                </Card>
            ))}
        </CardGroup>
        </div>
    )
})

export default BedsListComponent