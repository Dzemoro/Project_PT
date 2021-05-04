using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;

namespace AppFunctionsLibrary.DAL
{
    public class ConnectorRepository : BaseRepository<Connector>
    {
        public ConnectorRepository(AppDatabaseContext context) : base(context)
        {

        }
    }
}
