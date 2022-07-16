namespace EventBus
{
    public class OrderEvent : IEvent
    {
        public string orderId {get; set;}
        public int amount {get; set;}
    }
}