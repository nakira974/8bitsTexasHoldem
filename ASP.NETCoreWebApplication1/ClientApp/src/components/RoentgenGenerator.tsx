
import * as React from 'react'
import { Chart, ChartConfiguration, LineController, LineElement, PointElement, LinearScale, Title, registerables} from 'chart.js'

// Create in Typescript 4.5.4 a function that calculates the Coulomb force, and use this function into another that calculates Coulomb per Kilograms,

function coulombForce(q1: number, q2: number, d: number) {
    const k = 8.99 * Math.pow(10, 9);
    return (k * q1 * q2) / Math.pow(d, 2);
}

export function coulombPerKg(m: number, q: number, d: number) {
    return coulombForce(q, 1, d) / m;
}

// Create a function called ToRoentgen that convert Coulomb per Kilograms into the old roentgen unit measurement system

export function toRoentgen(coulombPerKg: number) {
    return coulombPerKg / 0.000258;
}


//Create a Typescript function called toSievert that convert roentgen unit pass in parameter into sievert unit


function toSievert(roentgen: number): number {
  return roentgen * 0.000258;
}

export class Measure {
    measure_datetime: Date;
    roentgen_level: number;

    constructor(measure_datetime: Date, roentgen_level: number) {
        this.measure_datetime = measure_datetime;
        this.roentgen_level = roentgen_level;
    }
}

// Create a react version version 18 component in Typescript 4.5.4 , create into the component an array of Measure type called measures, use the librairy chart.js inside the component to render a Line Chart from measures

interface MeasureProps {
    measures: Measure[];
}
const randomNumber = (): number => {
    return Math.random() * (2.58 - 0.645) + 0.645;
};

export function getMeasures() : Measure[] {
    let result :  Measure[]  = [];
    let dates = getRandomDates(256);
    dates.forEach(date => {
        result.push(new Measure(date, toRoentgen(randomNumber())))
    })
    return result;
}

function getRandomDates(limit : number) : Date [] {
    let result :  Date [] =  [] ;
    let startDate = new Date(1986, 5, 5, 12, 0, 0, 0);
    for (let i = 0; i < limit; i++) {
        startDate.setHours(startDate.getHours() + 1);
        result.push(new Date(startDate));
    }
    return result;
}

interface State{
    measures : Measure[],
    unit : string
}

export class MeasureComponent extends React.Component<MeasureProps, State> {
    constructor(props: MeasureProps) {
        super(props);
        this.state = {
            measures: this.props.measures,
            unit: "Roentgen",
        };
        this.handleClick = this.handleClick.bind(this);
    }
    
    handleClick() {
        
        if (this.state.unit === "Roentgen") {
            this.setState({
                measures: this.state.measures.map((measure) => {
                    return {
                        measure_datetime: measure.measure_datetime,
                        roentgen_level: toSievert(measure.roentgen_level),
                    };
                }),
                unit: "Sievert",
            });
        } else {
            this.setState({
                measures: this.state.measures.map((measure) => {
                    return {
                        measure_datetime: measure.measure_datetime,
                        roentgen_level: toRoentgen(measure.roentgen_level),
                    };
                }),
                unit: "Roentgen",
            });
        }
        
    }

    render() {
        return (
            <div>
                <h2>Measures</h2>
                <button onClick={this.handleClick}>
                    Switch to {this.state.unit === "Roentgen" ? "Sievert" : "Roentgen"}
                </button>
                <LineChart measures={this.state.measures} />
            </div>
        );
    }
}

interface LineChartProps {
    measures: Measure[];
}

class LineChart extends React.Component<LineChartProps, {}> {
    chartRef = React.createRef<HTMLCanvasElement>();
    chart : Chart;
    
    componentDidUpdate() {
        this.chart.destroy();
        this.buildChart();
    }

    componentDidMount() {
        this.buildChart();
    }

    setState<K extends never>(state: ((prevState: Readonly<{}>, props: Readonly<LineChartProps>) => (Pick<{}, K> | {} | null)) | Pick<{}, K> | {} | null, callback?: () => void) {
        super.setState(state, callback);
    }

    componentWillUnmount() {
        this.chart.destroy();
    }
    
    buildChart = () => {

        let myChartRef : CanvasRenderingContext2D  =
            this.chartRef.current.getContext("2d" );

        let ctx : CanvasRenderingContext2D |string = myChartRef == null ? "" : myChartRef;

        Chart.register(...registerables);

        this.chart = new Chart(ctx, {
            type: "line",
            
            data: {
                //Bring in data
                labels: this.props.measures.map(
                    (measure) => measure.measure_datetime.toLocaleDateString("fr-FR")
                ),
                datasets: [
                    {
                        label: "Roentgen Level",
                        data: this.props.measures.map(
                            (measure) => measure.roentgen_level
                        ),
                        borderColor: 'rgb(75, 192, 192)',
                        backgroundColor:  'rgb(227,38,54)',
                    },
                ],
            },
            options: {
                animations: {
                    tension: {
                        duration: 200,
                        easing: 'linear',
                        from: 1,
                        to: 0,
                        loop: true
                    }
                },
             scales : {}
            }
        });
    };

    render() {
        return <canvas id="myChart" ref={this.chartRef} />;
    }
}

// Create a react version version 18 component in Typescript 4.5.4 , create into the component an array of Measure type called measures, use the librairy chart.js inside the component to render a Line Chart from measures

