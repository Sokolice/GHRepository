import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../components/home/HomePage";
import SewingPlanComponent from "../components/dashboards/SewingPlan";
import PlantRecordsListComponent from "../components/dashboards/PlantRecordsList";
import PlantDetails from "../components/details/PlantDetails";
import BedsList from "../components/dashboards/BedsList";
import BedComponent from "../components/details/Bed";
import Settings from "../components/dashboards/Settings";
import RecipeHints from "../components/details/RecipeHints";
import CalendarList from "../components/dashboards/calendar";


export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: '', element: <HomePage /> },
            { path: 'sewingplan', element: <SewingPlanComponent /> },
            { path: 'plantrecords', element: <PlantRecordsListComponent /> },
            { path: 'plants/:id/:origin', element: <PlantDetails /> },
            { path: 'beds', element: <BedsList /> },
            { path: 'beds/:id', element: <BedComponent /> },
            { path: 'settings', element: <Settings /> },
            { path: 'recipeHints/:name', element: <RecipeHints /> },
            { path: 'calendar', element: <CalendarList /> }
            /*{ path: 'createActivity', element: <ActivityForm key='create' /> },
            { path: 'manage/:id', element: <ActivityForm key='manage' /> }*/
        ]
    }]

export const router = createBrowserRouter(routes);