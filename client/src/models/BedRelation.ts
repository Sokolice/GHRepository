import { BedDTO } from "./BedDTO";
import { Cell } from "./Cell";
import { PlantDTO } from "./PlantDTO";

export interface BedRelation {
    bed: BedDTO,
    cells: Array<Cell>,
    plants: Array<PlantDTO>
}