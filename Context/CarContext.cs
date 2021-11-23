using CarService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Context
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
        }

        public DbSet<CarPart> CarParts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
