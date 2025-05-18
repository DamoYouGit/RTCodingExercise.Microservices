using Catalog.API.Interfaces;
using IntegrationEvents;
using MassTransit;

namespace Catalog.API.Services
{
    public class ReservePlateConsumer : IConsumer<ReservationProducer>
    {
        private IPlateRepository _repo;
        public ReservePlateConsumer(IPlateRepository repo) { _repo = repo; }
        
        
        public async Task Consume(ConsumeContext<ReservationProducer> context)
        {
            await _repo.UpdateReservationStatus(context.Message.Registration);
        }
    }
}
