import {AssetBase} from "./AssetBase";

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe the family of a card 
 **/
export enum CardType{
    Club = "Club",
    Heart = "Heart",
    Spade = "Spade",
    Square = "Square",
   Other = "Other"
}

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
 * @author nakira974
 * @version 1.0.0
 * @description Describe a card game
 **/
export class Card extends AssetBase{
    constructor(cardNumber : CardNumber, cardType : CardType) {
        let cardName : string = cardType.toString()+"_"+cardNumber.toString();
        let cardFilePath : string = cardName+".png";
        super(cardName, cardFilePath);
    }
    
}