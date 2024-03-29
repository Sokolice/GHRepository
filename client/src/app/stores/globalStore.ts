import { makeAutoObservable, reaction, runInAction } from "mobx";
import { GardeningTaskDTO } from "../../models/GardeningTaskDTO";
import { MonthWeekDTO } from "../../models/MonthWeekDTO";
import agent from "../../api/agent";
import { Stats } from "../../models/Stats";
import { HarvestDTO } from "../../models/HarvestDTO";
import { v4 as uiid } from 'uuid';
import { store } from "./store";
export default class GlobalStore {

    monthweekDTOlist = new Map<string, MonthWeekDTO>();
    gardeningTaskList = new Map<string, GardeningTaskDTO>();
    loading = false;
    stats: Stats | undefined;
    token: string | null = localStorage.getItem('jwt');
    appLoaded = false;
    constructor() {
        makeAutoObservable(this);
        reaction(
            () => this.token, 
            token => {
                if (token) {
                    localStorage.setItem('jwt', token)
                }
                else {
                    localStorage.removeItem('jwt')
                }
            }
        )
    }

    setToken = (token: string) => {
        this.token = token;
    }

    setAppLoaded = () => {
        this.appLoaded = true;
    }

    loadStats = async () => {
        this.setLoading(true);
        try {
            const allStats = await agent.Stats.getStats();
            runInAction(() => {
                this.stats = allStats;
            });
            this.setLoading(false);
        }
        catch (error) {
            console.log(error);
        }
    }
        
    setLoading = (state: boolean) => {
        runInAction(() => {
            this.loading = state;
        })
    }


    saveHarvest = async (harvest: HarvestDTO) => {
        this.setLoading(true);

        try {
            harvest.id = uiid();
            await agent.Plants.harvest(harvest);
            this.setLoading(false);
        }
        catch (error) {
            console.log(error);
        }
        store.modalStore.closeModal();
    }
    
} 