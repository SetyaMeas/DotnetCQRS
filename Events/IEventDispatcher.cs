namespace CQRS
{
    public interface IEventDispatcher
    {
        Task DispatchAsync(IEvent ievent, CancellationToken cancellationToken = default);
    }
}
