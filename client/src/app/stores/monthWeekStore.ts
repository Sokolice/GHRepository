import { makeAutoObservable, runInAction } from "mobx";
import monthWeekAgent from "../../api/agent";
import { MonthWeekRelation } from "../../models/MonthWeekRelation";
import { store } from "./store";
import { MonthSewedRelation } from "../../models/MonthSewedRelation";
import MyMapping from "../../models/MyMapping";

export default class MonthWeekStore {

    monthWeekList = new Array<MonthSewedRelation>();
    monthWeekRelationList = new Array<MonthWeekRelation>();
    currentMonthRelationList = new Array<MonthSewedRelation>();
    isCurrentMonthActive = false;
    hidePlanted = false;

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
                this.currentMonthRelationList = monthWeeks;
                store.globalStore.loading = false;
            });
        }
        catch (error) {
            console.log(error);
        }

    }

    filterMonthWeeks = () => {

        if (this.isCurrentMonthActive) {
            const today = new Date();
            const month = today.getMonth() + 1;

            const filteredMonthWeeks = this.currentMonthRelationList.filter((item) => MyMapping.mapMonthIndex(item.month) == month);



            this.currentMonthRelationList = filteredMonthWeeks;
        }
        else
            this.loadMonthWeeeks();
    }


    filterPlanted = () => {

        if (this.hidePlanted) {

            const plantedIds = store.plantRecordStore.plantRecords.map((item) => item.plantId);

            const newArr = new Array<MonthSewedRelation>();

            this.currentMonthRelationList.forEach(relation => {
                newArr.push({
                    month: relation.month,
                    sewedPlants: relation.sewedPlants.filter(plant => !plantedIds.includes(plant.id))
                })
            });

                this.currentMonthRelationList = newArr;
            }
        else
            this.loadMonthWeeeks();
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