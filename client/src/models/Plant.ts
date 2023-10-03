export interface Plant {
    id: string
    name: string
    isHybrid: boolean
    directSewing: boolean
    germinationTemp: number
    sewingMonths: Array<string>
    harvestMonths: Array<string>
    companionPlants: Array<Plant>
    avoidPlants: Array<Plant>
    cropRotatoin: number
    description: string
    imageSrc: string
    repeatedPlanting: number
}
