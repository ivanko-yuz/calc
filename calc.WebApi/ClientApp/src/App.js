import React, { Component } from 'react';
import { Route } from 'react-router';
import { Calculator } from './components/Calculator';
import './App.css';

class App extends Component {

    render() {
        return (
            <Route exact path='/' component={Calculator} />
        );
    }
}

export default App;
