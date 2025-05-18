using Catalog.API.Interfaces;
using IntegrationEvents;
using MassTransit;

namespace Catalog.API.Services
{
    public class AddPlateConsumer : IConsumer<Sample>
    {
        private IPlateRepository _repo;
        public AddPlateConsumer(IPlateRepository repo) { _repo = repo; }
        public async Task Consume(ConsumeContext<Sample> context)
        {
            //interface to add records
            await _repo.AddPlate(new Plate
            {
                Registration = context.Message.Registration,
                Numbers = context.Message.Numbers,
                Letters = context.Message.Letters,
                PurchasePrice = context.Message.PurchasePrice,
                SalePrice = context.Message.SalePrice,
       
            });

           
        }
    }
}
