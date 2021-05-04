using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    [Table("Measurements")]
    public class Measurement
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("distance")]
        public float distance { get; set; }
        [Column("transmitter_id")]
        public int transmitter_id { get; set; }
        [Column("receiver_id")]
        public int receiver_id { get; set; }
        [Column("channel_id")]
        public int channel_id { get; set; }
        [Column("wireT_id")]
        public int wireT_id { get; set; }
        [Column("wireR_id")]
        public int wireR_id { get; set; }
        [Column("connectorT_id")]
        public int connectorT_id { get; set; }
        [Column("connectorR_id")]
        public int connectorR_id { get; set; }

        public List<ObstacleAmount> ObstaclesAmount { get; set; }
        public Device Transmitter { get; set; }
        public Device Receiver { get; set; }
        public Channel Channel { get; set; }
        public Wire WireT { get; set; }
        public Wire WireR { get; set; }
        public Connector ConnectorT { get; set; }
        public Connector ConnectorR { get; set; }
    }
}
