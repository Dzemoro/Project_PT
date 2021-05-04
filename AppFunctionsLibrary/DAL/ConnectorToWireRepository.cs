using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;

namespace AppFunctionsLibrary.DAL
{
    public class ConnectorToWireRepository : BaseRepository<ConnectorToWire>
    {
        public ConnectorToWireRepository(AppDatabaseContext context) : base(context)
        {

        }
    }
}
