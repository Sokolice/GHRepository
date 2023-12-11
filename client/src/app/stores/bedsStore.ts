import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import { store } from "./store";
import { v4 as uiid } from 'uuid';
import GlobalStore from "./globalStore";

export default class BedsStore {
    bedList = new Map<string, Bed>();
    selectedBed: Bed = <Bed>{ cells: new Array<Cell>(), id: "", length: 0, name: "", width: 0, numOfColumns: 0 };

    //cellMap = new Array<Array<Cell>>();
    clickedCells = new Array<string>();
    clickedGridId = "";

    constructor() {
        makeAutoObservable(this)
    }
    get beds() {
        return Array.from(this.bedList.values());
    }

    loadBeds = async () => {
        try {

            store.globalStore.loading = true;
            const bedRecords = await agent.Beds.getBeds();
            //console.log(bedRecords);
            runInAction(() => {
                bedRecords.forEach(bedRecord => {
                    this.bedList.set(bedRecord.bed.id,
                        <Bed>{
                            id: bedRecord.bed.id,
                            name: bedRecord.bed.name,
                            length: bedRecord.bed.length,
                            numOfColumns: bedRecord.bed.numOfColumns,
                            numOfRows: bedRecord.bed.numOfRows,
                            width: bedRecord.bed.width,
                            cells: bedRecord.cells
                        });
                })
                store.globalStore.loading = false;
            });

        }
        catch (error) {
            console.log(error);
        }
    }


    loadBed = async (id: string) => {

        let bed = this.bedList.get(id);
        if (bed) {
            this.selectedBed = bed;
        }
        else {
            store.globalStore.loading = true;
            try {
                const bedRelation = await agent.Beds.details(id);
                console.log(bedRelation);
                runInAction(() => {
                    this.selectedBed.id = bedRelation.bed.id;
                    this.selectedBed.cells = bedRelation.cells;
                    this.selectedBed.length = bedRelation.bed.length;
                    this.selectedBed.width = bedRelation.bed.width;
                    this.selectedBed.name = bedRelation.bed.name;
                    this.selectedBed.numOfColumns = bedRelation.bed.numOfColumns;
                    this.selectedBed.numOfRows = bedRelation.bed.numOfRows;
                });
                store.globalStore.loading = false;

            }
            catch (error) {
                console.log(error);
            }
        }
        
    }

    updateBed = (bed: Bed) => {

        try {

            runInAction(() => {
                this.bedList.set(bed.id, bed);
            })
        }
        catch (error) {
            console.log(error);
        }

    }

    createBed = async(aWidth: number, aLength: number, aName: string) =>{
        const bed = <Bed>{};
        bed.id = uiid();
        bed.name = aName;

        const r = (aWidth / 20) * 100;
        const c = (aLength / 20) * 100;

        const cells = new Array<Cell>();

        for (let x = 1; x <= c; x++) {
            //const row = Array<Cell>();
            for (let y = 1; y <= r; y++) {
                cells.push({id: uiid(), x: x, y: y, isActive: false, gridColumn: "", gridRow: "", backgroundImage: "" })
            }
            //cells.push(row);
        }
        bed.width = aWidth;
        bed.length = aLength;
        bed.cells = cells;
        bed.numOfColumns = c;
        bed.numOfRows = r;
        store.globalStore.loading = true;
        try {
            const newBed = <BedRelation>{
                bed: <BedDTO>{ id: bed.id, name: bed.name, length: bed.length, numOfColumns: bed.numOfColumns, width: bed.width, numOfRows: bed.numOfRows },
                cells: bed.cells
            };
            //console.log(newBed);
            await agent.Beds.create(newBed);
            runInAction(() => {
                this.bedList.set(bed.id, bed);
            })

            store.globalStore.loading = false;
        } catch (error) {
            console.log(error);
        }
    }

    saveBed = async (bed: Bed) => {
        await agent.Beds.create(bed);
    }

    deleteBed = async (id: string) => {
        store.globalStore.loading = true;
        try {
            await agent.Beds.delete(id);
            runInAction(() => {
                this.bedList.delete(id);
            });

            store.globalStore.loading = false;
        } catch (error) {
            console.log(error);
        }
    }
}