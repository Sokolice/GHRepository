import { makeAutoObservable, runInAction } from "mobx";
import { GardeningTaskDTO } from "../../models/GardeningTaskDTO";
import { MonthWeekDTO } from "../../models/MonthWeekDTO";
import { PlantDTO } from "../../models/PlantDTO";
import agent from "../../api/agent";
export default class GlobalStore {

    monthweekDTOlist = new Map<string, MonthWeekDTO>();
    plantDTOList = new Map<string, PlantDTO>();
    gardeningTaskList = new Map<string, GardeningTaskDTO>();
    loading = false;
    selectedPlant: PlantDTO | undefined = undefined;

    bedList = new Map<string, Bed>();

    cellMap = new Array<Array<{ x: number, y: number }>>();
    clickedCells = new Array<string>();
    clickedGridId = "";

    constructor() {
        makeAutoObservable(this)
    }

    get beds() {
        return Array.from(this.bedList.values());
    }

    setBed(bed: Bed) {
        this.bedList.set(bed.id, bed);
    }

    loadPlantDTO = async () => {
        this.loading = true;
        try {
            const plants = await agent.Plants.getPlants();
            plants.forEach(plant => {
                runInAction(()=>{
                    this.plantDTOList.set(plant.id, plant);
                    this.loading = false;
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

    loadPlant = async (id: string) => {
        let plant = this.getPlantDTO(id);
        if (plant) {
            this.selectedPlant = plant;
            return plant;
        }

        else {
            this.loading = true;
            try {
                plant = await agent.Plants.details(id);
                runInAction(() => {
                    this.selectedPlant = plant
                });
                this.loading = false;
                return plant;

            } catch (error) {
                console.log(error);
                this.loading = false;
            }
        }
    }
} 