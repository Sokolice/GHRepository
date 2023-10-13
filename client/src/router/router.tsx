import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../components/home/HomePage";
import PlantRecordsComponent from "../components/dashboard/PlantRecords";
import SewingPlanComponent from "../components/dashboard/SewingPlan";


export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: 'sewingplan', element: <SewingPlanComponent /> },
            { path: '', element: <HomePage/> },
            { path: 'plantrecords', element: <PlantRecordsComponent /> },
            /*{ path: 'createActivity', element: <ActivityForm key='create' /> },
            { path: 'manage/:id', element: <ActivityForm key='manage' /> }*/
        ]
    }]

export const router = createBrowserRouter(routes);