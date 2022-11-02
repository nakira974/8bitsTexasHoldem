import {AssetBase} from "./AssetBase";

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe the family of a card 
 **/
export enum CardType{
    Club = 0x0EAB0A,
    Heart = 0x0EAB0B,
    Spade = 0x0EAB0C,
    Square = 0x0EAB0D,
    Other = 0x0EAB0E
}

/**
 * @description Allowed card types for the Texas Holdem poker
 */
export const AllowedCardTypes : CardType[]  = [
    CardType.Club,
    CardType.Heart,
    CardType.Spade,
    CardType.Square 
];

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe the number of a card
 **/
export enum CardNumber{
    ReverseFace = 0x00,
    Two= 0x02, 
    Three = 0x03,
    Four = 0x04,
    Five= 0x05,
    Six= 0x06,
    Seven = 0x07,
    Height = 0x08,
    Nine= 0x09,
    Ten = 0x0A,
    Jack = 0x0B,
    Queen = 0x0C,
    King = 0x0D,
    Ace = 0X0E,
    Joker = 0XFFFFFFFFFFFF
}

/**
 * @description Allowed card numbers for the Texas Holdem poker
 */
export const AllowedCardNumbers : CardNumber[] = [
    CardNumber.Two,
    CardNumber.Three,
    CardNumber.Four,
    CardNumber.Five,
    CardNumber.Six,
    CardNumber.Seven,
    CardNumber.Height,
    CardNumber.Nine,
    CardNumber.Ten,
    CardNumber.Jack,
    CardNumber.Queen,
    CardNumber.King,
    CardNumber.Ace
]

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe a single card game in the Texas Holdem poker
 **/
export class Card extends AssetBase{

    /**
     * @description Get the family (Ace, Spade...) of the current card
     */
    get family(): CardType {
        return this._family;
    }

    /**
     * @description Get the number (Jack, Ace...) of the current card
     */
    get number(): CardNumber {
        return this._number;
    }
    /**
     * @description Family (Ace, Spade...) of the current card
     */    
    private readonly _family : CardType;
    
    /**
     * @description Number (Jack, Ace...) of the current card
     */
    private readonly _number : CardNumber;
    
    constructor(cardNumber : CardNumber, cardType : CardType) {
        let cardName : string = cardType.toString().toUpperCase()+"_"+cardNumber.toString().toUpperCase();
        let cardFilePath : string = cardName+".png";
        super(cardName, cardFilePath);
        this._family = cardType;
        this._number = cardNumber;
    }
    
}