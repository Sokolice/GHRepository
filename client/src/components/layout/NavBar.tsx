import React from 'react';
import { Button, Container, Menu, Image } from 'semantic-ui-react';
import { NavLink } from 'react-router-dom';


export default function NavBar() {

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' header>
                    Zahradnikuv pomocnik
                </Menu.Item>
                <Menu.Item as={NavLink} to='/sewingplan' name='SewingPlan' />
            </Container>
        </Menu>
    )
}