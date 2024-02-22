import { makeAutoObservable, runInAction } from "mobx";
import { store } from "./store";
import { PlantPlantsRelation } from "../../models/PlantPlantsRelation";
import agent from "../../api/agent";

export default class PlantStore {
    allPlantsRelations = new Array<PlantPlantsRelation>();

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

}