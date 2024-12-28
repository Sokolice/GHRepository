import { BedDTO } from "../models/BedDTO";
import { PlantDTO } from "../models/PlantDTO";

export const mapMonthIndex = (month: string) => {
  switch (month) {
    case "Leden":
      return 1;
    case "Únor":
      return 2;
    case "Březen":
      return 3;
    case "Duben":
      return 4;
    case "Květen":
      return 5;
    case "Červen":
      return 6;
    case "Červenec":
      return 7;
    case "Srpen":
      return 8;
    case "Září":
      return 9;
    case "Říjen":
      return 10;
    case "Listopad":
      return 11;
    case "Prosinec":
      return 12;
  }
};

export const mapMonthIndexToName = (index: number) => {
  switch (index) {
    case 1:
      return "Leden";
    case 2:
      return "Únor";
    case 3:
      return "Březen";
    case 4:
      return "Duben";
    case 5:
      return "Květen";
    case 6:
      return "Červen";
    case 7:
      return "Červenec";
    case 8:
      return "Srpen";
    case 9:
      return "Září";
    case 10:
      return "Říjen";
    case 11:
      return "Listopad";
    case 12:
    default:
      return "Prosinec";
  }
};

export const isCropRotationSame = (
  bed: BedDTO,
  plant: PlantDTO | undefined,
) => {
  if (
    plant?.cropRotation == 23 &&
    (bed.cropRotation == 2 || bed.cropRotation == 3)
  )
    return true;
  if (plant?.cropRotation == bed.cropRotation) return true;

  return false;
};
