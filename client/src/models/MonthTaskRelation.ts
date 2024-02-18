import { GardeningTaskDTO } from "./GardeningTaskDTO";

export interface MonthTaskRelation {
    month: string,
    index: number,
    weekTaskRelations: Array<WeekTaskRelation>
}

export interface WeekTaskRelation {
    week: number,
    gardeningTasks: Array<GardeningTaskDTO>
}
