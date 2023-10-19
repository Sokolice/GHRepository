import MonthWeekStore from "./monthWeekStore";
import { createContext, useContext } from "react";
import PlantRecordStore from "./plantRecordStore";
import GlobalStore from "./globalStore";

interface Store {
    monthWeekStore: MonthWeekStore,
    plantRecordStore: PlantRecordStore,
    globalStore: GlobalStore
}

export const store: Store = {
    monthWeekStore: new MonthWeekStore(),
    plantRecordStore: new PlantRecordStore(),
    globalStore: new GlobalStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}