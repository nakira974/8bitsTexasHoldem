import { OrbitControls, OrthographicCamera } from "@react-three/drei"
import { Canvas, useFrame, useLoader } from "@react-three/fiber"
import { useControls } from "leva"
import { Suspense, useRef } from "react"
import * as THREE from "three"
// @ts-ignore
import bard from "./resources/HEART_ACE.png"
// @ts-ignore
import texture02 from "./resources/OTHER_REVERSEFACE.png"
import {Texture} from "three";
import {CardsDeck} from "../models/CardsDeck";



const TexturedQuad = ({ scale, position }) => {
    let deck = new CardsDeck("CARDS_DECK", "./resources/OTHER_CARDSDECK.png")

    const group = useRef()

    let front_side_texture: Texture = useLoader(THREE.TextureLoader, bard) as Texture;
    let back_side_texture : Texture= useLoader(THREE.TextureLoader, texture02) as Texture

    back_side_texture.minFilter = THREE.NearestFilter
    back_side_texture.magFilter = THREE.NearestFilter
    front_side_texture.minFilter = THREE.NearestFilter
    front_side_texture.magFilter = THREE.NearestFilter
    
    const [{ rotationSpeed, sides, filter }, set] = useControls(() => ({
        rotationSpeed: {
            value: 0.01,
            min: 0.0,
            max: 0.1,
            step: 0.01,
        },
        sides: {
            value: THREE.DoubleSide,
            options: {
                "front side": THREE.FrontSide,
                "back side": THREE.BackSide,
                "both sides": THREE.DoubleSide,
            },
        },
        filter: {
            value: THREE.NearestFilter,
            options: {
                "nearest-neighbour": THREE.NearestFilter,
                bilinear: THREE.LinearFilter,
            },
        },
        
    }))

    useFrame(() => {
        back_side_texture.magFilter = filter
        back_side_texture.minFilter = filter
        back_side_texture.needsUpdate = true
        front_side_texture.magFilter = filter
        front_side_texture.minFilter = filter
        front_side_texture.needsUpdate = true

        if (group.current) {
            // @ts-ignore
            group.current.rotation.y += rotationSpeed
        }
    })

    return (
        <group ref={group}>

            {sides ==  THREE.DoubleSide  &&

                <>
                    <mesh position={[0.5, 0, -0.5]}>
                        <planeBufferGeometry attach="geometry" args={[1, 1]}/>
                        <meshBasicMaterial side={THREE.FrontSide} transparent={true} attach="material"
                                           map={front_side_texture}/>
                    </mesh>
                    <mesh position={[0.5, 0, -0.5]}>
                        <planeBufferGeometry attach="geometry" args={[1, 1]}/>
                        <meshBasicMaterial side={THREE.BackSide} transparent={true} attach="material"
                                           map={back_side_texture}/>
                    </mesh>
                    <mesh position={[-0.5, 0, 0.5]}>
                        <planeBufferGeometry attach="geometry" args={[1, 1]}/>
                        <meshBasicMaterial side={THREE.FrontSide} transparent={true} attach="material"
                                           map={front_side_texture}/>
                    </mesh>
                    <mesh position={[-0.5, 0, 0.5]}>
                        <planeBufferGeometry attach="geometry" args={[1, 1]}/>
                        <meshBasicMaterial side={THREE.BackSide} transparent={true} attach="material"
                                           map={back_side_texture}/>
                    </mesh>
                </>
            }

            {sides ==  THREE.FrontSide &&
                <>
                    <mesh position={[0.5, 0, -0.5]}>
                        <planeBufferGeometry attach="geometry" args={[1, 1]}/>
                        <meshBasicMaterial side={THREE.FrontSide} transparent={true} attach="material"
                                           map={front_side_texture}/>
                    </mesh>
                    <mesh position={[-0.5, 0, 0.5]}>
                        <planeBufferGeometry attach="geometry" args={[1, 1]}/>
                        <meshBasicMaterial side={THREE.FrontSide} transparent={true} attach="material"
                                           map={front_side_texture}/>
                    </mesh>
                </>
            }

            {sides ==  THREE.BackSide &&
                <>
                    <mesh position={[0.5, 0, -0.5]}>
                        <planeBufferGeometry attach="geometry" args={[1, 1]}/>
                        <meshBasicMaterial side={THREE.BackSide} transparent={true} attach="material"
                                           map={back_side_texture}/>
                    </mesh>
                    <mesh position={[-0.5, 0, 0.5]}>
                        <planeBufferGeometry attach="geometry" args={[1, 1]}/>
                        <meshBasicMaterial side={THREE.BackSide} transparent={true} attach="material"
                                           map={back_side_texture}/>
                    </mesh>
                </>
            }
            
            <sprite position={[-0.5, 0, -0.5]}>
                <spriteMaterial transparent={true} map={front_side_texture} />
            </sprite>
            <sprite position={[0.5, 0, 0.5]}>
                <spriteMaterial transparent={true} map={front_side_texture} />
            </sprite>
        </group>
    )
}

function Room() {
    return (
        <>
            <TexturedQuad scale={[1, 1, 1]} position={undefined}  />
        </>
    )
}

export default function App() {
    return (
        <Canvas>
            <color attach="background" args={["black"]} />
            {/* <Sky azimuth={1} inclination={0.1} distance={1000} /> */}
            <OrthographicCamera makeDefault position={[0, 1.5, 5]} zoom={200} />
            <ambientLight intensity={0.1} />
            <pointLight position={[10, 10, 10]} />
            <Suspense fallback={null}>
                <Room />
            </Suspense>
            <OrbitControls minPolarAngle={Math.PI / 10} maxPolarAngle={Math.PI / 1.5} />
        </Canvas>
    )
}
