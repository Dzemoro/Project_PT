using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    [Table("WiresAttenuation")]
    public class WireAttenuation
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("frequency")]
        public float frequency { get; set; }
        [Column("value")]
        public float value { get; set; }

    }
}
