using TexasHoldem.Models;
using TexasHoldem.Models.Services;

namespace ASP.NETCoreWebApplication1.Services;

public class TexasHoldem : GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>>
{
    public TexasHoldem(ILogger<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> logger)
    {
        _logger = logger;
        _players = new List<Player>();
        _bets = new List<Bet>();
        _deck = new CardsDeck ();
        State = TexasHoldemState.Flop;
    }
    
    private static readonly int START_ROUND_CARDS_COUNT = 3; 
    public TexasHoldemState State { get; set; }
    
    internal void NextTurn()
    {
        try
        {
            _deck = _deck?.Shuffle() as CardsDeck;
            _players.Where(x=> !x.Folded).ToList().ForEach(player =>
            {
                try
                {
                    switch (State)
                    {
                        case TexasHoldemState.Flop:
                            player.HeldCards = new CardsDeck(_deck?.DrawCards(START_ROUND_CARDS_COUNT)!);
                            break;
                    }

                }
                catch (InternalPokerGameException e)
                {
                    _logger.LogError(e.Message, e);
                }
            });
        }
        catch (InternalPokerGameException e)
        {
            _logger.LogError(e.Message, e);
        }
    }

    private readonly ILogger<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> _logger;
    private          List<Player>                                                             _players { get; set; }
    private          CardsDeck?                                                               _deck    { get; set; }
    private          IEnumerable<Bet>                                                         _bets    { get; set; }


    public enum TexasHoldemState
    {
        Flop = 0x0A,
        Turn = 0x0B,
        River = 0x0C
    }
}