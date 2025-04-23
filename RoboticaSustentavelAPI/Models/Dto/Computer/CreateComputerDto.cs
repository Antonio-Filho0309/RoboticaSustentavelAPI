namespace RoboticaSustentavelAPI.Models.Dto.Computer
{
    public class CreateComputerDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public string CPU { get; set; }
        public int Quantity { get; set; }
    }
}
