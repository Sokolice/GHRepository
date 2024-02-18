import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { store, useStore } from "../../app/stores/store";
import {  Button, Container, Header, Item, ItemGroup } from "semantic-ui-react";
import LoadingComponent from "../layout/LoadingComponent";
import TaskCheck from "../details/TaskCheck";
import { WeekTaskRelation } from "../../models/MonthTaskRelation";

const CalendarList = observer(function CalendarView() {


    const { monthWeekStore } = useStore();
    const { monthTaskRelations, loadMonthTasksRelation, shareWeekTasks } = monthWeekStore;
    useEffect(() => {
        if (monthTaskRelations.length <= 0) {

            loadMonthTasksRelation();
        }
    }, [monthTaskRelations.length, loadMonthTasksRelation])

    function shareClick(week: WeekTaskRelation) {
        shareWeekTasks(week);
    }


    if (store.globalStore.loading)
        return (
            <LoadingComponent />
        )
    return (
        <Container key={"1"}>
            {
                monthTaskRelations.map((month) => {
                    return (
                        <>
                            <Header as="h2" key={month.index}>{month.month}</Header>

                            <ItemGroup key={month.month}>
                            {
                                month.weekTaskRelations.map((week) => {
                                    return (
                                        <ItemGroup key={month.month + "_" + week.week}>
                                            <Button content={`${week.week} .Týden`} icon='share square' labelPosition='right' onClick={()=>shareClick(week)} />
                                            {week.gardeningTasks.map(task => {
                                                return (
                                                    <Item key={task.id}>
                                                        <TaskCheck task={task} key={task.id} />
                                                    </Item>
                                                )
                                            })}
                                        </ItemGroup>
                                    )
                                })
                            }
                            </ItemGroup>
                                        
                        </>
                    )
                })
            }    
        </Container>
    )
})
export default CalendarList;