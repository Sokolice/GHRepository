import { makeAutoObservable, runInAction } from "mobx";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import agent from "../../api/agent";
export default class PlantRecordStore {

    plantRecordsList = new Array<PlantRecordDTO>();

    constructor() {
        makeAutoObservable(this)
    }

    get plantRecords() {
        return this.plantRecordsList;
    }

    loadPlantRecords = async () => {
        try {
            const plantRecords = await agent.PlantRecords.getPlantRecords();


            runInAction(() => {
                this.plantRecordsList = plantRecords;
            });
        }
        catch (error) {
            console.log(error);
        }

    }

    createPlantRecord = async (plantrecord: PlantRecordDTO) => {
        try {
            //const monthWeeks = await monthWeekAgent.MonthWeeks.sewingGroupByMonth();

            await agent.PlantRecords.create(plantrecord);
            runInAction(() => {
                this.plantRecordsList.push(plantrecord);
                console.log("runincation");
            });
            
        }
        catch (error) {
            console.log(error);
        }
    }




}