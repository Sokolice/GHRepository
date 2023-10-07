import { Item, Segment } from "semantic-ui-react";
import { Plant } from "../models/Plant";

interface Props {
    plant: Plant
}


export default function Dashboard({ plant }: Props) {
    return (
        <Item key={plant.id}>
            <Item.Content>
            <Item.Header>{plant.name}</Item.Header>
            </Item.Content>
            <Item.Image src={`/src/assets/plants/${plant.imageSrc}`} size='small' />
                
            </Item>
    )
}