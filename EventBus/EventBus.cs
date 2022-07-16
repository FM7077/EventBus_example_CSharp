using System.Collections.Generic;
namespace EventBus
{
    public class EventBus : IEventBus
    {
        readonly Dictionary<Type, List<Object>> _handlerDictionary;
        private readonly object _publishLock = new object();

        public EventBus()
        {
            _handlerDictionary = new Dictionary<Type, List<object>>();
        }

        void IEventBus.Subscribe<TEvent>(IEventHandler<TEvent> eventHandler)
        {
            if(null == eventHandler) throw new Exception("Can not subscribe null eventHandler");

            var eType = typeof(TEvent);

            List<object> handlers;

            lock(_handlerDictionary)
            {
                if(!_handlerDictionary.TryGetValue(eType, out handlers))
                {
                    handlers = new List<object>();

                    _handlerDictionary.Add(eType, handlers);
                }
            }

            lock(handlers)
            {
                handlers.Add(eventHandler);
            }
        }

        Task IEventBus.Publish<TEvent>(TEvent e)
        {
            lock(_publishLock)
            {
                var publishModel = new DealPublishModel(_handlerDictionary);
                return publishModel.Publish(e);
            }
        }
    }
}