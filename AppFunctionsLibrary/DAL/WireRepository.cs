using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;

namespace AppFunctionsLibrary.DAL
{
    public class WireRepository : BaseRepository<Wire>
    {
        public WireRepository(AppDatabaseContext context) : base(context)
        {

        }
    }
}
