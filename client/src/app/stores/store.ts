import MonthWeekStore from "./monthWeekStore";
import { createContext, useContext, useEffect } from "react";
import PlantRecordStore from "./plantRecordStore";
import GlobalStore from "./globalStore";
import BedsStore from "./bedsStore";
import WeatherStore from "./weatherStore";
import RecipesStore from "./recipesStore";
import PestsStore from "./pestsStore";

interface Store {
    monthWeekStore: MonthWeekStore,
    plantRecordStore: PlantRecordStore,
    globalStore: GlobalStore,
    bedsStore: BedsStore,
    weatherStore: WeatherStore,
    recipesStore: RecipesStore,
    pestsStore: PestsStore
}

export const store: Store = {
    monthWeekStore: new MonthWeekStore(),
    plantRecordStore: new PlantRecordStore(),
    globalStore: new GlobalStore(),
    bedsStore: new BedsStore(),
    weatherStore: new WeatherStore(),
    recipesStore: new RecipesStore(),
    pestsStore: new PestsStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}