﻿import { Sprite } from 'three';
import { useRef } from 'react';
import { useAnimatedSprite } from 'use-animated-sprite';
import * as ThreeFiber from 'react-three-fiber'

export function MySprite () {

    const spriteRef = useRef<Sprite>();
    const texture = useAnimatedSprite(spriteRef, {
        spriteSheetUrl: `C:\\Users\\maxim\\Pictures\\télécharger.png`, // Required - The path or full URL to the sprite sheet
        xCount: 40, // Required - the number of sprites along the X axis the spritesheet is divided into
        yCount: 32, // Required - the number of sprites along the Y axis the spritesheet is divided into
        spriteFrames: 4, // Required - the number of frames for this sprite
        spriteX: 20, // Required - the start x position of this sprite (not pixels, but number of sprites from "left")
        spriteY: 10, // Required - the start y position of this sprite (not pixels, but the number of sprites from "bottom")

        // One of interval or intervalFunc are required
        interval: 0.5, // Optional - the number of seconds between sprite frames

        // Optional - a function returning a number to use for the next interval between sprite frames
        intervalFunc: () => {
            return (300 + Math.random() * 500) / 1000;
        }
    })

    return (
        <sprite ref={spriteRef}>
            <spriteMaterial map={texture} />
        </sprite>
    )
}