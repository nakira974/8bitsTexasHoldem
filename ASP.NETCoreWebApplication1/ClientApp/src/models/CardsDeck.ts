import {AssetBase} from "./AssetBase";
import {Card, CardNumber, CardType} from "./Card";

/**
 * @author nakira974
 * @version 1.0.0
 * @description Describe a game cards deck with all associated operations such as sort() or deal()
 **/
export class CardsDeck extends AssetBase{
    get cards(): Card[] {
        return this._cards;
    }

    /**
     * @description Game cards collection
     */
    private readonly _cards : Card[];
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