import { PlantDTO } from "./PlantDTO";

export interface MonthSewedRelation {
    month: string,
    sewedPlants: Array<PlantDTO>
}