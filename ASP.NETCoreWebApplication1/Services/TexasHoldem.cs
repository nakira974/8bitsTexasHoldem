using TexasHoldem.Models;
using TexasHoldem.Models.Services;

namespace ASP.NETCoreWebApplication1.Services
{
    public class TexasHoldem : GameBase<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>>
    {
        public TexasHoldem(ILogger<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>> logger)
        {
            _logger  = logger;
            _players = new List<Player>();
            _bets    = new List<Bet>();
            _deck    = new CardsDeck ();
            State    = TexasHoldemState.Flop;
        }
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
                                                                       player.HeldCards = State switch
                                                                           {
                                                                               TexasHoldemState.Flop =>
                                                                                   new CardsDeck(_deck?.DrawCards(CardsDeck.MAXIMUM_DISTRIBUABLE_CARDS)!),
                                                                               TexasHoldemState.River =>
                                                                                   new CardsDeck(_deck?.DrawCards(CardsDeck.MINIMUM_DISTRIBUABLE_CARDS)!),
                                                                               TexasHoldemState.Turn =>
                                                                                   new CardsDeck(_deck?.DrawCards(CardsDeck.MINIMUM_DISTRIBUABLE_CARDS)!),
                                                                               _ => player.HeldCards
                                                                           };
                                                                   }
                                                                   catch (InternalPokerGameException e)
                                                                   {
                                                                       // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
                                                                       _logger.LogError($"Error while dealing cards for player {player.UserName}", e);
                                                                   }
                                                               });
            }
            catch (InternalPokerGameException e)
            {
                // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
                _logger.LogError(e.Message, e);
            }
        }

        private readonly ILogger<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>> _logger;
        private          List<Player>                                                             _players { get; set; }
        private          CardsDeck?                                                               _deck    { get; set; }
        private          IEnumerable<Bet>                                                         _bets    { get; set; }


        public enum TexasHoldemState
        {
            Flop  = 0x0A,
            Turn  = 0x0B,
            River = 0x0C
        }
    }
}


