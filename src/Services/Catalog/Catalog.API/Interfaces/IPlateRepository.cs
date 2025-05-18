namespace Catalog.API.Interfaces
{
    public interface IPlateRepository
    {
        public Task AddPlate(Plate plate);
        public List<PlateRecord> GetAllPlates();
        public List<PlateRecord> GetPlates(string searchText);
        public Task UpdateReservationStatus(string reg);
        public decimal GetPlatesRevenue();
        public Task UpdateSoldStatus(string reg);
        public decimal GetProfitMargin();
        public PlateRecord? GetSoldPlate(string reg);
    }
}
