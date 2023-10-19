import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../components/home/HomePage";
import SewingPlanComponent from "../components/dashboard/SewingPlan";
import PlantRecordsListComponent from "../components/dashboard/PlantRecordsList";


export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: 'sewingplan', element: <SewingPlanComponent /> },
            { path: '', element: <HomePage/> },
            { path: 'plantrecords', element: <PlantRecordsListComponent /> },
            /*{ path: 'createActivity', element: <ActivityForm key='create' /> },
            { path: 'manage/:id', element: <ActivityForm key='manage' /> }*/
        ]
    }]

export const router = createBrowserRouter(routes);