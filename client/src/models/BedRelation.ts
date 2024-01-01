import { BedDTO } from "./BedDTO";
import { Cell } from "./Cell";

export interface BedRelation {
    bed: BedDTO,
    cells: Array<Cell>
}