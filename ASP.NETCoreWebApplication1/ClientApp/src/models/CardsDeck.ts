import {AssetBase} from "./AssetBase";
import {Card, CardNumber, CardType} from "./Card";

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe a game cards deck with all associated operations such as sort() or deal()
 **/
export class CardsDeck extends AssetBase{

    /**
     * @description Get the current game cards collection
     */
    get cards(): Card[] {
        return this._cards;
    }

    /**
     * @description Game cards collection
     */
    private readonly _cards : Card[];

    /**
     * @description Default constructor of a game cards deck
     * @param name : string Name of the current instance
     * @param path : string File path to the game cards deck asset
     */
    constructor(name: string, path: string) {
        
        super(name, path);

        for (const cardType in CardType) {
            const currentCardType: CardType = CardType[cardType as keyof typeof CardType];
            for(const cardNumber in CardNumber){
                const currentCardNumber: CardNumber = CardNumber[cardNumber as keyof typeof CardNumber];
                this._cards.push(new Card(currentCardNumber, currentCardType));
            }
        }
    }

    /**
     * @description Sort game cards in the current deck
     */
    public sort(){
        
    }
}