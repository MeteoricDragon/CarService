using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class CarPart
    {
        public int ID { get; set; }
        public string CarPartName { get; set; }
        public DateTime CarPartManufactureDate { get; set; }
        public string ManufacturerID { get; set; }
    }
}
