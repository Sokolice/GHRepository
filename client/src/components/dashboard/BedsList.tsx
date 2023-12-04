import { ChangeEvent, SyntheticEvent, useState } from "react";
import { Button, Card, DropdownItemProps, Form, Grid, Segment } from "semantic-ui-react";
import Bed from "../details/Bed";
import { store, useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import { PlantDTO } from "../../models/PlantDTO";
import ReactDOM from "react-dom";
import { act } from "react-dom/test-utils";



const BedsComponent = observer(function BedsList() {

    const [dimension, setDimension] = useState({
        length: 0,
        width: 0
    })

    const [bedsCount, setCount] = useState(1);
    const [plantId, setPlantId] = useState('');
    const options: DropdownItemProps[] | { key: string; text: string; value: string; image: { avatar: boolean; src: string; }; }[] | undefined = [];

    store.globalStore.plantDTOList.forEach((plant: PlantDTO) => {

        options.push({
            key: plant.id,
            text: plant.name,
            value: plant.id,
            image: { avatar: false, src: `/src/assets/plants/${plant.imageSrc}` }
        })
    })

    function AddBed() {

        setCount(bedsCount + 1);
        store.bedsStore.createBed({ width: dimension.width, length: dimension.length, id: bedsCount.toString(), cells: new Array<Array<Cell>>(), numOfColumns: 0 });

    }


    function AddPlantImage() {

        const imagePath = 'url(/src/assets/plants/' + store.globalStore.getPlantDTO(plantId)?.imageSrc + ")";
        const activeCells = new Array<Cell>();

        store.bedsStore.beds[0].cells.forEach((row) =>
            row.forEach((cell) => {
                if (cell.isActive) {
                    activeCells.push(cell);
                }
            }));

        const minColumn = Math.min(...activeCells.map((a) => a.x));
        const maxColumn = Math.max(...activeCells.map((a) => a.x));
        const minRow = Math.min(...activeCells.map((a) => a.y));
        const maxRow = Math.max(...activeCells.map((a) => a.y));

        const toBeDeleted = new Array<Cell>();

        console.log(minColumn);
        console.log(maxColumn);
        console.log(minRow);
        console.log(maxRow);

        console.log("active" + activeCells);

        activeCells.forEach(cell => {
            if (cell.x != minColumn || cell.y != minRow)
                toBeDeleted.push(cell);
        });

        console.log("delete: ");
        console.log(toBeDeleted);
        //const newCells = new Array<Array<Cell>>();

        store.bedsStore.beds[0].cells.forEach((row) =>
            row.forEach((cell) => {

                if (cell.x == minColumn && cell.y == minRow) {
                    cell.cssClass = "grid-column: " + minColumn + '/' + maxColumn + ";";
                    cell.cssClass = cell.cssClass +" grid-row: " + minRow + '/' + maxRow;
                    cell.backgroundImage = imagePath;
                }

                if (toBeDeleted.find(a => a === cell)) {
                    const index = row.indexOf(cell, 0);
                    row.splice(index, 1);
                }
            }));
        console.log(store.bedsStore.beds[0].cells);




        /*let lowestColumn: number = 0;
        let lowestRow: number = 0;


        let highestColumn: number = 0;
        let highestRow: number = 0;

        store.bedsStore.clickedCells.forEach((cell: string) => {
            console.log(cell);

            const thisColumn = Number(cell.substring(0,1));
            if (lowestColumn == 0 || thisColumn < lowestColumn)
                lowestColumn = thisColumn;
            console.log("lowestC " + lowestColumn);

            if (highestColumn == 0 || thisColumn > highestColumn)
                highestColumn = thisColumn;
            console.log("highestC " + highestColumn);


            const thisRow = Number(cell.substring(2));
            if (lowestRow == 0 || thisRow < lowestRow)
                lowestRow = thisRow;
            console.log("lowestR " + lowestRow);
            if (highestRow == 0 || thisColumn > highestRow)
                highestRow = thisRow;
            console.log("highestR " + highestRow);

        })
        highestColumn = highestColumn + 1;
        highestRow = highestRow + 1;
        document.getElementById(lowestColumn + "_" + lowestRow)?.style.setProperty('grid-column', lowestColumn + '/' + highestColumn);
        document.getElementById(lowestColumn + "_" + lowestRow)?.style.setProperty('grid-row', lowestRow + '/' + highestRow);

        const path = 'url(/src/assets/plants/' + store.globalStore.getPlantDTO(plantId)?.imageSrc + ")";

        document.getElementById(lowestColumn + "_" + lowestRow)?.style.setProperty('background-image', path);
        document.getElementById(lowestColumn + "_" + lowestRow)?.style.setProperty('background-size', 'cover');*/

    }

    function handleChange(event: ChangeEvent<HTMLInputElement>) {
        const { name, value } = event.target;
        setDimension({ ...dimension, [name]: value })
    }

    function handleDropChange(event: SyntheticEvent<HTMLElement, Event>, value) {
        setPlantId(value.value);
        console.log(value.value);
    }

    return (
        <div >
            <Segment.Group horizontal>
                <Segment>
                    <Form onSubmit={AddBed}>
                        <Form.Group>
                            <Form.Field>
                                <Form.Input label='Delka[m]' placeholder='Delka' id='length' name='length' onChange={handleChange} />
                            </Form.Field>
                            <Form.Field>
                                <Form.Input label='Sirka[m]' placeholder='Sirka' id='width' name='width' onChange={handleChange} />
                            </Form.Field>
                        </Form.Group>
                        <Form.Button type='submit'>
                            Pridat zahon
                        </Form.Button>
                    </Form>
                </Segment>    
                <Segment>
                    <Form onSubmit={AddPlantImage}>
                        <Form.Field>
                            <Form.Dropdown options={options} onChange={handleDropChange} />
                            </Form.Field>
                        <Form.Button type='submit'>
                            Vlozit rostlinu
                        </Form.Button>
                    </Form>
                </Segment>
            </Segment.Group>
            <br />
            <br />
            <div id="beds">
                {store.bedsStore.beds.map((bed: Bed) => (
                    <Bed Bed={bed} key={bed.id}/>
                )) }
            </div>
        </div>
    )
})

export default BedsComponent;