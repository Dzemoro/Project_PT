using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;

namespace AppFunctionsLibrary.DAL
{
    public class ObstacleRepository : BaseRepository<Obstacle>
    {
        public ObstacleRepository(AppDatabaseContext context) : base(context)
        {

        }
    }
}
