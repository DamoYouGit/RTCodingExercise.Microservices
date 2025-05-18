using IntegrationEvents;

namespace WebMVC.Services
{
    public interface IProducerService
    {
        public Task<bool> ReservePlate(string reg);
        public Task<bool> UnreservePlate(string reg);
        public Task<bool> AddPlate(Sample evt);
        public Task<bool> SellPlate(string reg);
        
    }
}
