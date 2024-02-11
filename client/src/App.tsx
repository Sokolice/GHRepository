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
    const { bedsStore, plantRecordStore, globalStore, monthWeekStore, pestsStore } = useStore();
    const { loadBeds, beds } = bedsStore;
    const { loadPlantRecords, plantRecordMap } = plantRecordStore;
    const { loadPlantDTO, plantDTOList } = globalStore;
    const { monthWeekRelationList, loadMonthWeeekRelations, currentMonthRelationList, loadMonthWeeeks } = monthWeekStore;
    const { pestsList, loadPests } = pestsStore;


    useEffect(() => {
        if (pestsList.length <= 0)
            loadPests();
        if (monthWeekRelationList.length <= 0)
            loadMonthWeeekRelations();
        if (currentMonthRelationList.length <= 0)
            loadMonthWeeeks();
        if (plantDTOList.size <= 0)
            loadPlantDTO();
        if (plantRecordMap.size <= 0)
            loadPlantRecords();
        if (beds.length <= 0)
            loadBeds();
    }, [beds.length, loadBeds, plantRecordMap, loadPlantRecords, plantDTOList, loadPlantDTO, monthWeekRelationList.length, loadMonthWeeekRelations, pestsList.length, loadPests, currentMonthRelationList.length, loadMonthWeeeks])


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
