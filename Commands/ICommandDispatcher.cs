namespace CQRS
{
    public interface ICommandDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(
            ICommand<TResult> command,
            CancellationToken cancellationToken = default
        );
    }
}
