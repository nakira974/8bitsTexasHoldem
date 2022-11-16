import {Guid} from "guid-typescript";
import * as signalR from "@microsoft/signalr";
import {HubConnection, HubConnectionState, IHttpConnectionOptions, ILogger, LogLevel} from "@microsoft/signalr";
import {ConsoleLogger} from "@microsoft/signalr/dist/esm/Utils";
import authService from '../components/api-authorization/AuthorizeService'

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe a Game and all associated properties and methods such as start(), stop()...
 **/
export abstract class GameBase {

    public logger : ILogger;
    /**
     * @description Get the current round count of the game
     */
    set turn(value: number) {
        this._turn = value;
    }

    /**
     * @description Get the current player count of the game
     */
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

    /**
     * @description Default constructor of an GameBase instance
     * @param namePrefix : string Prefix of the instance name
     * @param maximumAllowedPlayerCount : number Maximum player count allowed for a single game
     */
    protected  constructor(namePrefix: string, maximumAllowedPlayerCount: number) {
        this._maximumPlayerCount = maximumAllowedPlayerCount;
        this._turn = 0;
        this._name = namePrefix + "_" + Guid.create().toString();
        let url: string = "https://localhost:7129/api/hubs/" + namePrefix;
        this.logger = new ConsoleLogger(signalR.LogLevel.Debug);
        let token :string = "";
        

        const options: IHttpConnectionOptions = {
            accessTokenFactory: () => {
                return authService.getAccessToken().then(t=> token = t);
            },
            headers:{
                "Access-Control-Allow-Origin": "*", 
                "User-Agent": "React-SignalR-Client", 
                "Connection": "keep-alive"
            },
            transport: signalR.HttpTransportType.WebSockets,
            logMessageContent: true,
            httpClient: new HttpClientFactory(this.logger, namePrefix),
            logger : this.logger,
            withCredentials : true,
            skipNegotiation : true
        };
        
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(url,options)
            .configureLogging(this.logger)
            .build();

        // Starts the SignalR connection
        this.hubConnection.start()
            .then(r=> this.logger.log(LogLevel.Debug, "User is now connected to '"+namePrefix+"' hub"))
            .catch((err) => this.logger.log(LogLevel.Critical, `Error while starting connection: ${err}`));
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
    private readonly _maximumPlayerCount: number;

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

    /**
     * @description SignalR connection to the Game's Hub
     */
    public readonly hubConnection : HubConnection;
    
}

class HttpClientFactory extends signalR.DefaultHttpClient {
    
    private readonly _hubName : string;
    
    public send(request: signalR.HttpRequest): Promise<signalR.HttpResponse> {
        //request.headers = { ...request.headers, "Access-Control-Allow-Origin": "http://localhost:7129/api/hubs/"+this._hubName };
        return super.send(request);
    }

    constructor(logger: ILogger, hubName : string) {
        super(logger);
        this._hubName = hubName;
    }
    
    
}