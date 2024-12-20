import { observer } from "mobx-react-lite";
import { Grid, GridColumn, Header, List, ListContent, ListHeader, ListItem, Image, Accordion, AccordionTitle, AccordionContent, Icon, Checkbox, Button, Container, Divider } from "semantic-ui-react";
import { store, useStore } from "../../app/stores/store";
import { useEffect, useState } from "react";
import NewPlantForm from "../details/NewPlantForm";
import LoadingComponent from "../layout/LoadingComponent";

const MyPlantsComponent = observer(function MyPlants() {
    const { plantStore, userStore } = useStore()
    const { plantDTOList, allAvailablePlantDTOListGrouped, loadAllPlants, allPlantTypes, loadAllPlantTypes } = plantStore
    const [activeIndex, setActiveIndex] = useState(0);

    const { isLoggedIn } = userStore;
    let indexNumber = 0;
    const [plantsToAdd, setPlantsToAdd] = useState<string[]>([]);
    //const numOfElements = allAvailablePlantDTOListGrouped.length / 2;
    useEffect(() => {

        if (isLoggedIn) {
            if (allAvailablePlantDTOListGrouped.length <= 0)
                loadAllPlants();
            if (allPlantTypes.size <= 0)
                loadAllPlantTypes();
        }
    }, [allAvailablePlantDTOListGrouped.length, allPlantTypes.size, isLoggedIn, loadAllPlantTypes, loadAllPlants]);
    function handleClick(indexNumber: number) {
        const newIndex = activeIndex === indexNumber ? -1 : indexNumber;
        setActiveIndex(newIndex);
    }

    function handleCheckBoxChange(id: string) {
        setPlantsToAdd([...plantsToAdd, id]);
    }
    if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )
    return (
        <>
            <Button icon='plus' onClick={() => store.modalStore.openModal(<NewPlantForm />)} content="Nova rostlina" />            
            <Button positive onClick={() => store.plantStore.savePlantsForUser(plantsToAdd)} content="Ulozit" />
            <Divider hidden horizontal/>
            <Grid columns={2}>
                <GridColumn>

                    <Header>
                        Moje rostliny
                    </Header>
                    {(plantDTOList.size > 0) ?
                        <List>
                            {Array.from(plantDTOList).map(plant => {
                                return (
                                    <ListItem key={'p_' + plant[0]}>

                                        <Image avatar src={`/src/assets/plants/${plant[1].imageSrc}`} />
                                        <ListContent>
                                            <ListHeader>
                                                    {plant[1].name}
                                            </ListHeader>
                                        </ListContent>
                                    </ListItem>
                                )
                            })
                            }
                        </List>

                        :
                        <label>Seznam rostlin je prazdny, pridej z vyberu, nebo vytvor nove</label>
                    }
                </GridColumn>
                <GridColumn>
                    <Accordion >
                        {
                            allAvailablePlantDTOListGrouped.map(group => {
                                indexNumber++;
                                const thisIndex = indexNumber;
                                return (
                                    <>
                                        <AccordionTitle
                                        active={activeIndex == indexNumber}
                                        index={thisIndex}
                                        onClick={() => handleClick(thisIndex)}
                                    >
                                        <Icon name='dropdown' />
                                        <Image avatar src={`/src/assets/plants/${group.plantType.imageSrc}`} />

                                        {group.plantType.name}({group.plants.length})
                                    </AccordionTitle>
                                        <AccordionContent active={activeIndex == indexNumber}>
                                            <Container>
                                                <List>
                                                    {group.plants.map(plant =>
                                                        <ListItem key={'t_' + plant.id}>
                                                            <Checkbox onChange={() => handleCheckBoxChange(plant.id)} />
                                                            <Image avatar src={`/src/assets/plants/${plant.imageSrc}`} />
                                                            <ListContent>
                                                                <ListHeader>
                                                                    {plant.name}
                                                                </ListHeader>
                                                            </ListContent>
                                                        </ListItem>
                                                    )}
                                                </List>
                                            </Container>
                                        </AccordionContent>

                                    </>
                                )
                            })
                                }
                    </Accordion>
                </GridColumn>
            </Grid>
        </>
    )
})
export default MyPlantsComponent;