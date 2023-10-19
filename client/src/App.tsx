/* eslint-disable @typescript-eslint/no-explicit-any */
import { Container } from 'semantic-ui-react';
import './App.css'
import HomePage from './components/home/HomePage';
import { Outlet, useLocation } from 'react-router-dom';
import NavBar from './components/layout/NavBar';
import { observer } from 'mobx-react-lite';
import { useStore } from './app/stores/store';
import { useEffect } from 'react';

function App() {

    const { monthWeekStore, globalStore, plantRecordStore } = useStore();
    const { monthWeekList, loadMonthWeeeks, loadMonthWeeekRelations, monthWeekRelationList } = monthWeekStore;
    const { loadPlantDTO, plantDTOList } = globalStore;
    const { loadPlantRecords, plantRecordsList } = plantRecordStore;

    useEffect(() => {
        if (monthWeekList.length <= 1)
            loadMonthWeeeks();
    }, [loadMonthWeeeks, monthWeekList])

    useEffect(() => {
        if (plantRecordsList.length <= 1)
            loadPlantRecords();
    }, [loadPlantRecords, plantRecordsList.length])

    useEffect(() => {
        if (plantDTOList.size <= 1)
            loadPlantDTO();
    }, [loadPlantDTO, plantDTOList.size])

    useEffect(() => {
        if (monthWeekRelationList.length <= 1)
            loadMonthWeeekRelations();
    }, [loadMonthWeeekRelations, monthWeekRelationList.length])

    const location = useLocation();
    return (
        <>
            {location.pathname === '/' ? <HomePage /> : (
                <>
                    <NavBar />
                    <Container style={{ marginTop: '7em' }}>
                        <Outlet />
                    </Container>
                </>
            )}

        </>
    )
}

export default observer(App)
