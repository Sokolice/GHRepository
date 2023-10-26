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
    const { loadPlantRecords, plantRecordMap } = plantRecordStore;

    useEffect(() => {

        async function fetchData() {
            if (plantDTOList.size <= 0)
               await loadPlantDTO();

            if (monthWeekList.length <= 0)
                await loadMonthWeeeks();

            if (monthWeekRelationList.length <= 0)
                await loadMonthWeeekRelations();

            if (plantRecordMap.size <= 0)
                await loadPlantRecords();
        }

        fetchData();
        
    }, [loadMonthWeeeks, loadMonthWeeekRelations, loadPlantRecords, loadPlantDTO])

    
  
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
