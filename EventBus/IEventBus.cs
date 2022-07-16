namespace EventBus
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;
        Task Publish<TEvent>(TEvent e) where TEvent : IEvent;
    }
}