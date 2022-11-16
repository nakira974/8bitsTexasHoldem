import {GameBase} from "./GameBase";
import {CardsDeck} from "./CardsDeck";
import {HubConnectionState, LogLevel} from "@microsoft/signalr";


/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe a poker 'Texas Holdem' game
 * @see https://fr.wikipedia.org/wiki/Poker
 **/
export class TexasHoldem extends GameBase{
    
    public readonly deck : CardsDeck;
    
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
        this.deck = new CardsDeck("Texas_Holdem_Deck", "./resources/OTHER_CARDSDECK.png");
        
        this.hubConnection.send("SetUserInfo", "0d0a96c0-14cd-421b-8313-0ec874761d70")
            .then(r => this.logger.log(LogLevel.Debug, "Player has set info into game's hub"))
            .catch((err) => this.logger.log(LogLevel.Critical, `Error while sending user info connection: ${err}`));
        
    }
    
}