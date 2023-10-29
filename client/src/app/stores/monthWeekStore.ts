import { makeAutoObservable, runInAction } from "mobx";
import { MonthSewedRelation } from "../models/MonthSewedRelation";
import monthWeekAgent from "../../api/agent";
import { MonthWeekRelation } from "../../models/MonthWeekRelation";
import { store } from "./store";

export default class MonthWeekStore {

    monthWeekList = new Array<MonthSewedRelation>();
    monthWeekRelationList = new Array<MonthWeekRelation>();

    constructor() {
        makeAutoObservable(this)
    }

    get monthWeeks() {
        return this.monthWeekList;
    }

    loadMonthWeeeks = async () => {

        store.globalStore.loading = true;
        try {
            const monthWeeks = await monthWeekAgent.MonthWeeks.sewingGroupByMonth();
            
            runInAction(() => {
                this.monthWeekList = monthWeeks;
                store.globalStore.loading = false;
            });
        }
        catch (error) {
            console.log(error);
        }

    }

    loadMonthWeeekRelations = async () => {
        store.globalStore.loading = true;
        try {
            const monthWeekRelations = await monthWeekAgent.MonthWeeks.monthWeeksRelations();
            runInAction(() => {
                this.monthWeekRelationList = monthWeekRelations;
                store.globalStore.loading = false;
            });

        }
        catch (error) {
            console.log(error);
        }

    }




}