export default class MyMapping {

    static mapBedRelation = (bed: Bed)=> {

        return <BedRelation>{
            bed : bed,
            cells : bed.cells
        } 

    }
}