/* eslint-disable @typescript-eslint/no-explicit-any */
import { Container } from 'semantic-ui-react';
import './App.css'
import HomePage from './components/home/HomePage';
import { Outlet } from 'react-router-dom';
import NavBar from './components/layout/NavBar';

function App() {

    

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

export default App
