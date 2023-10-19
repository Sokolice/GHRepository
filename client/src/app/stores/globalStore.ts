import { makeAutoObservable, runInAction } from "mobx";
import { GardeningTaskDTO } from "../../models/GardeningTaskDTO";
import { MonthWeekDTO } from "../../models/MonthWeekDTO";
import { PlantDTO } from "../../models/PlantDTO";
import agent from "../../api/agent";

export default class GlobalStore {

    monthweekDTOlist = new Map<string, MonthWeekDTO>();
    plantDTOList = new Map<string, PlantDTO>();
    gardeningTaskList = new Map<string, GardeningTaskDTO>();

    constructor() {
        makeAutoObservable(this)
    }

    loadPlantDTO = async () => {

        try {
            const plants = await agent.Plants.getPlants();
            plants.forEach(plant => {
                runInAction(()=>{
                    this.plantDTOList.set(plant.id, plant);
                })
            })
        }
        catch (error) {
            console.log(error);
        }

    }

    getPlantDTO = (id: string) => {
        return this.plantDTOList.get(id);
    }
} 