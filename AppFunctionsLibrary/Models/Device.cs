using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    [Table("Devices")]
    public class Device
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("power")]
        public float power { get; set; }
        [Column("gain")]
        public float gain { get; set; }

        public List<Measurement> TransmitterMeasurements { get; set; }
        public List<Measurement> ReceiverMeasurements { get; set; }
    }
}
