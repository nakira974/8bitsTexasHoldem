import { Component, Fragment } from 'react';
import { Route } from "react-router-dom";
import { Login } from './Login'
import { Logout } from './Logout'
import { ApplicationPaths, LoginActions, LogoutActions } from './ApiAuthorizationConstants';

export function ApiAuthorizationRoutes(){
    return(
        <Fragment>
            <Route path={ApplicationPaths.Login} element={() => loginAction(LoginActions.Login)} />
            <Route path={ApplicationPaths.LoginFailed} element={() => loginAction(LoginActions.LoginFailed)} />
            <Route path={ApplicationPaths.LoginCallback} element={() => loginAction(LoginActions.LoginCallback)} />
            <Route path={ApplicationPaths.Profile} element={() => loginAction(LoginActions.Profile)} />
            <Route path={ApplicationPaths.Register} element={() => loginAction(LoginActions.Register)} />
            <Route path={ApplicationPaths.LogOut} element={() => logoutAction(LogoutActions.Logout)} />
            <Route path={ApplicationPaths.LogOutCallback} element={() => logoutAction(LogoutActions.LogoutCallback)} />
            <Route path={ApplicationPaths.LoggedOut} element={() => logoutAction(LogoutActions.LoggedOut)} />
        </Fragment>
    );
}


function loginAction(name){
    return (<Login action={name}></Login>);
}

function logoutAction(name) {
    return (<Logout action={name}></Logout>);
}
