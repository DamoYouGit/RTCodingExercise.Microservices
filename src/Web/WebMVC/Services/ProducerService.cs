using IntegrationEvents;
using MassTransit;

namespace WebMVC.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public ProducerService(IPublishEndpoint publishEndpoint) 
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> AddPlate(Sample evt)
        {
            await _publishEndpoint.Publish(evt);
            return true;
        }

        public async Task<bool> ReservePlate(string reg)
        {
            ReservationProducer producer = new ReservationProducer
            {
                Registration = reg
            };
            await _publishEndpoint.Publish(producer);
            return true;
        }

        public async Task<bool> UnreservePlate(string reg)
        {
            ReservationProducer producer = new ReservationProducer
            {
                Registration = reg
            };
            await _publishEndpoint.Publish(producer);
            return true;
        }

        public async Task<bool> SellPlate(string reg)
        {
            SendRegistrationEvent evt = new SendRegistrationEvent
            {
                Registration = reg
            };
            await _publishEndpoint.Publish(evt);
            return true;
        }
    }
}
