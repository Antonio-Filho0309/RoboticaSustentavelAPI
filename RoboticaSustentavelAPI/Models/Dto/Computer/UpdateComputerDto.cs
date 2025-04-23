using RoboticaSustentavelAPI.Models.Enum;

namespace RoboticaSustentavelAPI.Models.Dto.Computer
{
    public class UpdateComputerDto
    {
        public int Id { get; set; }
        public StatusComputer Status { get; set; }
    }
}
