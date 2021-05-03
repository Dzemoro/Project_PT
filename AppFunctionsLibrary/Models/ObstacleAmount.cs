using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    [Table("ObstaclesAmount")]
    public class ObstacleAmount
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("amount")]
        public int amount { get; set; }
        [Column("obstacles_id")]
        public int obstacles_id { get; set; }
        [Column("measurements_id")]
        public int measurements_id { get; set; }

        public Obstacle Obstacle { get; set; }
        public Measurement Measurement { get; set; }
    }
}
