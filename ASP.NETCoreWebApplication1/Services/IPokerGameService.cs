using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ASP.NETCoreWebApplication1.Models;
using Microsoft.AspNetCore.SignalR;

namespace ASP.NETCoreWebApplication1.Services;

public interface IPokerGameService<T> : IGameService<IPokerGameService<IPokerGameService<T>>>
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

    public new async Task<bool> DisconnectAsync(HubConnectionContext hubConnectionContext)
    {
       return await GameServicesImplementation.DisconnectAsync(hubConnectionContext);
    }
    


    internal enum CardNumber
    {
       Two = 0x02,
       Three = 0x03,
       Four = 0x04,
       Five = 0x05,
       Six = 0x06,
       Seven = 0x07,
       Height = 0x08,
       Nine = 0x09,
       Ten = 0x0A,
       Jack = 0x0B,
       Queen = 0x0C,
       King = 0x0D,
       Ace = 0X0E,
    }


    internal enum CardType
    {
       Club = 0x0EAB0A,
        Heart = 0x0EAB0B,
        Spade = 0x0EAB0C,
        Diamond = 0x0EAB0D,
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

    public sealed record Player
    {
       internal Player() {}

       internal Player(string connectionId)
       {
          ConnectionId = connectionId;
       }
       
       [JsonPropertyName("application_user")] internal ApplicationUser User { get; set; }
       
       [NotMapped]
       [JsonPropertyName("connection_id")] internal string ConnectionId { get; set; }
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