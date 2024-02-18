import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import { MonthWeekRelation } from "../../models/MonthWeekRelation";
import { store } from "./store";
import { MonthSewedRelation } from "../../models/MonthSewedRelation";
import { MonthTaskRelation, WeekTaskRelation } from "../../models/MonthTaskRelation";
import MyMapping from "../MyMapping";
import { GardeningTaskDTO } from "../../models/GardeningTaskDTO";

export default class MonthWeekStore {

    monthWeekList = new Array<MonthSewedRelation>();
    monthWeekRelationList = new Array<MonthWeekRelation>();
    //grouped list used for filtering in sewing plan
    currentMonthRelationList = new Array<MonthSewedRelation>();
    isCurrentMonthActive = false;
    hidePlanted = false;
    monthTaskRelations = new Array<MonthTaskRelation>();


    constructor() {
        makeAutoObservable(this)
    }

    loadMonthWeeeks = async () => {

        store.globalStore.setLoading(true);
        try {            
            const monthWeeks = await agent.MonthWeeks.sewingGroupByMonth();
            
            runInAction(() => {
                this.currentMonthRelationList = monthWeeks;
            });

            store.globalStore.setLoading(false);
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
            this.monthWeekList = this.currentMonthRelationList;
            this.currentMonthRelationList = filteredMonthWeeks;
        }
        else
            this.currentMonthRelationList = this.monthWeekList;
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

                this.monthWeekList = this.currentMonthRelationList;
                this.currentMonthRelationList = newArr;
            }
        else
            this.currentMonthRelationList = this.monthWeekList;
    }

    //using for calculationg progress 
    loadMonthWeeekRelations = async () => {
        store.globalStore.setLoading(true);
        try {
            const monthWeekRelations = await agent.MonthWeeks.monthWeeksRelations();
            runInAction(() => {
                this.monthWeekRelationList = monthWeekRelations;
            });

            store.globalStore.setLoading(false);
        }
        catch (error) {
            console.log(error);
        }

    }

    loadMonthTasksRelation = async () => {
        store.globalStore.setLoading(true);
        try {
            const relations = await agent.Tasks.getTasks();
            runInAction(() => {
                this.monthTaskRelations = relations;
            });
            console.log(relations);
            store.globalStore.setLoading(false);
        }
        catch (error) {
            console.log(error);
        }
    }

    setMonthTaskRelation = async (task: GardeningTaskDTO) => {
        await agent.Tasks.setTask(task);
    }

    shareWeekTasks = async (tasks: WeekTaskRelation) => {
        await agent.Tasks.shareTasks(tasks);
    }

}