import { Select } from "semantic-ui-react";
import { MonthWeekDTO } from "../../../models/MonthWeekDTO";
import { monthOptions, weekOptions } from "../../options/monthOptions";
import { mapMonthIndexToName } from "../../MyMapping";
import { observer } from "mobx-react-lite";
import { runInAction } from "mobx";

interface Props {
  value: MonthWeekDTO;
  disabled: boolean;
}

const MonthWeekSelect = observer(function MonthWeekSelect({
  value,
  disabled,
}: Props) {
  const handleMonthChange = (data: any) => {
    runInAction(() => {
      value.monthIndex = data.value;
      value.month = mapMonthIndexToName(data.value);
    });
  };

  const handleWeekChange = (data: any) => {
    runInAction(() => {
      value.week = data.value;
    });
  };

  return (
    <>
      <Select
        placeholder="Mesic"
        options={monthOptions}
        disabled={disabled}
        value={value.monthIndex}
        onChange={handleMonthChange}
      />
      <Select
        placeholder="Tyden"
        options={weekOptions}
        disabled={disabled}
        value={value.week}
        onChange={handleWeekChange}
      />
    </>
  );
});
export default MonthWeekSelect;
