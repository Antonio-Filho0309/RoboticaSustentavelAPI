namespace RoboticaSustentavelAPI.Models.Dto.Computer
{
    public class UpdateComputerDto
    {
        public string? Brand { get; set; }

        public string CPU { get; set; }
        public string Processor { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public int Quantity { get; set; }
    }
}
