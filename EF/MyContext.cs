using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.EF
{
    public class MyContext : DbContext
    {
        public DbSet<Kupac> Kupac { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=BazaKupacaDB;Trusted_Connection=False;MultipleActiveResultSets=true;User ID=CommanderAPI; Password=Emachines1992;");
        }
    }
}