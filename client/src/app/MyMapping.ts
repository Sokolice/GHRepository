import { Bed } from "../models/Bed"
import { BedRelation } from "../models/BedRelation"

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
    }
}