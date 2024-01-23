/* eslint-disable @typescript-eslint/no-explicit-any */
import { Container } from 'semantic-ui-react';
import './App.css'
import HomePage from './components/home/HomePage';
import { Outlet, useLocation } from 'react-router-dom';
import NavBar from './components/layout/NavBar';
import { observer } from 'mobx-react-lite';

function App() {

   
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
