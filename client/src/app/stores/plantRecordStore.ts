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

    getPlantRecord = (id: string) => {
        return this.plantRecordMap.get(id);
    }


    loadPlantRecords = async () => {
        store.globalStore.loading = true;
        try {
            const plantRecords = await agent.PlantRecords.getPlantRecords();
            
           // runInAction(() => {
                plantRecords.forEach(plantRecord => {
                    this.setPlantRecord(plantRecord);
                })
                store.globalStore.loading = false;
            //});

        }
        catch (error) {
            console.log(error);
        }

    }

    loadPlantRecord = async (id: string)=>{
        //try {
       //console.log("id atribute: " +id);
        let plantRecord = this.plantRecordMap.get(id);
        //console.log("record z mapy:" + plantRecord?.id);
        if (plantRecord) {
            //console.log("existuje")
            return plantRecord;
        }
            else {
                try {

                    plantRecord = await agent.PlantRecords.details(id);
                    this.setPlantRecord(plantRecord);
                    return plantRecord;
                }
                catch (error) {
                    console.log(error);
                }
            }

            /*console.log("plantRecordMap: ");
            console.log(this.plantRecordMap);

            console.log(this.plantRecordMap.has(String(id))); 

            console.log("plantRecord: " + plantRecord);


            const plantRecordFromArray = this.plantRecords.find((plantRecord) => plantRecord.id == id);
            console.log(this.plantRecords);
            console.log("plantrecordFromArray: " + plantRecordFromArray?.id);


            return this.plantRecordMap.get(id);
        }
        catch (error) {
            console.log(error);
        }*/
    }

    createPlantRecord = async (plantRecord: PlantRecordDTO) => {
        plantRecord.id = uiid();
        try {
            //const monthWeeks = await monthWeekAgent.MonthWeeks.sewingGroupByMonth();

            await agent.PlantRecords.create(plantRecord);
           // runInAction(() => {
                this.setPlantRecord(plantRecord);
            //});
            
        }
        catch (error) {
            console.log(error);
        }
    }

    updatePlantRecord = async (plantRecord: PlantRecordDTO) => {
        store.globalStore.loading = true;
        try {
            await agent.PlantRecords.update(plantRecord);

            runInAction(() => {
                this.plantRecordMap.set(plantRecord.id, plantRecord);
                store.globalStore.loading = false;
            })
        }
        catch (error) {
            console.log(error);
        }
    }

    deletePlantRecord = async (id: string) => {
        store.globalStore.loading = true;
        try {
            await agent.PlantRecords.delete(id);
            runInAction(() => {
                this.plantRecordMap.delete(id);
                store.globalStore.loading = false;
            });

        } catch (error) {
            console.log(error);
        }
    }

    private setPlantRecord = (plantRecord: PlantRecordDTO) => {

        plantRecord.datePlanted = plantRecord.datePlanted.split('T')[0];
        plantRecord.progress = this.calculatePlantRecordProgress(plantRecord, store.globalStore.getPlantDTO(plantRecord.plantId) as PlantDTO, store.monthWeekStore.monthWeekRelationList);

        this.plantRecordMap.set(plantRecord.id, plantRecord);        
    }


    calculatePlantRecordProgress = (plantRecord: PlantRecordDTO, plant: PlantDTO, monthWeekRelationList: Array<MonthWeekRelation>) => {
        const sewedMonthRelation = monthWeekRelationList.find(a => (a.sewedPlants.find(b => (b.id === plant.id))));
        const harvestedMonthRelation = monthWeekRelationList.find(a => (a.harvestedPlants.find(b => (b.id === plant.id))));


        const firstSewingtMonth = sewedMonthRelation?.monthWeekDTO.monthIndex;
        const firstHarvestedMonth = harvestedMonthRelation?.monthWeekDTO.monthIndex;

        const dateSewedMonth = new Date().setMonth(firstSewingtMonth - 1);
        const dateHarvestedMonth = new Date().setMonth(firstHarvestedMonth - 1);


        const vegetationPeriod = Math.abs(firstHarvestedMonth - firstSewingtMonth);
        const planted = new Date(plantRecord.datePlanted).getMonth();


        const now = new Date(Date.now()).getMonth();


        return Math.round((((now + 1) - (planted + 1)) / (vegetationPeriod))*100);

    }


    calculateProgress = () => {

        this.plantRecordMap.forEach((plantRecord) => {

            plantRecord.progress = this.calculatePlantRecordProgress(plantRecord, store.globalStore.getPlantDTO(plantRecord.plantId) as PlantDTO, store.monthWeekStore.monthWeekRelationList);
        })

    }

}