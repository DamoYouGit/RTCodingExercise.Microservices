using Catalog.API.Interfaces;

namespace Catalog.API.Services
{
    public class PlateRepository : IPlateRepository
    {
        private ApplicationDbContext _context;
        public PlateRepository(ApplicationDbContext context) { _context = context; }
        public async Task AddPlate(Plate plate)
        {
            var exists = _context.Plates.Where(x => x.Registration == plate.Registration).Any();

            if (exists)
            {
                return;

            }
            await _context.Plates.AddAsync(plate);
            _context.SaveChanges();
        }

        public List<PlateRecord> GetAllPlates()
        {
            //// this needs to be deleted 
            //foreach (var item in _context.Plates )
            //{
            //    if (item.Sold)
            //    {
            //        item.Sold = false;
            //    }
                
            //}
            //_context.SaveChanges();
            return _context.Plates.Where(x => x.Sold == false).Select(x => 
            new PlateRecord {
                Id = x.Id,
                Letters = x.Letters,
                Numbers = x.Numbers,
                Registration = x.Registration,
                SalePrice = x.SalePrice,
                PurchasePrice = x.PurchasePrice,
                Sold = x.Sold,
                Reserved = x.Reserved
            }).ToList();
        }

        public List<PlateRecord> GetPlates(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) 
            {

                return _context.Plates.Where(x => x.Sold == false).Select(x =>
                    new PlateRecord
                    {
                        Id = x.Id,
                        Letters = x.Letters,
                        Numbers = x.Numbers,
                        Registration = x.Registration,
                        SalePrice = Math.Round(x.SalePrice, 2),
                        PurchasePrice = Math.Round( x.PurchasePrice, 2),
                        Sold = x.Sold,
                        Reserved = x.Reserved

                    }).ToList();
            }

            List<Plate> plates = new List<Plate>();
            //check if characters are greater than 3 if so search for name
            if(searchText.Length > 3)
            {
                //_context.Plates.FindAsync(x 
                //search 
                //return ;
                plates.AddRange(_context.Plates.Where(x => x.Registration.StartsWith(searchText.Substring(0, 3)) && x.Sold == false).ToList());
                plates.AddRange(_context.Plates.Where(x => x.Registration.EndsWith(searchText.Substring(0, 3)) && x.Sold == false).ToList());

                plates.AddRange(_context.Plates.Where(x => x.Letters.Contains(searchText.Substring(0, 3)) && x.Sold == false).ToList());



            }
            else
            {
                plates.AddRange(_context.Plates.Where(x => x.Registration.Contains(searchText) && x.Sold == false).ToList());
                plates.AddRange(_context.Plates.Where(x => x.Letters.Contains(searchText) && x.Sold == false).ToList());
                var numbersOnly = searchText.All(c => char.IsDigit(c));
                if (numbersOnly)
                {
                    plates.AddRange(_context.Plates.Where(x => x.Numbers == int.Parse(searchText) && x.Sold == false).ToList());
                }
        
            }

       

            return plates.Distinct().Select(x => 
            new PlateRecord { 
                Id = x.Id,
                Letters = x.Letters,
                Numbers = x.Numbers,
                Registration = x.Registration,
                SalePrice = Math.Round(x.SalePrice, 2),
                PurchasePrice = Math.Round(x.PurchasePrice, 2),
                Sold = x.Sold,
                Reserved = x.Reserved

            }).ToList();

        }

        public decimal GetPlatesRevenue()
        {
           var result =  _context.Plates.Where(x => x.Sold == true).Select(x => x.SalePrice).ToList();
            return Math.Round(result.Sum()) ;

        }

        public decimal GetProfitMargin()
        {
            List<decimal> profitContainer = new List<decimal>();
            var soldPlates = _context.Plates.Where(x => x.Sold == true).ToList();

            if (!soldPlates.Any()) 
            {
                return Math.Round(0.00m);
            }
            else
            {
                foreach (var item in soldPlates)
                {
                    profitContainer.Add(item.SalePrice - item.PurchasePrice);
                }
                return Math.Round(profitContainer.Sum() / profitContainer.Count());
            }

        }

        public PlateRecord GetSoldPlate(string reg)
        {
            return _context.Plates.Where(x => x.Registration == reg && x.Sold == true).Select(x => new PlateRecord
            {
                Id = x.Id,
                Letters = x.Letters,
                Numbers = x.Numbers,
                Registration = x.Registration,
                SalePrice = Math.Round( x.SalePrice, 2),
                PurchasePrice = Math.Round( x.PurchasePrice, 2),
                Sold = x.Sold,
                Reserved = x.Reserved

            }).FirstOrDefault();
        }

        public async Task UpdateReservationStatus(string reg)
        {
            var result = _context.Plates.SingleOrDefault(x => x.Registration == reg);

            if (result != null) 
            {
                

                if (result.Reserved)
                {
                    result.Reserved = false;
                    var log = new ReservationLog
                    {   Id = new Guid(), 
                        Registration = reg,
                        IsReserved = false,
                        CreatedOn = DateTime.UtcNow
                    };
                    await _context.ReservationLogs.AddAsync(log);
                }
                else 
                {
                    result.Reserved = true;
                    var log = new ReservationLog
                    {   Id = new Guid(), 
                        Registration = reg,
                        IsReserved = false,
                        CreatedOn = DateTime.UtcNow
                    };
                    await _context.ReservationLogs.AddAsync(log);
                }
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task UpdateSoldStatus(string reg)
        {
            var result = _context.Plates.SingleOrDefault(x => x.Registration == reg);

            result.Sold = true;
            await _context.SaveChangesAsync();
            
        }
    }
}
