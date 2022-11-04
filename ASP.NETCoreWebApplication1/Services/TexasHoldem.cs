namespace ASP.NETCoreWebApplication1.Services;

internal class TexasHoldem : GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>>
{
    private static readonly int START_ROUND_CARDS_COUNT = 3; 
    public TexasHoldem(ILogger<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> logger)
    {
        _logger = logger;
        _players = new List<IPokerGameService<IPokerGameService<TexasHoldem>>.Player>();
        _bets = new List<IPokerGameService<IPokerGameService<TexasHoldem>>.Bet>();
        _deck = new IPokerGameService<IPokerGameService<TexasHoldem>>.CardsDeck ();
    }

    internal void NextTurn()
    {
        try
        {
            _deck = _deck?.Shuffle();
            _players.ToList().ForEach(player =>
            {
                try
                {
                    player.HeldCards = _deck?.DrawCards(START_ROUND_CARDS_COUNT)!;

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
    
}