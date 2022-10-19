import 'bootstrap/dist/css/bootstrap.css';
import * as React from 'react'
import * as ReactDOM from 'react-dom/client'
import App from './App'
import {BrowserRouter, Route, Routes} from "react-router-dom";
import reportWebVitals from './reportWebVitals';
import * as serviceWorkerRegistration from './serviceWorkerRegistration';
import {NavMenu} from "./components/NavMenu";
import {Home} from "./components/Home";
import {Counter} from "./components/Counter";

import {ApiAuthorizationRoutes} from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import { Container } from 'reactstrap';
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');

//<AuthorizeRoute path='/fetch-data' children={FetchData}/>
ReactDOM.createRoot(document.getElementById('root')!).render(
    <BrowserRouter basename={baseUrl}>
            <NavMenu/>
        <Container>
            <Routes>
                <Route path="/" element={<Home/>}/>
                
                <Route path="/games" element={<App/>}/>
                
                <Route path='/counter'  element={<Counter/>}/>
                
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} element={<ApiAuthorizationRoutes/>}/>

            </Routes>
        </Container>
    </BrowserRouter>)

serviceWorkerRegistration.unregister();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();