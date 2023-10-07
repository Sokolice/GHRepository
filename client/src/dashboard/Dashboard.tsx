import { Card, Container, Image, Label, Icon } from "semantic-ui-react";
import { Plant } from "../models/Plant";
import { useEffect, useState } from "react";
import axios from "axios";


export default function Dashboard() {

    const [plants, setPlants] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:5180/api/plants')
            .then(response => {
                console.log(response);
                setPlants(response.data);
                console.log(plants);
            })
    }, [])

    return (
        <Container>
            <Card.Group itemsPerRow={6} >
                {
                    plants.map((plant: Plant) => (
                        <Card key={plant.id}>
                            <Image src={`/src/assets/plants/${plant.imageSrc}`} wrapped ui={false} />
                            <Card.Content>
                                <Card.Header>{plant.name}</Card.Header>
                            </Card.Content>
                            {plant.directSewing ? null :
                                <Label color="grey">
                                    <Icon name='home' />
                                    Pøedpìstování
                                </Label>}

                            {plant.isHybrid ? null :
                                <Label color="yellow">
                                    <Icon name='pagelines' />
                                    Hybrid
                                </Label>}
                        </Card>
                    ))
                }
            </Card.Group>
        </Container>
    )
}