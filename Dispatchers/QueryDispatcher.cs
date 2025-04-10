using Microsoft.Extensions.DependencyInjection;

namespace CQRS
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<TResult> DispatchAsync<TResult>(
            IQuery<TResult> query,
            CancellationToken cancellationToken = default
        )
        {
            var handler = serviceProvider.GetRequiredService<
                IQueryHandler<IQuery<TResult>, TResult>
            >();
            return handler.HandleAsync(query, cancellationToken);
        }
    }
}
