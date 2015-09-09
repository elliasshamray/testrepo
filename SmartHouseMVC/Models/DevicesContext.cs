using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Models.SmartHouseMVC
{
    public class DevicesContext : DbContext
    {
        static DevicesContext()
        {
            Database.SetInitializer<DevicesContext>(new DevicesDbInitializer());
        }
        public DbSet<Lamp> lamps { get; set; }
        public DbSet<TV> tvsets { get; set; }
        public DbSet<Louvers> louvers { get; set; }
        public DbSet<Heating> heatings { get; set; }
        public DbSet<Boiler> boilers { get; set; }
    }
}