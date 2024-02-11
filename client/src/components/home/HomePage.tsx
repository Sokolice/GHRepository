import { Link } from "react-router-dom";
import { Container, Header, Segment, Card, Grid, GridColumn, Image, CardContent, CardHeader, Label, Icon, Popup } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSeedling } from '@fortawesome/free-solid-svg-icons'
import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import LoadingComponent from "../layout/LoadingComponent";

const HomePageComponent = observer(function HomePage() {

    const { globalStore, plantRecordStore, monthWeekStore } = useStore();
    const { calcMissingSowingAmount, missingSowingAmount, loading} = globalStore;
    const { loadPlantDTO, plantDTOList } = globalStore;
    const { loadPlantRecords, plantRecordMap } = plantRecordStore;
    const { monthWeekRelationList, loadMonthWeeekRelations } = monthWeekStore;

    const [ready, setReady] = useState(false);

    useEffect(() => {

        const customEffect = async () => {
                if (monthWeekRelationList.length <= 0)
                    await loadMonthWeeekRelations();
                if (plantDTOList.size <= 0)
                    await loadPlantDTO();
                if (plantRecordMap.size <= 0)
                    await loadPlantRecords();
                setReady(true); 
        };

        customEffect();
    }, [loadMonthWeeekRelations, loadPlantDTO, loadPlantRecords, monthWeekRelationList.length, plantDTOList.size, plantRecordMap.size]);


    useEffect(() => {
        if (ready)
            calcMissingSowingAmount();
    }, [ready]);
    
    if (loading)
        return (
            <LoadingComponent />
        )
    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container>
                <Header as='h1' inverted>                    
                    Zahradníkův pomocník
                </Header>
                <Grid columns={4}>
                    <GridColumn>
                        <Card>
                            <Image fluid
                                src='../src/assets/other/seeds.jpg' as={Link} to='/sewingplan'/>
                            <CardContent>
                                <CardHeader>
                                    Přehled výsevu &nbsp;
                                    {missingSowingAmount > 0
                                        ?
                                        <Popup content='Tento týden možno vysadit' trigger={
                                            <Label as={Link} to='/sewingplan' color='red'>
                                                <FontAwesomeIcon icon={faSeedling} /> {missingSowingAmount}
                                            </Label>
                                        } />
                                     
                                    : null
                            }
                                    
                                </CardHeader>
                            </CardContent>
                        </Card>
                    </GridColumn>
                    <GridColumn>
                        <Card>
                            <Image fluid
                                src='../src/assets/other/raised_bed.jpg' as={Link} to='/plantrecords' />
                            <CardContent>
                                <CardHeader>
                                    Roste
                                </CardHeader>
                            </CardContent>
                        </Card>
                    </GridColumn>
                    <GridColumn>
                        <Card>
                            <Image fluid
                                src='../src/assets/other/plan.jpg' as={Link} to='/beds' />
                            <CardContent>
                                <CardHeader>
                                    Plánování záhonů
                                </CardHeader>
                            </CardContent>
                        </Card>
                    </GridColumn>
                    <GridColumn>
                        <Card>
                            <Image fluid
                                src='../src/assets/other/todo.jpg' as={Link} to='/calendar' />
                            <CardContent>
                                <CardHeader>
                                    Zahradnické úkoly
                                </CardHeader>
                            </CardContent>
                        </Card>
                    </GridColumn>                   
                </Grid>                
            </Container>
        </Segment>
    )
})

export default HomePageComponent;