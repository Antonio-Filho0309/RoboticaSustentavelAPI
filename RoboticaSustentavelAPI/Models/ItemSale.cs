﻿using RoboticaSustentavelAPI.Models.Enum;

namespace RoboticaSustentavelAPI.Models
{
    public class ItemSale
    {
        public ItemSale() {
            
        }

        public ItemSale(int id, int computerId,int saleId,int quantity)
        {
            Id = id;
            ComputerId = computerId;
            SaleId = saleId;
            Quantity = quantity;
            Status = StatusComputer.vendido;
        }

        public ItemSale(int id, int? computerId, int saleId, string? brand, string? cPU,  int quantity)
        {
            Id = id;
            ComputerId = computerId;
            SaleId = saleId;
            Brand = brand;
            CPU = cPU;
            Quantity = quantity;
            Status = StatusComputer.vendido;
        }

        public int Id { get; set; }
        public int? ComputerId { get; set; }
        public Computer Computer { get; set; }
        public string? Brand { get; set; }
        public string? CPU { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public int Quantity { get; set; }
        public  StatusComputer Status { get; set; }
    }
}
