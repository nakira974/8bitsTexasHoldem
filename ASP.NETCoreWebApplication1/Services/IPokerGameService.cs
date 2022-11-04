using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASP.NETCoreWebApplication1.Services;

internal interface IPokerGameService<T> : IGameService<IPokerGameService<IPokerGameService<T>>>
{
    IGameService<IPokerGameService<IPokerGameService<T>>> GameServicesImplementation { get; }

    public new GameBase<IGameService<IPokerGameService<IPokerGameService<T>>>> Start()
    {
        return GameServicesImplementation.Start();
    }

    public new async Task<GameBase<IGameService<IPokerGameService<IPokerGameService<T>>>>> StartAsync()
    {
        return await GameServicesImplementation.StartAsync();
    }

    public new GameBase<IGameService<IPokerGameService<IPokerGameService<T>>>> Suspend(double time)
    {
        return GameServicesImplementation.Suspend(time);
    }

    public new async Task<GameBase<IGameService<IPokerGameService<IPokerGameService<T>>>>> SuspendAsync(double time)
    {
        return await GameServicesImplementation.SuspendAsync(time);
    }

    public new GameBase<IGameService<IPokerGameService<IPokerGameService<T>>>> Finish()
    {
        return GameServicesImplementation.Finish();
    }

    public new async Task<GameBase<IGameService<IPokerGameService<IPokerGameService<T>>>>> FinishAsync()
    {
        return await GameServicesImplementation.FinishAsync();
    }


    internal enum CardNumber
    {
        /** Reversed side of cards */
        ReverseFace = 0x00,

        /**@description Two is a playing card value
     * @see https://fr.wikipedia.org/wiki/Deux_(carte_%C3%A0_jouer)*/
        Two = 0x02,

        /**@description Three is a playing card value
     * @see https://fr.wikipedia.org/wiki/Trois_(carte_%C3%A0_jouer)*/
        Three = 0x03,

        /**@description Four is a playing card value
     * @see https://fr.wikipedia.org/wiki/Quatre_(carte_%C3%A0_jouer)*/
        Four = 0x04,

        /**@description Five is a playing card value
     * @see https://fr.wikipedia.org/wiki/Cinq_(carte_%C3%A0_jouer)*/
        Five = 0x05,

        /**@description Six is a playing card value
     * @see https://fr.wikipedia.org/wiki/Six_(carte_%C3%A0_jouer)*/
        Six = 0x06,

        /**@description Seven is a playing card value
     * @see https://fr.wikipedia.org/wiki/Sept_(carte_%C3%A0_jouer)*/
        Seven = 0x07,

        /**@description Height is a playing card value
     * @see https://fr.wikipedia.org/wiki/Huit_(carte_%C3%A0_jouer)*/
        Height = 0x08,

        /**@description Nine is a playing card value
     * @see https://fr.wikipedia.org/wiki/Neuf_(carte_%C3%A0_jouer)*/
        Nine = 0x09,

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
        Joker = 1
    }

    /**
 * @author nakira974
 * @version 1.0.0
 * @description Describe the family of a card 
 **/
    internal enum CardType
    {
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

    internal sealed record Card
    {
        [JsonPropertyName("family")] internal CardType Family { get; init; }

        [JsonPropertyName("number")] internal CardNumber Number { get; init; }

        internal Card(CardType family, CardNumber number)
        {
           Family = family;
           Number = number;
        }
    }

    internal class CardsDeck : List<Card>
    {
       internal static readonly int MAXIMUM_DISTRIBUABLE_CARDS = 3;
       
       
       public CardsDeck(IEnumerable<Card> collection) : base(collection)
       {
       }
       
       public CardsDeck()
       {
          var cardTypes = Enum.GetValues(typeof(CardType));
          var cardNumbers = Enum.GetValues(typeof(CardNumber));

          foreach (CardType cardType in cardTypes)
          {
             foreach (CardNumber cardNumber in cardNumbers)
             {
                Add(new Card(cardType,cardNumber));
             }
          }
       }
       
       
       internal IEnumerable<Card> DrawCards(int cardsCount)
       {
          try
          {
             cardsCount = cardsCount >= MAXIMUM_DISTRIBUABLE_CARDS ? throw new TooManyCardsDealtException(cardsCount) : cardsCount;
             return this.OrderBy(x => Guid.NewGuid()).Take(cardsCount).ToList();
          }
          catch (TooManyCardsDealtException e)
          {
             throw new InternalPokerGameException("Deck failed to drawn cards", e);
          }
       }

       public CardsDeck? Shuffle()
       {
          return this.OrderBy(x => Guid.NewGuid()).Take(this.Count).ToList() as CardsDeck;
       }
       
    }

    internal sealed record Bet
    {
       internal Bet(){}
       
       internal Bet(double threshold, double amount, Player gambler)
       {
          Amount = !(amount.Equals(0)) && (amount>=threshold) ? amount : throw new BetBelowThresholdException(threshold, amount, gambler);
          Gambler = gambler;
       }

       [JsonPropertyName("bet_id")]internal int Id { get; init; }
       [JsonPropertyName("amount")] internal Double Amount { get; init; }
       [JsonPropertyName("player")] internal Player Gambler { get; init; }
    }

    internal sealed record Player
    {
       internal Player() {}
       
       [JsonPropertyName("user_id")] internal int Id { get; init; }
       [JsonPropertyName("username")] internal string UserName { get; init; }
       [JsonPropertyName("held_cards")] internal IEnumerable<Card> HeldCards { get; set; }
       [JsonPropertyName("folded")] internal bool Folded { get; set; }
    }

    internal class BetBelowThresholdException : Exception
    {
       internal BetBelowThresholdException(double threshold, double amount, Player player) : base($"Player:{player.Id} has placed a bet:{amount}$ below the threshold:{threshold}$")
       {
       }
    }
    
    internal class TooManyCardsDealtException : Exception
    {
       public TooManyCardsDealtException(int cardsCount) : base($"Too many cards dealt {cardsCount} for Texas Holdem the limit is {CardsDeck.MAXIMUM_DISTRIBUABLE_CARDS}")
       {
       }
    }

    internal class InternalPokerGameException : Exception
    {
       public InternalPokerGameException(string? message, Exception? innerException) : base(message, innerException)
       {
       }
    }
    
}