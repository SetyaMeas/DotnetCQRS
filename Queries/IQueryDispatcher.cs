namespace CQRS
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(
            IQuery<TResult> query,
            CancellationToken cancellationToken = default
        );
    }
}
