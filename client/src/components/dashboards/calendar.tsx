import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { store, useStore } from "../../app/stores/store";
import {  Checkbox, Container, Item, Label } from "semantic-ui-react";
import LoadingComponent from "../layout/LoadingComponent";

const CalendarList = observer(function CalendarView() {


    const { monthWeekStore } = useStore();
    const { monthWeekTaskRelationList, loadMonthTasksRelation } = monthWeekStore;
    useEffect(() => {
        if (monthWeekTaskRelationList.length <= 0) {

            loadMonthTasksRelation();
        }
    }, [monthWeekTaskRelationList.length, loadMonthTasksRelation])
    if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )
    return (
        <Container>
            {
                monthWeekTaskRelationList.map((item) => {
                    return (
                        <>
                            <Label>{item.monthWeekDTO.month} - {item.monthWeekDTO.week}</Label>
                            {
                                item.gardeningTasks.map((task) => {
                                    return (
                                        <Item key={task.id}>
                                            <Checkbox label={task.name} checked={task.isCompleted} />
                                        </Item>
                                    )
                                    })
                            }
                        </>
                    )
                })
            }    
        </Container>
    )
})
export default CalendarList;