import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { Container, Header, Segment, Card, Grid, GridColumn, Image, CardContent, CardHeader, Label, Popup } from "semantic-ui-react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSeedling, faSquareCheck, faRepeat, faWheatAwn, faSnowflake, faFire, faCloudRain } from '@fortawesome/free-solid-svg-icons'
import LoadingComponent from "../layout/LoadingComponent";
import { Link } from "react-router-dom";

const MainDashboard = observer(function MainDashboard() {

    const { globalStore } = useStore();
    const { loading, stats } = globalStore;

    if (loading)
        return (
            <LoadingComponent content="Loading" />
        )
    return (<>
                <Header as='h1' inverted>
                    Zahradníkův pomocník
                </Header>
                <Grid columns={4}>
                    <GridColumn>
                        <Card>
                            <Image fluid
                                src='../src/assets/other/seeds.jpg' as={Link} to='/sewingplan' />
                            <CardContent>
                                <CardHeader>
                                    Přehled výsevu &nbsp;
                                    {stats?.missingSowingThisWeekAmount > 0
                                        ?
                                        <Popup content='Tento týden zbývá vysadit' trigger={
                                            <Label as={Link} to='/sewingplan' color='red'>
                                                <FontAwesomeIcon icon={faSeedling} /> {stats?.missingSowingThisWeekAmount}
                                            </Label>
                                        } />

                                        : null
                                    }{stats?.canBeSowedRepeatedlyAmount > 0
                                        ?
                                        <Popup content='Opakovaný výsev' trigger={
                                            <Label as={Link} to='/sewingplan' color='red'>
                                                <FontAwesomeIcon icon={faRepeat} /> {stats?.canBeSowedRepeatedlyAmount}
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
                                    Roste &nbsp;
                                    {stats?.readyToHarvestAmount > 0
                                        ?
                                        <Popup content='Ke sklizni' trigger={
                                            <Label as={Link} to='/plantrecords' color='red'>
                                                <FontAwesomeIcon icon={faWheatAwn} /> {stats?.readyToHarvestAmount}
                                            </Label>
                                        } />

                                        : null
                                    }
                                    {stats?.freezeAlert
                                        ?
                                        <Popup content='Nebezpečí mrazu' trigger={
                                            <Label as={Link} to='/plantrecords' color='red'>
                                                <FontAwesomeIcon icon={faSnowflake} />
                                            </Label>
                                        } />

                                        : null
                                    }
                                    {stats?.highTemperatureAlert
                                        ?
                                        <Popup content='Nebezpečí vysokých teplot' trigger={
                                            <Label as={Link} to='/plantrecords' color='red'>
                                                <FontAwesomeIcon icon={faFire} />
                                            </Label>
                                        } />

                                        : null
                                    }
                                    {stats?.rainPeriodAlert
                                        ?
                                        <Popup content='Dlouhodobý déšť' trigger={
                                            <Label as={Link} to='/plantrecords' color='red'>
                                                <FontAwesomeIcon icon={faCloudRain} />
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
                                    Zahradnické úkoly&nbsp;
                                    {stats?.missingTaskThisWeekAmount > 0
                                        ?
                                        <Popup content='Zbývá úkolů pro tento týden' trigger={
                                            <Label as={Link} to='/calendar' color='red'>
                                                <FontAwesomeIcon icon={faSquareCheck} /> {stats?.missingTaskThisWeekAmount}
                                            </Label>
                                        } />

                                        : null
                                    }
                                </CardHeader>
                            </CardContent>
                        </Card>
                    </GridColumn>
        </Grid>
    </>
    )

})

export default MainDashboard;