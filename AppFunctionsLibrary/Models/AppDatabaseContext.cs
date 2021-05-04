using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;

namespace AppFunctionsLibrary.Models
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext() : base("name=AppDatabaseContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<Connector> Connectors { get; set; }
        public DbSet<ConnectorToWire> ConnectorsToWires { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Obstacle> Obstacles { get; set; }
        public DbSet<ObstacleAmount> ObstaclesAmount { get; set; }
        public DbSet<Wire> Wires { get; set; }
        public DbSet<WireAttenuation> WiresAttenuation { get; set; }
    }
}
