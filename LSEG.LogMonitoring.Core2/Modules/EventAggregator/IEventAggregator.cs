namespace LSEG.LogMonitoring.Core.Modules.EventAggregator
{
    public interface IEventAggregator
    {
        void Subscribe<TMessage>(Action<TMessage> handler);
        void Unsubscribe<TMessage>(Action<TMessage> handler);
        void Publish<TMessage>(TMessage message);
    }
}
