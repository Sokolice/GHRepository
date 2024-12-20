export interface Statistics{
    freezeAlert: boolean,
    highTemperatureAlert: boolean,
    rainPeriodAlert: boolean,
    missingSowingThisWeekAmount: number,
    missingTaskThisWeekAmount: number,
    canBeSowedRepeatedlyAmount: number,
    readyToHarvestAmount: number,
    canBeSowedThisWeek: Array<string>,
    canBeSowedRepeatedly: Array<string>,
    readyToHarvest: Array<string>
}