using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;

namespace AppFunctionsLibrary.DAL
{
    public class WireAttenuationRepository : BaseRepository<WireAttenuation>
    {
        public WireAttenuationRepository(AppDatabaseContext context) : base(context)
        {

        }
    }
}
