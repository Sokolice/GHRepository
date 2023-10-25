import { makeAutoObservable, runInAction } from "mobx";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import agent from "../../api/agent";
import { v4 as uiid } from 'uuid';
export default class PlantRecordStore {

    plantRecordsList = new Array<PlantRecordDTO>();
    plantRecordMap = new Map<string, PlantRecordDTO>();

    constructor() {
        makeAutoObservable(this)
    }

    get plantRecords() {
        return Array.from(this.plantRecordMap.values()).sort((a, b) =>
            Date.parse(a.datePlanted) - Date.parse(b.datePlanted));
    }

    loadPlantRecords = async () => {
        try {
            const plantRecords = await agent.PlantRecords.getPlantRecords();
            plantRecords.forEach(plantRecord => {
                this.setPlantRecord(plantRecord);
            })
            runInAction(() => {
                this.plantRecordsList = plantRecords;
            });
        }
        catch (error) {
            console.log(error);
        }

    }

    createPlantRecord = async (plantrecord: PlantRecordDTO) => {
        plantrecord.id = uiid();
        try {
            //const monthWeeks = await monthWeekAgent.MonthWeeks.sewingGroupByMonth();

            await agent.PlantRecords.create(plantrecord);
            runInAction(() => {
                this.plantRecordMap.set(plantrecord.id, plantrecord);
                this.plantRecordsList.push(plantrecord);
                console.log("runincation");
            });
            
        }
        catch (error) {
            console.log(error);
        }
    }

    deletePlantRecord = async (id: string) => {
        try {
            await agent.PlantRecords.delete(id);
            runInAction(() => {
                this.plantRecordMap.delete(id);
                /*let index = this.plantRecordsList.find(a => (a.id === id)).
                this.plantRecordsList.re(id);*/
            });

        } catch (error) {
            console.log(error);
        }
    }

    setPlantRecord = (plantRecord: PlantRecordDTO) => {

        plantRecord.datePlanted = plantRecord.datePlanted.split('T')[0];
        this.plantRecordMap.set(plantRecord.id, plantRecord);
    }


    calculateProgress() {

    }

}