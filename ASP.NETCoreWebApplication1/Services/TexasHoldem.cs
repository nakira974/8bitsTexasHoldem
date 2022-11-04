namespace ASP.NETCoreWebApplication1.Services;

public class TexasHoldem : GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>>
{
    public TexasHoldem(ILogger<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> logger)
    {
        _logger = logger;
        _players = new List<IPokerGameService<IPokerGameService<TexasHoldem>>.Player>();
        _bets = new List<IPokerGameService<IPokerGameService<TexasHoldem>>.Bet>();
        _deck = new IPokerGameService<IPokerGameService<TexasHoldem>>.CardsDeck ();
        State = TexasHoldemState.Flop;
    }
    
    private static readonly int START_ROUND_CARDS_COUNT = 3; 
    public TexasHoldemState State { get; set; }
    
    internal void NextTurn()
    {
        try
        {
            _deck = _deck?.Shuffle();
            _players.Where(x=> !x.Folded).ToList().ForEach(player =>
            {
                try
                {
                    switch (State)
                    {
                        case TexasHoldemState.Flop:
                            player.HeldCards = new IPokerGameService<IPokerGameService<TexasHoldem>>.CardsDeck(_deck?.DrawCards(START_ROUND_CARDS_COUNT)!);
                            break;
                    }

                }
                catch (IPokerGameService<IPokerGameService<TexasHoldem>>.InternalPokerGameException e)
                {
                    _logger.LogError(e.Message, e);
                }
            });
        }
        catch (IPokerGameService<IPokerGameService<TexasHoldem>>.InternalPokerGameException e)
        {
            _logger.LogError(e.Message, e);
        }
    }

    private readonly ILogger<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> _logger;
    private IEnumerable<IPokerGameService<IPokerGameService<TexasHoldem>>.Player> _players { get; set; }
    private IPokerGameService<IPokerGameService<TexasHoldem>>.CardsDeck? _deck { get; set; }
    private IEnumerable<IPokerGameService<IPokerGameService<TexasHoldem>>.Bet> _bets { get; set; }


    public enum TexasHoldemState
    {
        Flop = 0x0A,
        Turn = 0x0B,
        River = 0x0C
    }
}