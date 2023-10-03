import { Item, Segment } from "semantic-ui-react";
import { Plant } from "../models/Plant";

interface Props {
    plant: Plant
}


export default function Dashboard({ plant }: Props) {
    return (
            <Item>
                <Item.Image src='/src/assets/plant.png' size='mini' />
                <Item.Content>
                <Item.Header>{plant.name}</Item.Header>
                </Item.Content>
            </Item>
    )
}