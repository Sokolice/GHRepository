import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import SewingPlanComponent from "../components/dashboard/SewingPlan";
import HomePage from "../components/home/HomePage";


export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: '', element: <HomePage /> },
            { path: 'sewingplan', element: <SewingPlanComponent /> },
            /*{ path: 'activities/:id', element: <ActivityDetails /> },
            { path: 'createActivity', element: <ActivityForm key='create' /> },
            { path: 'manage/:id', element: <ActivityForm key='manage' /> }*/
        ]
    }]

export const router = createBrowserRouter(routes);