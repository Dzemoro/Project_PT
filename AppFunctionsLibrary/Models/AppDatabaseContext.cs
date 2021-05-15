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
                .WithMany(b => b.Measurements)
                .HasForeignKey(p => p.channel_id);
            modelBuilder.Entity<ConnectorToWire>()
                .HasOne(p => p.Connector)
                .WithMany(b => b.ConnectorsToWires)
                .HasForeignKey(p => p.connector_id)
                .HasForeignKey(b => b.wire_id);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.ConnectorT)
                .WithMany(b => b.ConnectorTMeasurements)
                .HasForeignKey(p => p.connectorT_id);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.ConnectorR)
                .WithMany(b => b.ConnectorRMeasurements)
                .HasForeignKey(p => p.connectorR_id);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.Transmitter)
                .WithMany(b => b.TransmitterMeasurements)
                .HasForeignKey(p => p.transmitter_id);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.Receiver)
                .WithMany(b => b.ReceiverMeasurements)
                .HasForeignKey(p => p.receiver_id);
            modelBuilder.Entity<ObstacleAmount>()
                .HasOne(p => p.Measurement)
                .WithMany(b => b.ObstaclesAmount)
                .HasForeignKey(p => p.measurements_id);
            modelBuilder.Entity<ObstacleAmount>()
                .HasOne(p => p.Obstacle)
                .WithMany(b => b.ObstaclesAmount)
                .HasForeignKey(p => p.obstacles_id);
            modelBuilder.Entity<WireAttenuation>()
                .HasOne(p => p.Wire)
                .WithMany(b => b.WiresAttenuation)
                .HasForeignKey(p => p.wire_id);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.WireT)
                .WithMany(b => b.WireTMeasurements)
                .HasForeignKey(p => p.wireT_id);
            modelBuilder.Entity<Measurement>()
                .HasOne(p => p.WireR)
                .WithMany(b => b.WireRMeasurements)
                .HasForeignKey(p => p.wireR_id);
            modelBuilder.Entity<ConnectorToWire>()
                .HasOne(p => p.Wire)
                .WithMany(b => b.ConnectorsToWires)
                .HasForeignKey(p => p.wire_id);
        }
    }
}
