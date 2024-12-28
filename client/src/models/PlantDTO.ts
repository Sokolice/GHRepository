import { MonthWeekDTO } from "./MonthWeekDTO";

export interface PlantDTO {
  id: string;
  name: string;
  isHybrid: boolean;
  directSewing: boolean;
  germinationTemp: number;
  cropRotation: number;
  description: string;
  imageSrc: string;
  repeatedPlanting: number;
  preCultivation: boolean;
  sowingFrom: MonthWeekDTO;
  sowingTo: MonthWeekDTO;
  harvestFrom: MonthWeekDTO;
  harvestTo: MonthWeekDTO;
  plantTypeId: string;
}
