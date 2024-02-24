import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import { store } from "./store";
import { v4 as uiid } from 'uuid';
import { BedRelation } from "../../models/BedRelation";
import { Bed } from "../../models/Bed";
import { Cell } from "../../models/Cell";
import { BedDTO } from "../../models/BedDTO";
import { PlantDTO } from "../../models/PlantDTO";

export default class BedsStore {
    bedList = new Map<string, BedRelation>();
    selectedBed: BedRelation = {
        bed: <BedDTO>{},
        cells: [],
        plants: []
    };
    constructor() {
        makeAutoObservable(this)
    }
    get beds() {
        return Array.from(this.bedList.values());
    }

    loadBeds = async () => {
        try {

            store.globalStore.setLoading(true);
            const bedRelations = await agent.Beds.getBeds();
            console.log(bedRelations);
            runInAction(() => {
                bedRelations.forEach(bedRelation => {

                    /*bedRelation.cells.forEach(cell => {
                        if (cell.plantRecordId != "") {

                            const plant: PlantDTO = store.globalStore.getPlantDTO(
                                bedRelation.bed.isDesign ? cell.plantRecordId : store.plantRecordStore.getPlantRecord(cell.plantRecordId)?.plantId
                                    ?? "");
                            if (plant)
                                bedRelation.plants.push(plant);
                        }
                    })*/

                    this.bedList.set(bedRelation.bed.id, bedRelation);
                })
                store.globalStore.setLoading(false);
            });

        }
        catch (error) {
            console.log(error);
        }
    }


    loadBed = async (id: string) => {

        const bed = this.bedList.get(id);
        console.log("bed: " + bed);
        if (bed) {
            this.selectedBed = bed;
        }
        else {
            store.globalStore.setLoading(true);
            try {
                const bedRelation = await agent.Beds.details(id);


                const ids = new Map<string, PlantDTO>();
                bedRelation.cells.forEach(cell => {
                    if (cell.plantRecordId != "") {

                        const plant: PlantDTO = store.globalStore.getPlantDTO(
                            bedRelation.bed.isDesign ? cell.plantRecordId : store.plantRecordStore.getPlantRecord(cell.plantRecordId)?.plantId
                                ?? "");
                        if (plant)
                            ids.set(plant.id, plant);
                    }
                })
                runInAction(() => {
                    this.selectedBed = bedRelation;
                });

                store.globalStore.setLoading(false);
            }
            catch (error) {
                console.log(error);
            }
        }
        
    }

    updateBed = async (bedRelation: BedRelation) => {

        try {

            store.globalStore.setLoading(true);
            await agent.Beds.update(bedRelation);
            runInAction(() => {
                this.bedList.set(bedRelation.bed.id, bedRelation);
            })

            store.globalStore.setLoading(false);
        }
        catch (error) {
            console.log(error);
        }

    }

    deleteCells = async (ids: Array<string>) => {

        try {

            store.globalStore.setLoading(true);
            await agent.Cells.deleteCells(ids);
            store.globalStore.setLoading(false);
        }
        catch (error) {
            console.log(error);
        }

    }


    createBed = async (aWidth: number, aLength: number, aName: string, aIsDesign: boolean, aCropRotation: number) => {
        const bed = <Bed>{};
        bed.id = uiid();
        bed.name = aName;

        const r = (aWidth / 20) * 100;
        const c = (aLength / 20) * 100;

        const cells = new Array<Cell>();

        for (let x = 1; x <= c; x++) {
            //const row = Array<Cell>();
            for (let y = 1; y <= r; y++) {
                cells.push({ id: uiid(), x: x, y: y, isActive: false, gridArea: "", backgroundImage: "", plantRecordId: "", isHidden: false, objectID: "" })
            }
            //cells.push(row);
        }
        bed.width = aWidth;
        bed.length = aLength;
        bed.cells = cells;
        bed.numOfColumns = c;
        bed.numOfRows = r;
        bed.isDesign = aIsDesign;
        bed.cropRotation = aCropRotation;
        bed.plants = new Map<string, PlantDTO>();

        store.globalStore.setLoading(true);

        try {
            const newBed = <BedRelation>{
                bed: <BedDTO>{
                    id: bed.id,
                    name: bed.name,
                    length: bed.length,
                    numOfColumns: bed.numOfColumns,
                    width: bed.width,
                    numOfRows: bed.numOfRows,
                    isDesign: bed.isDesign,
                    cropRotation: bed.cropRotation
                },
                cells: bed.cells,
                plants: new Array<PlantDTO>
            };
            await agent.Beds.create(newBed);
            runInAction(() => {
                this.bedList.set(bed.id, newBed);
            })

            store.globalStore.setLoading(false);

        } catch (error) {
            console.log(error);
        }
    }


    deleteBed = async (id: string) => {
        store.globalStore.loading = true;
        try {
            await agent.Beds.delete(id);
            runInAction(() => {
                this.bedList.delete(id);
                store.globalStore.loading = false;
            });

        } catch (error) {
            console.log(error);
        }
    }
}