import MonthWeekStore from "./monthWeekStore";
import { createContext, useContext } from "react";

interface Store {
    monthWeekStore: MonthWeekStore
}

export const store: Store = {
    monthWeekStore: new MonthWeekStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}