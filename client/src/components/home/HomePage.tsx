import { Link } from "react-router-dom";
import { Container, Header, Segment, Button } from "semantic-ui-react";


export default function HomePage() {
    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container text>
                <Header as='h1' inverted>                    
                    Zahradníkův pomocník
                </Header>
                <Button as={Link} to='/sewingplan' size='huge' inverted>
                    Pojďme na to!
                </Button>
            </Container>
        </Segment>
    )
}