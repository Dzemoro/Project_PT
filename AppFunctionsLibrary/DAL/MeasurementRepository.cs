using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;

namespace AppFunctionsLibrary.DAL
{
    public class MeasurementRepository : BaseRepository<Measurement>
    {
        public MeasurementRepository(AppDatabaseContext context) : base(context)
        {

        }
    }
}
