import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import { store } from "./store";
import { v4 as uiid } from "uuid";
import { BedRelation } from "../../models/BedRelation";
import { Cell } from "../../models/Cell";
import { BedDTO } from "../../models/BedDTO";
import { PlantDTO } from "../../models/PlantDTO";

export default class BedsStore {
  bedList = new Map<string, BedRelation>();
  selectedBed: BedRelation = {
    bed: <BedDTO>{},
    cells: [],
    plants: [],
    avoidPlantsIds: [],
    companionPlantsIds: [],
  };
  constructor() {
    makeAutoObservable(this);
  }
  get beds() {
    return Array.from(this.bedList.values());
  }

  loadBeds = async () => {
    try {
      store.globalStore.setLoading(true);
      const bedRelations = await agent.Beds.getBeds();
      runInAction(() => {
        bedRelations.forEach((bedRelation) => {
          this.bedList.set(bedRelation.bed.id, bedRelation);
        });
        store.globalStore.setLoading(false);
      });
    } catch (error) {
      console.log(error);
    }
  };

  loadBed = async (id: string) => {
    const bed = this.bedList.get(id);
    if (bed) {
      this.selectedBed = bed;
    } else {
      store.globalStore.setLoading(true);
      try {
        const bedRelation = await agent.Beds.details(id);

        const ids = new Map<string, PlantDTO>();
        bedRelation.cells.forEach((cell) => {
          if (cell.plantRecordId != "") {
            const plant: PlantDTO | undefined = store.plantStore.getPlantDTO(
              bedRelation.bed.isDesign
                ? cell.plantRecordId
                : (store.plantRecordStore.getPlantRecord(cell.plantRecordId)
                    ?.plantId ?? ""),
            );
            if (plant) ids.set(plant.id, plant);
          }
        });
        runInAction(() => {
          this.selectedBed = bedRelation;
        });

        store.globalStore.setLoading(false);
      } catch (error) {
        console.log(error);
      }
    }
  };

  updateBed = async (bedRelation: BedRelation) => {
    try {
      store.globalStore.setLoading(true);
      const responseRelation = await agent.Beds.update(bedRelation);
      runInAction(() => {
        this.bedList.set(responseRelation.bed.id, responseRelation);
        this.selectedBed = responseRelation;
      });

      store.globalStore.setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  deleteCells = async (ids: Array<string>) => {
    try {
      store.globalStore.setLoading(true);
      await agent.Cells.deleteCells(ids);
      store.globalStore.setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  createBed = async (
    width: number,
    length: number,
    name: string,
    isDesign: boolean,
    cropRotation: number,
    note: string,
  ) => {
    const r = (width / 10) * 100;
    const c = (length / 10) * 100;

    const cells = new Array<Cell>();

    for (let x = 1; x <= c; x++) {
      for (let y = 1; y <= r; y++) {
        cells.push({
          id: uiid(),
          x: x,
          y: y,
          isActive: false,
          gridArea: "",
          backgroundImage: "",
          plantRecordId: "00000000-0000-0000-0000-000000000000",
          isHidden: false,
          objectID: "",
        });
      }
    }

    store.globalStore.setLoading(true);

    try {
      const newBed = <BedRelation>{
        bed: <BedDTO>{
          id: uiid(),
          name: name,
          length: length,
          numOfColumns: c,
          width: width,
          numOfRows: r,
          isDesign: isDesign,
          cropRotation: cropRotation,
          note: note,
        },
        cells: cells,
        plants: new Array<PlantDTO>(),
        avoidPlantsIds: new Array<string>(),
        companionPlantsIds: new Array<string>(),
      };
      await agent.Beds.create(newBed);
      runInAction(() => {
        this.bedList.set(newBed.bed.id, newBed);
      });

      store.globalStore.setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  deleteBed = async (id: string) => {
    store.globalStore.loading = true;
    try {
      await agent.Beds.delete(id);
      runInAction(() => {
        this.bedList.delete(id);
        store.globalStore.loading = false;
        store.modalStore.closeModal();
      });
    } catch (error) {
      console.log(error);
    }
  };
}
