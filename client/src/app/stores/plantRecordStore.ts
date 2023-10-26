import { makeAutoObservable, runInAction } from "mobx";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import agent from "../../api/agent";
import { v4 as uiid } from 'uuid';
import { PlantDTO } from "../../models/PlantDTO";
import { store } from "./store";
import { MonthWeekRelation } from "../../models/MonthWeekRelation";
export default class PlantRecordStore {

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
            
            runInAction(() => {
                plantRecords.forEach(plantRecord => {
                    this.setPlantRecord(plantRecord);
                })
            });

        }
        catch (error) {
            console.log(error);
        }

    }

    createPlantRecord = async (plantRecord: PlantRecordDTO) => {
        plantRecord.id = uiid();
        try {
            //const monthWeeks = await monthWeekAgent.MonthWeeks.sewingGroupByMonth();

            await agent.PlantRecords.create(plantRecord);
            runInAction(() => {
                this.setPlantRecord(plantRecord);
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
            });

        } catch (error) {
            console.log(error);
        }
    }

    setPlantRecord = (plantRecord: PlantRecordDTO) => {

        plantRecord.datePlanted = plantRecord.datePlanted.split('T')[0];
        plantRecord.progress = this.calculatePlantRecordProgress(plantRecord, store.globalStore.getPlantDTO(plantRecord.plantId) as PlantDTO, store.monthWeekStore.monthWeekRelationList);

        this.plantRecordMap.set(plantRecord.id, plantRecord);
        
    }


    calculatePlantRecordProgress = (plantRecord: PlantRecordDTO, plant: PlantDTO, monthWeekRelationList: Array<MonthWeekRelation>) => {
        const sewedMonthRelation = monthWeekRelationList.find(a => (a.sewedPlants.find(b => (b.id === plant.id))));
        const harvestedMonthRelation = monthWeekRelationList.find(a => (a.harvestedPlants.find(b => (b.id === plant.id))));


        const firstSewingtMonth = sewedMonthRelation?.monthWeekDTO.monthIndex;
        const firstHarvestedMonth = harvestedMonthRelation?.monthWeekDTO.monthIndex;

        const vegetationPeriod = firstHarvestedMonth - firstSewingtMonth;

        const now = new Date(Date.now());
        const planted = new Date(plantRecord.datePlanted);
        console.log(planted);
        const PlantedMonth = planted.getMonth() + 1;
        console.log("vyseto v mesici " +PlantedMonth + " - roste mesicu " + vegetationPeriod);
        const finalMonth = PlantedMonth + vegetationPeriod;
        console.log(finalMonth);

        return Math.round(((now.getMonth() + 1) * 100) / finalMonth);

    }


    calculateProgress = () => {

        this.plantRecordMap.forEach((plantRecord) => {

            plantRecord.progress = this.calculatePlantRecordProgress(plantRecord, store.globalStore.getPlantDTO(plantRecord.plantId) as PlantDTO, store.monthWeekStore.monthWeekRelationList);
        })

    }

}