import * as React from 'react'
import { Canvas, useThree, extend } from 'react-three-fiber'
import { useLoader} from '@react-three/fiber'
import { a } from '@react-spring/three'


export const Player = () => {
    let ref = React.useRef<any>()
    let mouse = React.useRef({ x: 0, y: 0 })

    return (
        <a.mesh ref={ref} position={[-3, 0, -10]} onClick={() => {ref.current.position.set(mouse.current.x, mouse.current.y, -10)}}>
            <a.boxBufferGeometry attach="geometry" args={[1, 1, 1]} />
            <a.meshBasicMaterial attach="material" color="#ff0000" />
        </a.mesh>
    )
}