using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    [Table("Connectors")]
    public class Connector
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("attenuation")]
        public float attenuation { get; set; }

        public List<ConnectorToWire> ConnectorsToWires { get; set; }
        public List<Measurement> ConnectorTMeasurements { get; set; }
        public List<Measurement> ConnectorRMeasurements { get; set; }
    }
}
