import { makeAutoObservable, runInAction } from "mobx";
import { MonthSewedRelation } from "../models/MonthSewedRelation";
import monthWeekAgent from "../../api/agent";
import { MonthWeekRelation } from "../../models/MonthWeekRelation";

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
        try {
            const monthWeeks = await monthWeekAgent.MonthWeeks.sewingGroupByMonth();
            

            runInAction(() => {
                this.monthWeekList = monthWeeks;    
            });
        }
        catch (error) {
            console.log(error);
        }

    }

    loadMonthWeeekRelations = async () => {
        try {
            const monthWeekRelations = await monthWeekAgent.MonthWeeks.monthWeeksRelations();


            runInAction(() => {
                this.monthWeekRelationList = monthWeekRelations;
            });
        }
        catch (error) {
            console.log(error);
        }

    }




}