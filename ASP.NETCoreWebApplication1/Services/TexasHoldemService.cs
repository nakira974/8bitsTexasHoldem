using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Protocol;
using TexasHoldem.Models;
using TexasHoldem.Models.Services;

namespace ASP.NETCoreWebApplication1.Services;

public sealed class TexasHoldemService : PokerServiceBase<TexasHoldem>
{
    public TexasHoldemService(ILogger<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>> logger)
    {
        _logger = logger;
        GameServicesImplementation = this;
        Game = new TexasHoldem(_logger);
    }

    public TexasHoldem Game { get; init; }

    public IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>> GameServicesImplementation { get; }

    private readonly ILogger<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>> _logger;

    public GameBase<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>> Start()
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

    public async Task<GameBase<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>>> StartAsync()
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

    public GameBase<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>> Suspend(double time)
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

    public async Task<GameBase<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>>>
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

    public GameBase<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>> Finish()
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

    public async Task<GameBase<IGameService<PokerServiceBase<PokerServiceBase<TexasHoldem>>>>> FinishAsync()
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