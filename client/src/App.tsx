/* eslint-disable @typescript-eslint/no-explicit-any */
import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios'
import { Grid, Item, List, Segment } from 'semantic-ui-react'
import Dashboard from './dashboard/Dashboard';

function App() {

    const [plants, setPlants] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:5180/api/plants')
            .then(response => {
                console.log(response);
                setPlants(response.data)
            })
    }, [])

  return (
    <>

          <Grid container columns={6}>
              {
                  plants.map((plant: any) => (
                      <Grid.Column>
                          <Dashboard plant={plant}/>
                      </Grid.Column>
                  ))
              }
          </Grid>
    </>
  )
}

export default App
