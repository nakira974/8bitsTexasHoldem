using System.ComponentModel;
using ASP.NETCoreWebApplication1.Models;
using ASP.NETCoreWebApplication1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TexasHoldem.Models;
using TexasHoldem.Models.Services;

namespace ASP.NETCoreWebApplication1.Controllers;

[Authorize()]
[Produces("application/json")]
[ApiController]
[Route("api/controllers/[controller]")]
[DisplayName("Texas_Holdem")]
internal class TexasHoldemController : ControllerBase
{
    private readonly ILogger<TexasHoldemController>                                           _logger;
    private readonly IOptions<TexasHoldemConfiguration>                                       _configuration;
    private readonly IGameService<PokerServiceBase<PokerServiceBase<Services.TexasHoldem>>> _pokerGameService;

    public TexasHoldemController(ILogger<TexasHoldemController> logger, IOptions<TexasHoldemConfiguration> configuration, IGameService<PokerServiceBase<PokerServiceBase<Services.TexasHoldem>>> pokerGameService)
    {
        _logger = logger;
        _configuration = configuration;
        _pokerGameService = pokerGameService;
    }
    
    
}