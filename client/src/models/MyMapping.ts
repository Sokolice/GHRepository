import { Bed } from "./Bed"
import { BedRelation } from "./BedRelation"

export default class MyMapping {

    static mapBedRelation = (bed: Bed)=> {

        return <BedRelation>{
            bed : bed,
            cells: bed.cells,
            plants: bed.plants
        } 

    }
}