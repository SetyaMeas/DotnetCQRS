namespace CQRS
{
    public interface IEventHandler<TEvent>
        where TEvent : IEvent
    {
        Task HandleAsync(TEvent tevent, CancellationToken cancellationToken = default);
    }
}
