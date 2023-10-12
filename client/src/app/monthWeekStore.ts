import { makeAutoObservable, runInAction } from "mobx";
import monthWeekAgent from "../api/monthWeekAgent";
import { MonthWeekRelation } from "../models/MonthWeekRelation";
import { MonthWeekDTO } from "../models/MonthWeekDTO";
import { PlantDTO } from "../models/PlantDTO";
import { MonthSewedRelation } from "../models/MonthSewedRelation";

export default class MonthWeekStore {

    monthWeekList = new Array<MonthSewedRelation>();
    //prepsat naplneni hodnot a tvorbu komponent
    //groupedMonthWeeksList = new Map<string, PlantDTO[]>(); 


    constructor() {
        makeAutoObservable(this)
    }

    get monthWeeks() {
        return this.monthWeekList;
    }

    /*get groupedMonthWeeks() {
        return Object.entries(
            Array.from(this.groupedMonthWeeksList.values())
        )        
    }*/

    /*groupSewedPlantsByMonth = async () => {

        if (this.monthWeekList.length <= 1)
            await this.loadMonthWeeeks();

        this.monthWeekList.forEach(m => {
            m.sewedPlants.forEach(p => {
                if (!this.groupedMonthWeeksList.has(m.monthWeekDTO.month))
                    runInAction(() => {
                        this.groupedMonthWeeksList.set(m.monthWeekDTO.month, m.sewedPlants);
                    })
                else 
                    runInAction(() => {
                        this.groupedMonthWeeksList.set(m.monthWeekDTO.month, [p])
                    })



                console.log(this.groupedMonthWeeksList.keys());
                console.log(this.groupedMonthWeeksList.values());
            })
        })
    }*/

    loadMonthWeeeks = async () => {
        try {
            const monthWeeks = await monthWeekAgent.MonthWeeks.sewingGroupByMonth();
            //console.log(monthWeeks);
            /*monthWeeks.map((monthRelation: MonthWeekRelation) => {
                console.log(monthRelation.monthWeekDTO);
                //console.log(monthRelation.monthweekDTO);
            })*/

            runInAction(() => {
                this.monthWeekList = monthWeeks;    
            });
            /*monthWeeks.forEach(monthWeek => {
                this.setMonthWeek(monthWeek);
            } )*/

            /*monthWeeks.forEach(MonthWeekRelation => {
                //this.setActivity(activity);
            })*/
        }
        catch (error) {
            console.log(error);
        }

    }




}