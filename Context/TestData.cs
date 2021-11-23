using CarService.Models;
using System;
using System.Linq;

namespace CarService.Context
{
    public static class TestData
    {
        public static void Initialize(CarContext context)
        {
            context.Database.EnsureCreated();

            if (context.CarParts.Any())
            {
                return;   // DB has been initialized
            }

            var parts = new CarPart[]
            {
                new CarPart{CarPartName="Alternator", CarPartManufactureDate=DateTime.Parse("2018-03-06")},
                new CarPart{CarPartName="Crankshaft", CarPartManufactureDate=DateTime.Parse("2015-03-16")},
                new CarPart{CarPartName="Piston", CarPartManufactureDate=DateTime.Parse("2021-01-30")}
            };
            foreach (CarPart p in parts)
            {
                context.CarParts.Add(p);
            }
            context.SaveChanges();

            var manufacturers = new Manufacturer[]
            {
                new Manufacturer{ManufacturerName="PartsRUs"},
                new Manufacturer{ManufacturerName="OffBrand"}
            };
            foreach (Manufacturer m in manufacturers)
            {
                context.Manufacturers.Add(m);
            }
            context.SaveChanges();
        }
    }
}