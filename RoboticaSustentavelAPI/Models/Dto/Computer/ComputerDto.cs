﻿using RoboticaSustentavelAPI.Models.Enum;

namespace RoboticaSustentavelAPI.Models.Dto.Computer
{
    public class ComputerDto
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string CPU { get; set; }
        public string Ram { get; set; }
        public string Storage { get; set; }
        public StatusComputer Status { get; set; }
        public int Quantity { get; set; }
    }
}
