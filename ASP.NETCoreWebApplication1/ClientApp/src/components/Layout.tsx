import { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import * as React from 'react'
import {RouteProps} from "react-router-dom";
import { State } from 'zustand';

export class Layout extends React.Component  {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}

