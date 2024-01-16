import { makeAutoObservable, runInAction } from "mobx";
import { PestRelation } from "../../models/PestRelation";
import { store } from "./store";
import agent from "../../api/agent";

export default class PestsStore {
    pestsList = new Array<PestRelation>();
    currentPests = new Array<PestRelation>();

    constructor() {
        makeAutoObservable(this)
    }

    get getPests() {
        return this.pestsList;
    }

    loadPests = async () => {

        store.globalStore.loading = true;
        const pests = await agent.Pests.getPests();

        runInAction(() => {
            this.pestsList = pests;

            store.globalStore.loading = false;
        })
    }

    getCurrentPest = (plantId: string) => {

        this.currentPests = this.pestsList.filter(relation => relation.plants.find(p => p.id == plantId));
    }
}