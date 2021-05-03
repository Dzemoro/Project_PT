using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    [Table("Channels")]
    public class Channel
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("number")]
        public int number { get; set; }
        [Column("band")]
        public int band { get; set; }
        [Column("frequency")]
        public int frequency { get; set; }

        public List<Measurement> Measurements { get; set; }
    }
}
