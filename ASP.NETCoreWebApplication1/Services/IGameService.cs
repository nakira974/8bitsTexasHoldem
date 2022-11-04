using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace ASP.NETCoreWebApplication1.Services;

public interface IGameService<T>
{
    public GameBase<IGameService<T>> Start();

    public Task<GameBase<IGameService<T>>> StartAsync();

    public GameBase<IGameService<T>> Suspend(Double time);

    public Task<GameBase<IGameService<T>>> SuspendAsync(Double time);

    public GameBase<IGameService<T>> Finish();

    public Task<GameBase<IGameService<T>>> FinishAsync();

}