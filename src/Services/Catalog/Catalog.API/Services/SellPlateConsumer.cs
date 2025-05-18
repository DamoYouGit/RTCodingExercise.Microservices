using Catalog.API.Interfaces;
using IntegrationEvents;
using MassTransit;

namespace Catalog.API.Services
{
    public class SellPlateConsumer : IConsumer<SendRegistrationEvent>
    {
        private IPlateRepository _repo;
        public SellPlateConsumer(IPlateRepository repo) { _repo = repo; }
      
        public async  Task Consume(ConsumeContext<SendRegistrationEvent> context)
        {
            await _repo.UpdateSoldStatus(context.Message.Registration);
        }
    }
}
