import { observer } from "mobx-react-lite";
import { MouseEvent, useState } from "react";
import { store } from "../../app/stores/store";
import { setReactionScheduler } from "mobx/dist/internal";
import { render } from "react-dom";

interface Props {
    Bed: Bed
}


const BedComponent = observer(function Bed({Bed}: Props) {   

    const [gridCells, setGridCells] = useState(Bed.cells);


    function handleClick(event: MouseEvent<HTMLDivElement, MouseEvent>) {


        const thisCell = event.currentTarget;
        const x = Number(thisCell.dataset.x);
        const y = Number(thisCell.dataset.y);

        Bed.cells.forEach(row => {
            row.forEach(cell => {
                if (cell.x == x && cell.y == y)

                    cell.isActive = cell.isActive ? false : true;
            });
        });

        setGridCells([...Bed.cells]);

        /*store.bedsStore.clickedCells.push(thisCell.id);
        store.bedsStore.clickedGridId = thisCell ? thisCell.parentElement.id : "";*/
       // alert(event.currentTarget.id)
    }


    function renderCell(cell: Cell) {
        return (
            <div className={'grid-item' + (cell.isActive ? " clicked" : "")} onClick={(e) => handleClick(e)}
                data-x={cell.x} data-y={cell.y} key={cell.x + '_' + cell.y}
                id={cell.x + '_' + cell.y}
            >
            </div>
        )
    }

    function renderRow(row: Cell[]) {
        const items = []
        items.push(
            row.map((cell: Cell) => renderCell(cell)
            ));

        return items;
    }

    function generateStyle(): React.CSSProperties {
        let value = "";

        for (let x = 0; x < Bed.numOfColumns; x++) {
            value = value + "50px ";
        }

        return { gridTemplateColumns: value }; 
    }

    return (
        <div className='grid-container bed' id={`bed_${Bed.id}`} key={`bed_${Bed.id}`} style={generateStyle()}>
            {
                gridCells.map((row) => renderRow(row))
            }
        </div>
    )
})

export default BedComponent;