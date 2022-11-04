using System.ComponentModel;
using ASP.NETCoreWebApplication1.Data;
using ASP.NETCoreWebApplication1.Models;
using ASP.NETCoreWebApplication1.Services;
using Duende.IdentityServer.EntityFramework.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASP.NETCoreWebApplication1.Hubs;

[DisplayName("Texas_Holdem_Hub")]
public class TexasHoldemHub : Hub
{
    private readonly ILogger<TexasHoldemHub> _logger;
    private readonly TexasHoldemService? _texasHoldemService;
    private readonly IOptions<TexasHoldemConfiguration> _configuration;
    private readonly ApplicationDbContext _applicationDbContext;
    private IEnumerable<IPokerGameService<IPokerGameService<TexasHoldem>>.Player?> Players { get; set; }

    public TexasHoldemHub(IGameService<IPokerGameService<IPokerGameService<TexasHoldem>>> texasHoldemService, ILogger<TexasHoldemHub> logger, ApplicationDbContext applicationDbContext)
    {
        _texasHoldemService = texasHoldemService as TexasHoldemService;
        _logger = logger;
        _applicationDbContext = applicationDbContext;
        Players = new List<IPokerGameService<IPokerGameService<TexasHoldem>>.Player?>();
    }


    public override Task OnConnectedAsync()
    {
        try
        {
            Players.ToList().Add(new IPokerGameService<IPokerGameService<TexasHoldem>>.Player(connectionId:Context.ConnectionId));
        }
        catch (Exception e)
        {
            _logger.LogError($"Error on connection, client {Context.ConnectionId} has been aborted");
            Context.Abort();
        }
        
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        try
        {
            Players.ToList().Remove(Players.FirstOrDefault(x => x != null && x.ConnectionId.Equals(Context.ConnectionId)));
        }
        catch (Exception e)
        {
            _logger.LogError($"Error on connection, client {Context.ConnectionId} has been aborted");
            Context.Abort();
        }
        return base.OnDisconnectedAsync(exception);
    }


    public async Task SetUserInfo(int userId)
    {
        try
        {
            var storedPlayer =  await _applicationDbContext.Players.Include(player => player.User).Where(x=>x.Id.Equals(userId)).FirstOrDefaultAsync();
            var currentPlayer= Players.Where(x => x != null && x.ConnectionId.Equals(Context.ConnectionId)).Select(x => x).FirstOrDefault();
            var index = Players.ToList().IndexOf(currentPlayer!);
            Players.ToList()[index] = index != -1 ? storedPlayer : throw new ArgumentException($"Player {Context.ConnectionId} doesn't exists in the hub's player list");
        }
        catch (Exception e)
        {
            _logger.LogError($"Error on sending user {Context.ConnectionId} information");
            Context.Abort();
        }
    }
}