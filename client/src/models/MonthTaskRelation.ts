import { GardeningTaskDTO } from "./GardeningTaskDTO";
import { MonthWeekDTO } from "./MonthWeekDTO";

export interface MonthTaskRelation {
    monthWeekDTO: MonthWeekDTO,
    gardeningTasks: Array<GardeningTaskDTO>
}
