import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import App from "./App";
import * as React from "react";
import {getMeasures, MeasureComponent} from "./components/RoentgenGenerator";

export const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    requireAuth: true,
    element: <FetchData />
  },
  {
    path: '/games',
    requireAuth: true,
    element: <App/>
  },
  {
    path :'/measure_simulator',
    requireAuth: false,
    element : <MeasureComponent measures={getMeasures()}/>
  },
  ...ApiAuthorzationRoutes
];
