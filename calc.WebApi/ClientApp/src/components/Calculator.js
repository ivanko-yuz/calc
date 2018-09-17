import React, { Component } from 'react';

export class Calculator extends Component {
    displayName = Calculator.name

    constructor(props) {
        super(props);
        this.state = {
            value: '',
            expression: ''
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleClick = this.handleClick.bind(this);
    }

    handleChange(event) {
        this.setState({ expression: event.target.value });
    }

    handleClick() {
        console.log(JSON.stringify({
            value: this.state.expression.toString()
        }));

        fetch('api/calc/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: "\"" + this.state.expression +"\""
        })
            .then(response => response.json())
            .then(data => {
                this.setState({ value: data });
            })
            .catch((error) => {
                console.error(error);
            });
    }


    render() {
        return (
            <div>
                <h1>Calculator</h1>

                <p>This is a simple example of a React component.</p>

                <input type="text" value={this.state.expression} onChange={this.handleChange} placeholder="Write a expression..." />

                <p>Result: <strong>{this.state.value}</strong></p>

                <button onClick={this.handleClick}>Calculate</button>
            </div>
        );
    }
}
