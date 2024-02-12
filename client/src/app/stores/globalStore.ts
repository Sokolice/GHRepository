import { makeAutoObservable, runInAction } from "mobx";
import { GardeningTaskDTO } from "../../models/GardeningTaskDTO";
import { MonthWeekDTO } from "../../models/MonthWeekDTO";
import { PlantDTO } from "../../models/PlantDTO";
import agent from "../../api/agent";
import { PlantPlantsRelation } from "../../models/PlantPlantsRelation";
import { Stats } from "../../models/Stats";
export default class GlobalStore {

    monthweekDTOlist = new Map<string, MonthWeekDTO>();
    plantDTOList = new Map<string, PlantDTO>();
    gardeningTaskList = new Map<string, GardeningTaskDTO>();
    loading = false;
    selectedPlant: PlantDTO | undefined = undefined;
    otherPlants: PlantPlantsRelation = <PlantPlantsRelation>{
        plant: <PlantDTO>{}, avoidPlants: new Array<PlantDTO>(), companionPlants: new Array<PlantDTO>()
    };
    stats: Stats | undefined;    

    constructor() {
        makeAutoObservable(this)
    }

    loadStats = async () => {
        this.setLoading(true);
        try {
            this.stats = await agent.Stats.getStats();
            this.setLoading(false);
        }
        catch (error) {
            console.log(error);
        }
    }
        

    loadPlantDTO = async () => {
        this.setLoading(true);
        try {
            const plants = await agent.Plants.getPlants();
            plants.forEach(plant => {
                runInAction(()=>{
                    this.plantDTOList.set(plant.id, plant);
                })
            })

            this.setLoading(false);
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
            this.setLoading(true);
            try {
                plant = await agent.Plants.details(id);
                runInAction(() => {
                    this.selectedPlant = plant
                });
                this.setLoading(false);
                return plant;

            } catch (error) {
                console.log(error);
            }
        }
    }

    loadOtherPlants = async (id: string) => {

        this.setLoading(true);
        try {
            const plants = await agent.Plants.getOtherPlants(id);
            runInAction(() => {
                this.otherPlants = plants
            });
            this.setLoading(false);

        } catch (error) {
            console.log(error);
        }
    }

    setLoading = (state: boolean) => {
        runInAction(() => {
            this.loading = state;
        })
    }
    
} 