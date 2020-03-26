using System.Threading.Tasks;

namespace Core.RabbitMq.Modules
{
    public interface IModuleHandle
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        Task PublishEvent(EventBusArgs e);
        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        Task SubscribeEvent(EventBusArgs e);
    }
}
