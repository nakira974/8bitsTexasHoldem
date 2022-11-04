namespace ASP.NETCoreWebApplication1.Services;

internal sealed class TexasHoldemService : IPokerGameService<TexasHoldem>
{
    public TexasHoldemService(ILogger<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> logger)
    {
        _logger = logger;
        GameServicesImplementation = this;
        Game = new TexasHoldem(_logger);
    }

    public GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> Game { get; init; }

    public IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>> GameServicesImplementation { get; }

    private readonly ILogger<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> _logger;

    public GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> Start()
    {
        try
        {
            return Game;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            throw;
        }
    }

    public async Task<GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>>> StartAsync()
    {
        try
        {
            return Game;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            throw;
        }
    }

    public GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> Suspend(double time)
    {
        try
        {
            return Game;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            throw;
        }
    }

    public async Task<GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>>>
        SuspendAsync(double time)
    {
        try
        {
            return Game;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            throw;
        }
    }

    public GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>> Finish()
    {
        try
        {
            return Game;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            throw;
        }
    }

    public async Task<GameBase<IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>>>> FinishAsync()
    {
        try
        {
            return Game;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            throw;
        }
    }
}