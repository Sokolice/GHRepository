import {
  Container,
  Dropdown,
  DropdownItem,
  DropdownMenu,
  Menu,
} from "semantic-ui-react";
import { Link, NavLink } from "react-router-dom";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";

const NavBar = observer(function NavBar() {
  const { userStore } = useStore();
  const { user, logout } = userStore;
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item as={NavLink} to="/" header>
          Zahradníkův pomocník
        </Menu.Item>
        <Menu.Item as={NavLink} to="/sewingplan" name="Rostliny"></Menu.Item>
        <Menu.Item as={NavLink} to="/plantrecords" name="Roste"></Menu.Item>
        <Menu.Item as={NavLink} to="/beds">
          Záhony
        </Menu.Item>
        <Menu.Item as={NavLink} to="/calendar">
          Kalendář
        </Menu.Item>
        <Menu.Item position="right">
          <Dropdown pointing="left" text={user?.displayName}>
            <DropdownMenu>
              <DropdownItem
                as={Link}
                to={`/profiles/${user?.userName}`}
                text="Muj profil"
                icon="user"
              />
              <DropdownItem onClick={logout} text="Odhlasit" icon="power" />
            </DropdownMenu>
          </Dropdown>
        </Menu.Item>
      </Container>
    </Menu>
  );
});

export default NavBar;
