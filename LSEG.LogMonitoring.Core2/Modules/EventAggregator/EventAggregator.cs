namespace LSEG.LogMonitoring.Core.Modules.EventAggregator
{
    /// <summary>
    /// A lightweight publish-subscribe event aggregator that allows
    /// decoupled communication between components
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, List<Delegate>> _subscriptions = new();

        /// <summary>
        /// Subscribes a handler to a specific message type.
        /// </summary>
        /// <typeparam name="TMessage">The type of message to subscribe to</typeparam>
        /// <param name="handler">The action to invoke when the message is published</param>
        public void Subscribe<TMessage>(Action<TMessage> handler)
        {
            var type = typeof(TMessage);
            if (!_subscriptions.ContainsKey(type))
                _subscriptions[type] = new List<Delegate>();

            _subscriptions[type].Add(handler);
        }

        /// <summary>
        /// Unsubscribes a previously subscribed handler for a specific message type
        /// </summary>
        /// <typeparam name="TMessage">The type of message to unsubscribe from</typeparam>
        /// <param name="handler">The handler to remove</param>
        public void Unsubscribe<TMessage>(Action<TMessage> handler)
        {
            var type = typeof(TMessage);
            if (_subscriptions.ContainsKey(type))
                _subscriptions[type].Remove(handler);
        }

        /// <summary>
        /// Publishes a message to all registered subscribers of that message type
        /// </summary>
        /// <typeparam name="TMessage">The type of the message to publish</typeparam>
        /// <param name="message">The message instance to publish</param>
        public void Publish<TMessage>(TMessage message)
        {
            var type = typeof(TMessage);
            if (_subscriptions.ContainsKey(type))
            {
                foreach (var handler in _subscriptions[type].OfType<Action<TMessage>>())
                {
                    handler.Invoke(message);
                }
            }
        }
    }
}
