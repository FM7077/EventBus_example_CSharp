namespace EventBus
{
    // 事件处理接口
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        void Handle(TEvent e);
    }
}