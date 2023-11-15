import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../components/home/HomePage";
import SewingPlanComponent from "../components/dashboard/SewingPlan";
import PlantRecordsListComponent from "../components/dashboard/PlantRecordsList";
import PlantDetails from "../components/details/PlantDetails";
import BedsList from "../components/dashboard/BedsList";


export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: '', element: <HomePage /> },
            { path: 'sewingplan', element: <SewingPlanComponent /> },
            { path: 'plantrecords', element: <PlantRecordsListComponent /> },
            { path: 'plants/:id', element: <PlantDetails /> },
            { path: 'beds', element: <BedsList /> }
            /*{ path: 'createActivity', element: <ActivityForm key='create' /> },
            { path: 'manage/:id', element: <ActivityForm key='manage' /> }*/
        ]
    }]

export const router = createBrowserRouter(routes);