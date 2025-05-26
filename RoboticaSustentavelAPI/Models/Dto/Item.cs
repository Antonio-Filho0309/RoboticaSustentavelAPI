namespace RoboticaSustentavelAPI.Models.Dto
{
    public class Item
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? CPU { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; } 
    }
}
