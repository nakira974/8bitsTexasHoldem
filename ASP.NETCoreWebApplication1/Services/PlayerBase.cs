namespace ASP.NETCoreWebApplication1.Services;

public abstract class PlayerBase<T>
{
    internal string ConnectionId { get; init; }

    internal PlayerBase(string connectionId)
    {
        ConnectionId = connectionId;
    }
}