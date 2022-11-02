import {GameBase} from "./GameBase";


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

    /**
     * @description Default constructor of Texas Holdem game
     * @param maximumAllowedPlayerCount : number Maximum number of players allowed to play together in the game
     */
    constructor(maximumAllowedPlayerCount: number) {
        super("Texas_Holdem", maximumAllowedPlayerCount);
        
    }
    
}