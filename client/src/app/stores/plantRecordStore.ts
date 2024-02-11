import { makeAutoObservable, runInAction } from "mobx";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import agent from "../../api/agent";
import { v4 as uiid } from 'uuid';
import { store } from "./store";
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
        runInAction(() => {
            store.globalStore.loading = true;
        })
        try {
            const plantRecords = await agent.PlantRecords.getPlantRecords();
            
            runInAction(() => {
                plantRecords.forEach(plantRecord => {
                    this.setPlantRecord(plantRecord);
                })
            runInAction(() => {
                store.globalStore.loading = false;
            })
            });

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
    }

    createPlantRecord = async (plantRecord: PlantRecordDTO) => {
        plantRecord.id = uiid();
        try {
            const response = await agent.PlantRecords.create(plantRecord);

            runInAction(() => {
                this.setPlantRecord(response.data);
            });
            
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
        let update = false;
        store.bedsStore.bedList.forEach(bed => {
            bed.cells.forEach(cell => {
                if (cell.plantRecordId == id) {
                    runInAction(() => {
                        cell.backgroundImage = "";
                        cell.gridArea = " ";
                        cell.isHidden = false;
                        cell.plantRecordId = "";
                        cell.objectID = "";
                        cell.isActive = false;
                    })
                    update = true;
                }

            })
            if (update) {
                store.bedsStore.updateBed(bed);
                update = false;
            }
        })

    }

    private setPlantRecord = (plantRecord: PlantRecordDTO) => {
        runInAction(() => {
            plantRecord.datePlanted = plantRecord.datePlanted.split('T')[0];
            this.plantRecordMap.set(plantRecord.id, plantRecord);        
        })
    }

}