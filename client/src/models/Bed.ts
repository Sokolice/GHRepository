import { Cell } from "./Cell";
import { PlantDTO } from "./PlantDTO";
export interface Bed {
    id: string,
    width: number,
    length: number,
    cells: Array<Cell>,
    numOfColumns: number,
    numOfRows: number,
    name: string,
    isDesign: boolean,
    cropRotation: number,
    plants: Map<string, PlantDTO>
}