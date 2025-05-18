using Catalog.API.Interfaces;
using IntegrationEvents;
using MassTransit;

namespace Catalog.API.Services
{
    public class UnreservePlateConsumer : IConsumer<ReservationProducer>
    {
        private IPlateRepository _repo;
        public UnreservePlateConsumer(IPlateRepository repo) { _repo = repo; }
      
        public async Task Consume(ConsumeContext<ReservationProducer> context)
        {
            await _repo.UpdateReservationStatus(context.Message.Registration);
        }
    }
}
