import { makeAutoObservable, runInAction } from "mobx";
import { PlantRecordDTO } from "../../models/PlantRecordDTO";
import agent from "../../api/agent";
import { v4 as uiid } from "uuid";
import { store } from "./store";
import plantStore from "./plantStore";
export default class PlantRecordStore {
  plantRecordMap = new Map<string, PlantRecordDTO>();
  constructor() {
    makeAutoObservable(this);
  }

  get plantRecords() {
    return Array.from(this.plantRecordMap.values()).sort(
      (a, b) => a.datePlanted!.getTime() - b.datePlanted!.getTime(),
    );
  }

  getPlantRecord = (id: string) => {
    return this.plantRecordMap.get(id);
  };

  loadPlantRecords = async () => {
    store.globalStore.setLoading(true);
    try {
      const plantRecords = await agent.PlantRecords.getPlantRecords();

      runInAction(() => {
        plantRecords.forEach((plantRecord) => {
          this.setPlantRecord(plantRecord);
        });
      });

      store.globalStore.setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  loadPlantRecord = async (id: string) => {
    let plantRecord = this.plantRecordMap.get(id);
    if (plantRecord) {
      return plantRecord;
    } else {
      store.globalStore.setLoading(true);
      try {
        plantRecord = await agent.PlantRecords.details(id);
        this.setPlantRecord(plantRecord);
        store.globalStore.setLoading(false);
        return plantRecord;
      } catch (error) {
        console.log(error);
      }
    }
  };

  createPlantRecord = async (plantRecord: PlantRecordDTO) => {
    plantRecord.id = uiid();
    try {
      const response = await agent.PlantRecords.create(plantRecord);

      runInAction(() => {
        this.setPlantRecord(response.data);
      });
    } catch (error) {
      console.log(error);
    }
    store.globalStore.loadStats();
    store.modalStore.closeModal();
  };

  updatePlantRecord = async (plantRecord: PlantRecordDTO) => {
    try {
      await agent.PlantRecords.update(plantRecord);

      runInAction(() => {
        this.plantRecordMap.set(plantRecord.id, plantRecord);
      });
      store.modalStore.closeModal();
    } catch (error) {
      console.log(error);
    }
  };

  deletePlantRecord = async (id: string) => {
    store.globalStore.setLoading(true);
    try {
      await agent.PlantRecords.delete(id);
      runInAction(() => {
        this.plantRecordMap.delete(id);
      });
      store.modalStore.closeModal();
    } catch (error) {
      console.log(error);
    }
    let update = false;
    store.bedsStore.bedList.forEach((bed) => {
      bed.cells.forEach((cell) => {
        if (cell.plantRecordId == id) {
          runInAction(() => {
            cell.backgroundImage = "";
            cell.gridArea = " ";
            cell.isHidden = false;
            cell.plantRecordId = "";
            cell.objectID = "";
            cell.isActive = false;
          });
          update = true;
        }
      });
      if (update) {
        store.bedsStore.updateBed(bed);
        update = false;
      }
    });
    store.globalStore.loadStats();
    store.globalStore.setLoading(false);
  };

  private setPlantRecord = (plantRecord: PlantRecordDTO) => {
    runInAction(() => {
      plantRecord.datePlanted = new Date(plantRecord.datePlanted!);
      this.plantRecordMap.set(plantRecord.id, plantRecord);
    });
  };

  searchPlantRecords =(searchedString: string)=>{
    const filteredPlantRecords= this.plantRecords.filter(record => {
      const plant =store.plantStore.getPlantDTO(record.plantId);
    if(plant?.name.toLowerCase().includes(searchedString)){
      console.log(plant.name);
      return record;
    };   
  })
    return filteredPlantRecords;
  }
}
