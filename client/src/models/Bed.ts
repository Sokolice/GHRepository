import { Cell } from "./Cell";
export interface Bed {
    id: string,
    width: number,
    length: number,
    cells: Array<Cell>,
    numOfColumns: number,
    numOfRows: number,
    name: string,
    isDesign: boolean
}