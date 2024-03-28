import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../components/home/HomePage";
import SewingPlanComponent from "../components/dashboards/SewingPlan";
import PlantRecordsListComponent from "../components/dashboards/PlantRecordsList";
import PlantDetails from "../components/details/PlantDetails";
import BedComponent from "../components/details/Bed";
import RecipeHints from "../components/details/RecipeHints";
import CalendarList from "../components/dashboards/Calendar";
import BedsPage from "../components/dashboards/BedsPage";
import LoginComponent from "../components/users/login";
import MainDashboard from "../components/dashboards/MainDashboard";


export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: '', element: <HomePage /> },
            { path: 'main', element: <MainDashboard /> },
            { path: 'login', element: <LoginComponent /> },
            { path: 'sewingplan', element: <SewingPlanComponent /> },
            { path: 'plantrecords', element: <PlantRecordsListComponent /> },
            { path: 'plants/:id/:origin', element: <PlantDetails /> },
            { path: 'plants/:id/:origin/:otherId', element: <PlantDetails /> }, 
            { path: 'plants/:id/', element: <PlantDetails /> },
            { path: 'beds', element: <BedsPage /> },
            { path: 'beds/:id', element: <BedComponent /> },
            { path: 'recipeHints/:name', element: <RecipeHints /> },
            { path: 'calendar', element: <CalendarList /> }
        ]
    }]

export const router = createBrowserRouter(routes);