export default class BedsStore {
    bedList = new Map<string, Bed>();

    //cellMap = new Array<Array<Cell>>();
    clickedCells = new Array<string>();
    clickedGridId = "";

    get beds() {
        return Array.from(this.bedList.values());
    }

    createBed(bed: Bed) {
        const r = (bed.width / 20) * 100;
        const c = (bed.length / 20) * 100;

        const cells = new Array<Array<Cell>>();

        for (let y = 1; y <= c; y++) {
            const row = Array<Cell>();
            for (let x = 1; x <= r; x++) {
                row.push({ x: x, y: y, isActive: false, cssClass: "", backgroundImage: "" })
            }
            cells.push(row);
        }

        bed.cells = cells;
        bed.numOfColumns = c;

        this.bedList.set(bed.id, bed);
    }
}