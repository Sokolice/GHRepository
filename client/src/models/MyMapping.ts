import { Bed } from "./Bed"
import { BedRelation } from "./BedRelation"

export default class MyMapping {

    static mapBedRelation = (bed: Bed)=> {

        return <BedRelation>{
            bed : bed,
            cells: bed.cells
        } 

    }

    static mapMonthIndex = (month: string)=>{

        switch (month) {
            case "Leden":
                return 1;
            case "�nor":
                return 2;
            case "B�ezen":
                return 3;
            case "Duben":
                return 4;
            case "Kv�ten":
                return 5;
            case "�erven":
                return 6;
            case "�ervenec":
                return 7;
            case "Srpen":
                return 8;
            case "Z���":
                return 9;
            case "��jen":
                return 10;
            case "Listopad":
                return 11;
            case "Prosinec":
                return 12;
        }
    }
}