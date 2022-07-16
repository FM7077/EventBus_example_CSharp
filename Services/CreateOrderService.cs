namespace EventBus
{
    public class CreateOrderService : ICreateOrderService
    {
        public CreateOrderService(IEventBus _eventBus)
        {
            _eventBus.Subscribe(this);
        }

        public void Handle(OrderEvent e)
        {
            Console.WriteLine($"Handling order: id: {e.orderId}, amount: {e.amount}");
        }
    }
}