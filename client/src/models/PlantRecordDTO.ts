export interface PlantRecordDTO {
    id: string,
    plantId: string,
    datePlanted: Date | null,
    amountPlanted: number,
    progress: number,
    presumedHarvest: string,
    note: string,
    mark: string
}
