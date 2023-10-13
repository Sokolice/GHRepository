
import ReactDOM from 'react-dom/client'
import './index.css'
import 'semantic-ui-css/semantic.min.css'
import { StoreContext, store } from './app/store.ts'
import { RouterProvider } from 'react-router-dom'
import { router } from './router/router'


const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);
root.render(
    <StoreContext.Provider value={store}>
        <RouterProvider router={router} />
    </StoreContext.Provider>
);
