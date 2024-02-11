import { makeAutoObservable, runInAction } from "mobx";
import { GardeningTaskDTO } from "../../models/GardeningTaskDTO";
import { MonthWeekDTO } from "../../models/MonthWeekDTO";
import { PlantDTO } from "../../models/PlantDTO";
import agent from "../../api/agent";
import { PlantPlantsRelation } from "../../models/PlantPlantsRelation";
import { store } from "./store";
import MyMapping from "../MyMapping";
import { MonthWeekRelation } from "../../models/MonthWeekRelation";
export default class GlobalStore {

    monthweekDTOlist = new Map<string, MonthWeekDTO>();
    plantDTOList = new Map<string, PlantDTO>();
    gardeningTaskList = new Map<string, GardeningTaskDTO>();
    loading = false;
    selectedPlant: PlantDTO | undefined = undefined;
    otherPlants: PlantPlantsRelation = <PlantPlantsRelation>{
        plant: <PlantDTO>{}, avoidPlants: new Array<PlantDTO>(), companionPlants: new Array<PlantDTO>()
    };
    canBeSowedThisWeekPlantsList = new Array<string>();
    missingSowingAmount = 0;
        
    constructor() {
        makeAutoObservable(this)
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

    loadOtherPlants = async (id: string) => {

        this.loading = true;
        try {
            const plants = await agent.Plants.getOtherPlants(id);
            runInAction(() => {
                this.otherPlants = plants
            });
            this.loading = false;

        } catch (error) {
            console.log(error);
            this.loading = false;
        }
    }

    calcMissingSowingAmount = async () => {
        
        runInAction(() => {
            this.loading = true;
        })

        /*if (this.plantDTOList.size == 0)
            await this.loadPlantDTO();
        if (store.plantRecordStore.plantRecordMap.size == 0)
            await store.plantRecordStore.loadPlantRecords();
        if (store.monthWeekStore.monthWeekRelationList.length == 0)
            await store.monthWeekStore.loadMonthWeeekRelations();*/
            
        if (this.plantDTOList.size > 0 && store.plantRecordStore.plantRecordMap.size > 0) {
            runInAction(() => {
                this.missingSowingAmount = 0;
            })

            const plantedIds = store.plantRecordStore.plantRecords.map((item) => item.plantId);
            const today = new Date();
            const month = today.getMonth() + 1;

            
          
            const date = today.getDate();

            const weekOfMonth = Math.ceil(date / 7);

            const canBeSowedThisWeekList = store.monthWeekStore.monthWeekRelationList.filter(item => item.monthWeekDTO.monthIndex == month && item.monthWeekDTO.week == weekOfMonth);

            canBeSowedThisWeekList.forEach(item => {
                item.sewedPlants.forEach(plant => {
                    console.log(plant.name);
                    if (!plantedIds.includes(plant.id)) {                       
                        runInAction(() => {
                            this.missingSowingAmount++;
                            this.canBeSowedThisWeekPlantsList.push(plant.id);
                        })
                    }
                }
                )
            })

            console.log(this.missingSowingAmount);
        }
        runInAction(() => {
            this.loading = false;
        })
    }
} 