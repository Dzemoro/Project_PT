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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.Channel)
                .WithMany(b => b.Measurements);
            modelBuilder.Entity<ConnectorToWire>()
                .HasOne(p => p.Connector)
                .WithMany(b => b.ConnectorsToWires);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.ConnectorT)
                .WithMany(b => b.ConnectorTMeasurements);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.ConnectorR)
                .WithMany(b => b.ConnectorRMeasurements);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.Transmitter)
                .WithMany(b => b.TransmitterMeasurements);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.Receiver)
                .WithMany(b => b.ReceiverMeasurements);
            modelBuilder.Entity<ObstacleAmount>()
                .HasOne(p => p.Measurement)
                .WithMany(b => b.ObstaclesAmount);
            modelBuilder.Entity<ObstacleAmount>()
                .HasOne(p => p.Obstacle)
                .WithMany(b => b.ObstaclesAmount);
            modelBuilder.Entity<WireAttenuation>()
                .HasOne(p => p.Wire)
                .WithMany(b => b.WiresAttenuation);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.WireT)
                .WithMany(b => b.WireTMeasurements);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.WireR)
                .WithMany(b => b.WireRMeasurements);
            modelBuilder.Entity<ConnectorToWire>()
                .HasOne(p => p.Wire)
                .WithMany(b => b.ConnectorsToWires);
        }
    }
}
