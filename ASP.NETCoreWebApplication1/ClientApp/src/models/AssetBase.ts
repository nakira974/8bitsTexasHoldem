import {Guid} from "guid-typescript";


/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe an Asset and all associated properties and methods
 **/
export abstract class AssetBase{
    
    /**
     * @description Name of the AssetBase instance
     */
    private readonly _name : string;

    /**
     * @description File path of the AssetBase instance
     */
    private readonly _path : string;

    protected constructor(name: string, path: string) {
        this._name = name+"_"+Guid.create().toString();
        this._path = path;
    }
}