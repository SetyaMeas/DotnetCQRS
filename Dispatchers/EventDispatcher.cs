using Microsoft.Extensions.DependencyInjection;

namespace CQRS
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task DispatchAsync(IEvent ievent, CancellationToken cancellationToken = default)
        {
            var handler = serviceProvider.GetRequiredService<IEventHandler<IEvent>>();
            return handler.HandleAsync(ievent, cancellationToken);
        }
    }
}
