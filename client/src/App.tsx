/* eslint-disable @typescript-eslint/no-explicit-any */
import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios'
import { Card, Grid, Icon, Item, List, Segment, Image, Container, Label } from 'semantic-ui-react'
import Dashboard from './dashboard/Dashboard';
import { Plant } from './models/Plant';

function App() {

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
                                    Předpěstování
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

export default App
