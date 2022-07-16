using Microsoft.Extensions.DependencyInjection;
namespace EventBus
{
    public class EventBusTest
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IEventBus, EventBus>();
            services.AddSingleton<ICreateOrderService, CreateOrderService>();
            IServiceProvider provider = services.BuildServiceProvider();

            var _eventBus = provider.GetRequiredService<IEventBus>();
            var _craeteOrder = provider.GetRequiredService<ICreateOrderService>();
            OrderEvent e = new OrderEvent()
            {
                orderId = "132",
                amount = 100
            };
            _eventBus.Publish(e);
            Console.ReadLine();
        }
    }
}