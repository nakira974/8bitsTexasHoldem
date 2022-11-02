import {GameBase} from "./GameBase";
import { Guid } from "guid-typescript";


/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe a poker 'Texas Holdem' game
 **/
export class TexasHoldem extends GameBase{
    end() {
    }

    nextTurn() {
    }

    start() {
    }

    stop() {
    }

    suspend(duration: number) {
    }
    constructor(maximumAllowedPlayerCount: number) {
        super("Texas_Holdem", maximumAllowedPlayerCount);
        
    }
    
}