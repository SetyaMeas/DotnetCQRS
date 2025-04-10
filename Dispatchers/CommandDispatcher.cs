using Microsoft.Extensions.DependencyInjection;

namespace CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<TResult> DispatchAsync<TResult>(
            ICommand<TResult> command,
            CancellationToken cancellationToken = default
        )
        {
            var handler = serviceProvider.GetRequiredService<
                ICommandHandler<ICommand<TResult>, TResult>
            >();
            return handler.HandleAsync(command, cancellationToken);
        }
    }
}
