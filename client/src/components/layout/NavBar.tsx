import React from 'react';
import { Container, Menu } from 'semantic-ui-react';
import { NavLink } from 'react-router-dom';


export default function NavBar() {

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' header >
                    Zahradníkův pomocník
                </Menu.Item>
                <Menu.Item as={NavLink} to='/sewingplan' name='Rostliny'>
            </Menu.Item>
                <Menu.Item as={NavLink} to='/plantrecords' name='Roste'>
            </Menu.Item>
                <Menu.Item as={NavLink} to='/beds' >
                    Záhony
                </Menu.Item>
                <Menu.Item as={NavLink} to='/settings' >
                    Nastavení pocasi
                </Menu.Item>
            </Container>
        </Menu>
    )
}