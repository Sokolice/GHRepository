import { GardeningTaskDTO } from "./GardeningTaskDTO";
import { MonthWeekDTO } from "./MonthWeekDTO";
import { PlantDTO } from "./PlantDTO";

export interface MonthWeekRelation {
  monthWeekDTO: MonthWeekDTO;
  sewedPlants: Array<PlantDTO>;
  harvestedPlants: Array<PlantDTO>;
  gardeningTasks: Array<GardeningTaskDTO>;
}
