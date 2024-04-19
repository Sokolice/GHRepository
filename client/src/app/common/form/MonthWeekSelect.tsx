import { Select } from "semantic-ui-react";
import { MonthWeekDTO } from "../../../models/MonthWeekDTO";
import { monthOptions, weekOptions } from "../../options/monthOptions";
import { SyntheticEvent } from "react";
import MyMapping from "../../MyMapping";
import { observer } from "mobx-react-lite";
import { runInAction } from "mobx";

interface Props {
    value: MonthWeekDTO,
    disabled: boolean
}


const MonthWeekSelect = observer(function MonthWeekSelect({ value, disabled }: Props) {

    const handleMonthChange = (e: SyntheticEvent<HTMLElement, Event>, data) => {
        runInAction(() => {
            value.monthIndex = data.value;
            value.month = MyMapping.mapMonthIndexToName(data.value);
        })
    }

    const handleWeekChange = (e: SyntheticEvent<HTMLElement, Event>, data) => {
        runInAction(() => {

            value.week = data.value;
        })
    }

    return (
        <>
            <Select placeholder='Mesic' options={monthOptions} disabled={disabled} value={value.monthIndex} onChange={handleMonthChange} />
            <Select placeholder='Tyden' options={weekOptions} disabled={disabled} value={value.week} onChange={handleWeekChange} />
        </>)
}
)
export default MonthWeekSelect;