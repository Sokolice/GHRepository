import { PlantDTO } from "./PlantDTO";
import { PlantTypeDTO } from "./PlantTypeDTO";

export interface PlantTypePlantsRelation {
  plantType: PlantTypeDTO;
  plants: Array<PlantDTO>;
}
