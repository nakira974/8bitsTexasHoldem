import * as React from 'react'
import {Canvas, extend} from 'react-three-fiber'
import {a} from '@react-spring/three'
import Card from "./Card";
import {CardFamily} from "../../scripts/CardFamily";
import {CardNumber} from "../../scripts/CardNumber";
import {Player} from "./Player";


extend({ Card }) // define the component as a custom element to be used in the scene graph

export default function Casino() {

    return( 
        <Canvas>
            <pointLight distance={40} intensity={8}/>
            <pointLight position={[20, 70, 50]} distance={1000}/>
            <pointLight position={[-20, -70, -50]} distance={1000}/>

            <Player/>
            
            <Card cardFamily={CardFamily.Club} cardNumber={CardNumber.Ace}/>
            <Card cardFamily={CardFamily.Spade} cardNumber={CardNumber.Eight}/>
            <Card cardFamily={CardFamily.Diamond} cardNumber={CardNumber.Four}/>
            
            <mesh >
                <sprite scale={[10, 10, 1]}>
                    <a.sprite scale={[3,3,1]} material-map={"url(casino.ase)"}/>
                </sprite>
            </mesh>
        </Canvas>
    )
}
