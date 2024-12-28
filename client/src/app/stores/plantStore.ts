import { makeAutoObservable, runInAction } from "mobx";
import { store } from "./store";
import { PlantPlantsRelation } from "../../models/PlantPlantsRelation";
import agent from "../../api/agent";
import { PlantDTO } from "../../models/PlantDTO";
import { PlantTypePlantsRelation } from "../../models/PlantTypePlantsRelation";
import { PlantTypeDTO } from "../../models/PlantTypeDTO";
import { MonthWeekDTO } from "../../models/MonthWeekDTO";
import { v4 as uiid } from "uuid";

export default class PlantStore {
  allPlantsRelations = new Array<PlantPlantsRelation>();

  selectedPlant: PlantDTO | undefined = undefined;
  plantDTOList = new Map<string, PlantDTO>();
  allAvailablePlantDTOListGrouped = new Array<PlantTypePlantsRelation>();
  otherPlants: PlantPlantsRelation = <PlantPlantsRelation>{
    plant: <PlantDTO>{},
    avoidPlants: new Array<PlantDTO>(),
    companionPlants: new Array<PlantDTO>(),
  };
  //allPLantTypes = new Array<PlantTypeDTO>();

  allPLantTypesOptions = Array<{
    key: string;
    text: string;
    value: string;
  }>();

  allPlantTypes = new Map<string, PlantTypeDTO>();

  newPlantSowingFrom: MonthWeekDTO = { month: "", monthIndex: 0, week: 0 };
  newPlantSowingTo: MonthWeekDTO = { month: "", monthIndex: 0, week: 0 };
  newPlantHarvestFrom: MonthWeekDTO = { month: "", monthIndex: 0, week: 0 };
  newPlantHarvestTo: MonthWeekDTO = { month: "", monthIndex: 0, week: 0 };

  constructor() {
    makeAutoObservable(this);
  }

  loadAllPlantsRelations = async () => {
    store.globalStore.setLoading(true);

    try {
      const relations = await agent.Plants.getAllPlantsRelations();
      //console.log(relations);
      runInAction(() => {
        this.allPlantsRelations = relations;
      });

      store.globalStore.setLoading(false);
    } catch (exception) {
      console.log(exception);
    }
  };

  loadAllPlantTypes = async () => {
    store.globalStore.setLoading(true);

    try {
      const plantTypes = await agent.Plants.getAllPlantTypes();
      runInAction(() => {
        if (this.allPLantTypesOptions.length == 0) {
          plantTypes.forEach((type) => {
            this.allPlantTypes.set(type.id, type);
            this.allPLantTypesOptions.push({
              key: type.id,
              text: type.name,
              value: type.id,
            });
          });
        }
      });

      store.globalStore.setLoading(false);
    } catch (exception) {
      console.log(exception);
    }
  };

  getPlantRelation = (id: string) => {
    const relation = this.allPlantsRelations.find((a) => a.plant.id == id);

    return relation;
  };

  getPlantDTO = (id: string) => {
    return this.plantDTOList.get(id);
  };

  loadPlant = async (id: string) => {
    store.globalStore.setLoading(true);
    let plant = this.getPlantDTO(id);
    if (plant) {
      this.selectedPlant = plant;
      store.globalStore.setLoading(false);
      return plant;
    } else {
      store.globalStore.setLoading(true);
      try {
        plant = await agent.Plants.details(id);
        runInAction(() => {
          this.selectedPlant = plant;
        });
        store.globalStore.setLoading(false);
        return plant;
      } catch (error) {
        console.log(error);
      }
    }
  };
  loadPlantDTO = async () => {
    store.globalStore.setLoading(true);
    try {
      const plants = await agent.Plants.getPlants();
      plants.forEach((plant) => {
        runInAction(() => {
          this.plantDTOList.set(plant.id, plant);
        });
      });

      store.globalStore.setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  loadAllPlants = async () => {
    store.globalStore.setLoading(true);
    try {
      const plants = await agent.Plants.getAllAvailablePlants();
      runInAction(() => {
        this.allAvailablePlantDTOListGrouped = plants;
      });

      store.globalStore.setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  loadOtherPlants = async (id: string) => {
    store.globalStore.setLoading(true);
    try {
      const plants = await agent.Plants.getOtherPlants(id);
      runInAction(() => {
        this.otherPlants = plants;
      });
      store.globalStore.setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  savePlantsForUser = async (plantsToAdd: Array<string>) => {
    console.log(plantsToAdd);
    store.globalStore.setLoading(true);
    try {
      await agent.Plants.savePlantsForUser(plantsToAdd).finally(() =>
        this.realoadUserPlants(),
      );
      store.globalStore.setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };

  realoadUserPlants = () => {
    store.globalStore.setLoading(true);
    this.loadPlantDTO();
    this.loadAllPlants();
    store.globalStore.setLoading(false);
  };

  createNewPlant = async (plant: PlantDTO, plantTypeId: string) => {
    store.globalStore.setLoading(true);
    try {
      plant.id = uiid();
      plant.plantTypeId = plantTypeId;
      plant.sowingFrom = this.newPlantSowingFrom;
      plant.sowingTo = this.newPlantSowingTo;
      plant.harvestFrom = this.newPlantHarvestFrom;
      plant.harvestTo = this.newPlantHarvestTo;
      await agent.Plants.createNewPlant(plant);
      store.globalStore.setLoading(false);
    } catch (error) {
      console.log(error);
    }
  };
}
