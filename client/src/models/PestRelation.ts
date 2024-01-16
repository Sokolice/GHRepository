import { PestDTO } from "./PestDTO";
import { PlantDTO } from "./PlantDTO";

export interface PestRelation {
    pestDTO: PestDTO,
    plants: Array<PlantDTO>
}