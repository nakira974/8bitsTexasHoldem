import {AssetBase} from "./AssetBase";

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe the family of a card 
 **/
export enum CardType{
    
    /**@description The club (♣) is a playing card sign, one of four French signs with heart, tile and spade.
     * @see https://fr.wikipedia.org/wiki/Tr%C3%A8fle_(carte_%C3%A0_jouer)*/
    Club = 0x0EAB0A,
    
    /**@description The heart (♥) is a playing card sign, one of the four French signs with spade, tile and clover.
     * @see https://fr.wikipedia.org/wiki/C%C5%93ur_(carte_%C3%A0_jouer)*/
    Heart = 0x0EAB0B,
    
   /** @description The spade (♠) is a playing card sign, one of the four French signs with heart, tile and clover.
    * @see https://fr.wikipedia.org/wiki/Pique_(carte_%C3%A0_jouer)*/
   Spade = 0x0EAB0C,
    
    /**@description The diamond (♦) is a playing card sign, one of four French signs with spades, hearts and clubs.
     * @see https://fr.wikipedia.org/wiki/Carreau_(carte_%C3%A0_jouer)*/
    Diamond = 0x0EAB0D,
    
    /**Cards like reversed side or the joker*/ 
    Other = 0x0EAB0E
}

/**
 * @description Allowed card types for the Texas Holdem poker
 */
export const AllowedCardTypes : CardType[]  = [
    CardType.Club,
    CardType.Heart,
    CardType.Spade,
    CardType.Diamond 
];

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe the number of a card
 **/
export enum CardNumber{
    
    /** Reversed side of cards */
    ReverseFace = 0x00,
    
    /**@description Two is a playing card value
     * @see https://fr.wikipedia.org/wiki/Deux_(carte_%C3%A0_jouer)*/
    Two= 0x02,
    
    /**@description Three is a playing card value
     * @see https://fr.wikipedia.org/wiki/Trois_(carte_%C3%A0_jouer)*/
    Three = 0x03,
    
    /**@description Four is a playing card value
     * @see https://fr.wikipedia.org/wiki/Quatre_(carte_%C3%A0_jouer)*/
    Four = 0x04,
    
    /**@description Five is a playing card value
     * @see https://fr.wikipedia.org/wiki/Cinq_(carte_%C3%A0_jouer)*/
    Five= 0x05,
    
    /**@description Six is a playing card value
     * @see https://fr.wikipedia.org/wiki/Six_(carte_%C3%A0_jouer)*/
    Six= 0x06,
    
    /**@description Seven is a playing card value
     * @see https://fr.wikipedia.org/wiki/Sept_(carte_%C3%A0_jouer)*/
    Seven = 0x07,
    
    /**@description Height is a playing card value
     * @see https://fr.wikipedia.org/wiki/Huit_(carte_%C3%A0_jouer)*/
    Height = 0x08,
    
    /**@description Nine is a playing card value
     * @see https://fr.wikipedia.org/wiki/Neuf_(carte_%C3%A0_jouer)*/
    Nine= 0x09,
    
    /**@description Ten is a playing card value
     * @see https://fr.wikipedia.org/wiki/Dix_(carte_%C3%A0_jouer)*/
    Ten = 0x0A,
    
    /**@description The valet is a playing card figure. Usually representing a young man, it is often the weakest figure
     * @see https://fr.wikipedia.org/wiki/Valet_(carte_%C3%A0_jouer)*/
    Jack = 0x0B,
    
    /**@description The lady or queen is a playing card figure, usually representing a noble woman
     * @see https://fr.wikipedia.org/wiki/Dame_(carte_%C3%A0_jouer)*/
    Queen = 0x0C,
    
    /**@description The king is a playing card figure, usually representing a noble man
     * @see https://fr.wikipedia.org/wiki/Roi_(carte_%C3%A0_jouer)*/
    King = 0x0D,
    
    /**@description The ace is a playing card value, corresponding to the number 1
     * @see https://fr.wikipedia.org/wiki/As_(carte_%C3%A0_jouer)*/
    Ace = 0X0E,
    
    /**@description The joker is a «generic» card capable of representing one of the other playing cards
     * @see https://fr.wikipedia.org/wiki/Joker_(carte_%C3%A0_jouer)*/
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
 * @see https://fr.wikipedia.org/wiki/Carte_%C3%A0_jouer
 **/
export class Card extends AssetBase{

    /**
     * @description Get the family (Club, Spade...) of the current card
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
     * @description Family (Club, Spade...) of the current card
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