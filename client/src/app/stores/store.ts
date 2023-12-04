import MonthWeekStore from "./monthWeekStore";
import { createContext, useContext } from "react";
import PlantRecordStore from "./plantRecordStore";
import GlobalStore from "./globalStore";
import BedsStore from "./BedsStore";

interface Store {
    monthWeekStore: MonthWeekStore,
    plantRecordStore: PlantRecordStore,
    globalStore: GlobalStore,
    bedsStore: BedsStore
}

export const store: Store = {
    monthWeekStore: new MonthWeekStore(),
    plantRecordStore: new PlantRecordStore(),
    globalStore: new GlobalStore(),
    bedsStore: new BedsStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}