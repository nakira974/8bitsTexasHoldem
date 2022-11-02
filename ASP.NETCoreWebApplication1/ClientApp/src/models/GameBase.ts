import {Guid} from "guid-typescript";

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe a Game and all associated properties and methods such as start(), stop()...
 **/
export abstract class GameBase {
    set turn(value: number) {
        this._turn = value;
    }

    set playerCount(value: number) {
        this._playerCount = value;
    }

    /**
     * @description Get the current name of the GameBase instance
     */
    get name(): string {
        return this._name;
    }

    /**
     * @description Get the current round number of the GameBase instance
     */
    get turn(): number {
        return this._turn;
    }

    /**
     * @description Get the current player count of the GameBase instance
     */
    get playerCount(): number {
        return this._playerCount;
    }

    /**
     * @description Get the maximum player count allowed for the current GameBase instance
     */
    get maximumPlayerCount(): number {
        return this._maximumPlayerCount;
    }
    
    protected constructor(namePrefix : string , maximumAllowedPlayerCount : number) {
        this._maximumPlayerCount = maximumAllowedPlayerCount;
        this._turn = 0;
        this._name = namePrefix+"_"+Guid.create().toString();
    }
    /**
     * @description Name of the GameBase instance
     */
    private readonly _name : string;

    /**
     * @description Current turn of the game
     */
    private _turn : number;

    /**
     * @description Current player count of the game
     */
    private _playerCount : number;

    /**
     * @description Maximum players allowed for a single game
     */
    private _maximumPlayerCount: number;

    /**
     * @description Starts the next round of the game
     */
    public abstract nextTurn();

    /**
     * @description Starts the current instance and launch the game
     */
    public abstract start();

    /**
     * @description Suspends the game for a determined duration.
     * @param duration : number Game suspension time in seconds
     */
    public abstract suspend(duration : number);

    /**
     * @description Stops the game without finishing the game, in case of player abandonment or disconnection
     */
    public abstract stop();

    /**
     * @description Ends the game by following the rules of the game
     */
    public abstract end();
    
}