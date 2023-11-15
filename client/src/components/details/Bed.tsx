import { observer } from "mobx-react-lite";
import { MouseEvent } from "react";
import { store } from "../../app/stores/store";

interface Props {
    rows: number, 
    columns: number,
    id: string
}


const BedComponent =  observer(function Bed({ rows, columns, id }: Props) {   
    const r = (rows / 20) * 100;
    const c = (columns / 20) * 100;
    function handleClick(event: MouseEvent<HTMLDivElement, MouseEvent>) {


        const thisCell = event.currentTarget;
        thisCell.classList.add('clicked');

        store.globalStore.clickedCells.push(thisCell.id);
        store.globalStore.clickedGridId = thisCell ? thisCell.parentElement.id : "";
       // alert(event.currentTarget.id);
    }

    function createGrid() {
        for (let y = 1; y <= c; y++) {
            const row = [];
            for (let x = 1; x <= r; x++) {
                row.push({ x: x, y: y })
            }
            store.globalStore.cellMap.push(row);
        }
    }

    function renderCell(cell: { x:  number; y: number; }) {
        return (
            <div className='grid-item' onClick={(e) => handleClick(e)}  key={cell.x + '_' + cell.y} id={cell.x + '_' + cell.y}>
            </div>
        )
    }

    function renderRow(row: { x: number; y: number; }[]) {
        const items = []
        items.push(
            row.map((cell: { x: number; y: number; }) => renderCell(cell)
            ));

        return items;
    }

    function generateStyle(): React.CSSProperties {
        let value = "";

        for (let x = 0; x < c; x++) {
            value = value + "auto ";
        }

        return { gridTemplateColumns: value }; 
    }

    createGrid();

    return (
        <div className='grid-container' id={`bed_${id}`} key={`bed_${id}`} style={generateStyle()}>
            {
                store.globalStore.cellMap.map((row) => renderRow(row))
            }
        </div>
    )
})

export default BedComponent;