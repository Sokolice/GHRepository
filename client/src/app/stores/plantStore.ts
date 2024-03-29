import { makeAutoObservable, runInAction } from "mobx";
import { store } from "./store";
import { PlantPlantsRelation } from "../../models/PlantPlantsRelation";
import agent from "../../api/agent";
import { PlantDTO } from "../../models/PlantDTO";

export default class PlantStore {
    allPlantsRelations = new Array<PlantPlantsRelation>();

    selectedPlant: PlantDTO | undefined = undefined;
    plantDTOList = new Map<string, PlantDTO>();
    otherPlants: PlantPlantsRelation = <PlantPlantsRelation>{
        plant: <PlantDTO>{}, avoidPlants: new Array<PlantDTO>(), companionPlants: new Array<PlantDTO>()
    };
    constructor() {
        makeAutoObservable(this)
    }

    loadAllPlantsRelations = async () => {

        store.globalStore.setLoading(true);

        try {
            const relations = await agent.Plants.getAllPlantsRelations();
            //console.log(relations);
            runInAction(() => {
                this.allPlantsRelations = relations;
            })
            
            store.globalStore.setLoading(false);
        } catch (exception) {
            console.log(exception);
        }
    }

    getPlantRelation = (id: string) => {
        const relation = this.allPlantsRelations.find(a => a.plant.id == id);

        return relation;
    }

    getPlantDTO = (id: string) => {
        return this.plantDTOList.get(id);
    }

    loadPlant = async (id: string) => {

        store.globalStore.setLoading(true);
        let plant = this.getPlantDTO(id);
        if (plant) {
            this.selectedPlant = plant;
            store.globalStore.setLoading(false);
            return plant;
        }

        else {
            store.globalStore.setLoading(true);
            try {
                plant = await agent.Plants.details(id);
                runInAction(() => {
                    this.selectedPlant = plant
                });
                store.globalStore.setLoading(false);
                return plant;

            } catch (error) {
                console.log(error);
            }
        }
    }
    loadPlantDTO = async () => {
        store.globalStore.setLoading(true);
        try {
            const plants = await agent.Plants.getPlants();
            plants.forEach(plant => {
                runInAction(() => {
                    this.plantDTOList.set(plant.id, plant);
                })
            })

            store.globalStore.setLoading(false);
        }
        catch (error) {
            console.log(error);
        }

    }

    loadOtherPlants = async (id: string) => {

        store.globalStore.setLoading(true);
        try {
            const plants = await agent.Plants.getOtherPlants(id);
            runInAction(() => {
                this.otherPlants = plants;
            });
            store.globalStore.setLoading(false);

        } catch (error) {
            console.log(error);
        }
    }
}