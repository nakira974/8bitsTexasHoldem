import {Guid} from "guid-typescript";


/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe an Asset and all associated properties and methods
 **/
export abstract class AssetBase{

    /**
     * @description Get the name of the AssetBase instance
     */
    get name(): string {
        return this._name;
    }

    /**
     * @description Get the file path of the AssetBase instance
     */
    get path(): string {
        return this._path;
    }
    
    /**
     * @description Name of the AssetBase instance
     */
    private readonly _name : string;

    /**
     * @description File path of the AssetBase instance
     */
    private readonly _path : string;

    /**
     * @description Default constructor of an AssetBase instance
     * @param name : string Instance name
     * @param path : string Asset file path
     */
    protected constructor(name: string, path: string) {
        this._name = name+"_"+Guid.create().toString();
        this._path = path;
    }
}