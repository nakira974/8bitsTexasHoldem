import  { Component } from 'react';




export class Counter extends Component {
    static displayName = Counter.name;
    currentCount : number;
    
    constructor(props) {
    super(props);
    this.currentCount = 0x00;
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.currentCount++;
  }

  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p aria-live="polite">Current count: <strong>{this.currentCount}</strong></p>

        <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>
      </div>
    );
  }
}
