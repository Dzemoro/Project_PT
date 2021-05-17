using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFunctionsLibrary.Models
{
    [Table("Obstacles")]
    public class Obstacle
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("attenuation_24")]
        public float attenuation_24 { get; set; }
        [Column("attenuation_5")]
        public float attenuation_5 { get; set; }

        public List<ObstacleAmount> ObstaclesAmount { get; set; }
    }
}
