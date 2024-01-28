import { PlantDTO } from "./PlantDTO";

export interface PlantPlantsRelation{
    plant: PlantDTO,
    companionPlants: Array<PlantDTO>,
    avoidPlants: Array<PlantDTO>
}