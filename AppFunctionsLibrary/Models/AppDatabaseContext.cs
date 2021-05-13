using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options) { }

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
