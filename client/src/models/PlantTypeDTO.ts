export interface PlantTypeDTO {
    id: string,
    name: string,
    directSewing: boolean,
    preCultivation: boolean,
    germinationTemp: number,
    cropRotation: number,
    description: string,
    imageSrc: string,
    repeatedPlanting: number
}