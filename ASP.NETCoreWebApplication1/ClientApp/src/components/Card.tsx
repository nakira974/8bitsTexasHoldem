import * as React from 'react'
import {CardFamily} from "../../scripts/CardFamily";
import {CardNumber} from "../../scripts/CardNumber";
import {MathUtils} from "three";
import { useLoader,useFrame } from '@react-three/fiber';
import { a } from '@react-spring/three'

export type CardProps = { cardFamily:CardFamily,cardNumber:CardNumber }
export type CardState = { isFlipped:boolean}

export default class Card extends React.Component<CardProps,CardState> {

    constructor(props:any){
        super(props);
        this.state = {isFlipped:false}
        this.handleClick = this.handleClick.bind(this)

        //@ts-ignore
        const cardAsset = `${this.props.cardFamily}_${this.props.cardNumber}.ase`;


    }

    handleClick() {
        this.setState((state) => ({isFlipped : !state.isFlipped}))
    }

    render() {

        const cardAsset = `${this.props.cardFamily}_${this.props.cardNumber}.ase`;

        return (  <group onClick={ this.handleClick }>
            <mesh position={[0, 0, 0]} rotation={[0, MathUtils.degToRad(-90), 0]} castShadow receiveShadow >
                <sprite scale={[10, 10, 1]}>
                    <a.sprite key={"key-"+MathUtils.generateUUID()} name="aseprite" scale={[3,3,1]} material-map={"url(" + cardAsset + ")"}/>
                </sprite>
            </mesh>
        </group> )
    }


}