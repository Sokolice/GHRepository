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
            case "Únor":
                return 2;
            case "Bøezen":
                return 3;
            case "Duben":
                return 4;
            case "Kvìten":
                return 5;
            case "Èerven":
                return 6;
            case "Èervenec":
                return 7;
            case "Srpen":
                return 8;
            case "Záøí":
                return 9;
            case "Øíjen":
                return 10;
            case "Listopad":
                return 11;
            case "Prosinec":
                return 12;
        }
    }
}