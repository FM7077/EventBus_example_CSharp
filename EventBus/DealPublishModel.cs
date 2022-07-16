using System.Threading.Tasks;
namespace EventBus
{
    // 在内存中开辟新空间处理事件
    public class DealPublishModel
    {
        private readonly Dictionary<Type, List<Object>> _handlerDictionary;
        public DealPublishModel(Dictionary<Type, List<Object>> handlerDictionary)
        {
            _handlerDictionary = handlerDictionary;
        }
        public Task Publish<TEvent>(TEvent e) where TEvent : IEvent
        {
            return Task.Run(() => 
            {
                if(null == e) throw new System.Exception("Cannot process null event");

                var eType = typeof(TEvent);

                if(!_handlerDictionary.TryGetValue(eType, out var handlers))
                {
                    return;
                }

                foreach (var handler in handlers)
                {
                    Task.Run(() => 
                    {
                        (handler as IEventHandler<TEvent>).Handle(e);
                    });
                }
            });
        }
    }
}