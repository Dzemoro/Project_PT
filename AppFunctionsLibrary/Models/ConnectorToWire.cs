using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    [Table("ConnectorsToWires")]
    public class ConnectorToWire
    {
        [Column("wire_id")]
        public int wire_id { get; set; }
        [Column("connector_id")]
        public int connector_id { get; set; }

        public Wire Wire { get; set; }
        public Connector Connector { get; set; }
    }
}
