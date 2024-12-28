import { Checkbox } from "semantic-ui-react";
import { GardeningTaskDTO } from "../../models/GardeningTaskDTO";
import { useState } from "react";
import { useStore } from "../../app/stores/store";

interface Props {
  task: GardeningTaskDTO;
}
const TaskCheck = function ({ task }: Props) {
  const { monthWeekStore } = useStore();
  const { setMonthTaskRelation } = monthWeekStore;

  const [completed, setCompleted] = useState(task.isCompleted);

  function onClick() {
    task.isCompleted = !task.isCompleted;
    setCompleted(task.isCompleted);
    setMonthTaskRelation(task);
  }

  return <Checkbox label={task.name} checked={completed} onClick={onClick} />;
};

export default TaskCheck;
