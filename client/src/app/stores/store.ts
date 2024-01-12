import MonthWeekStore from "./monthWeekStore";
import { createContext, useContext } from "react";
import PlantRecordStore from "./plantRecordStore";
import GlobalStore from "./globalStore";
import BedsStore from "./bedsStore";
import WeatherStore from "./weatherStore";
import RecipesStore from "./recipesStore";

interface Store {
    monthWeekStore: MonthWeekStore,
    plantRecordStore: PlantRecordStore,
    globalStore: GlobalStore,
    bedsStore: BedsStore,
    weatherStore: WeatherStore,
    recipesStore: RecipesStore
}

export const store: Store = {
    monthWeekStore: new MonthWeekStore(),
    plantRecordStore: new PlantRecordStore(),
    globalStore: new GlobalStore(),
    bedsStore: new BedsStore(),
    weatherStore: new WeatherStore(),
    recipesStore: new RecipesStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}