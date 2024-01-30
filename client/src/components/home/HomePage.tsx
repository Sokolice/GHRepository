import { Link } from "react-router-dom";
import { Container, Header, Segment, Card, Grid, GridColumn } from "semantic-ui-react";


export default function HomePage() {
    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container text>
                <Header as='h1' inverted>                    
                    Zahradníkův pomocník
                </Header>
                <Grid columns={3}>
                    <GridColumn>
                        <Card image='../src/assets/other/seeds.jpg' header='Prehled vysevu' as={Link} to='/sewingplan' />
                    </GridColumn>
                    <GridColumn>

                        <Card image='../src/assets/other/raised_bed.jpg' header='Roste' as={Link} to='/plantrecords' />
                    </GridColumn>
                        <GridColumn>
                        <Card image='../src/assets/other/plan.jpg' header='Planovani zahonu' as={Link} to='/beds' />
                    </GridColumn>
                </Grid>                
            </Container>
        </Segment>
    )
}