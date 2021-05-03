using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    [Table("Wires")]
    public class Wire
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }

        public List<WireAttenuation> WiresAttenuation { get; set; }
        public List<Measurement> WireTMeasurements { get; set; }
        public List<Measurement> WireRMeasurements { get; set; }
        public List<ConnectorToWire> ConnectorsToWires { get; set; }
    }
}
