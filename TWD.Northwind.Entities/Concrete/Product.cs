using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TWD.Core.Entities;

namespace TWD.Northwind.Entities.Concrete
{
    //Devart Entity generation tools
    public class Product : IEntity
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public short UnitsInStock { get; set; }
    }
}
