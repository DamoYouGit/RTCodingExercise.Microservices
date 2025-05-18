namespace WebMVC.Models
{
    public class ResultsViewModel
    {
        public List<Plate>? Plates { get; set; }
        public List<PlateRecord>? PlateRecords { get; set; }
        public string? QueryString {  get; set; }
        public string? SortBy { get; set; }
        public string? PlatesRevenue { get; set; }
        public string? AverageProfitMargin { get; set; }
        public string? PromoCode { get; set; }
        public int TotalPlates { get; set; }
    }
}
