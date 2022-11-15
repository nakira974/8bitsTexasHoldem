import 'bootstrap/dist/css/bootstrap.css';
import * as React from 'react'
import * as ReactDOM from 'react-dom/client'
import {BrowserRouter, Route, Routes} from "react-router-dom";
import reportWebVitals from './reportWebVitals';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import {NavMenu} from "./components/NavMenu";

import { Container } from 'reactstrap';
import {AppRoutes} from './AppRoutes.js'
import {AuthorizeRoute} from './components/api-authorization/AuthorizeRoute.js'
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');


ReactDOM.createRoot(document.getElementById('root')!).render(
    <BrowserRouter basename={baseUrl}>
            <NavMenu/>
        <Container>
            <Routes>
                {AppRoutes.map((route, index) => {
                    const { element, requireAuth, ...rest } = route;
                    return <Route key={index} {...rest} element={requireAuth ? <AuthorizeRoute {...rest} element={element} /> : element} />;
                })}
            </Routes>
        </Container>
    </BrowserRouter>)

serviceWorkerRegistration.unregister();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();