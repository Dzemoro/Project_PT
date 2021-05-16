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
        public List<ConnectorToWire> GetAllConnectorsToWires()
        {
            return dbSet.ToList();
        }
        public List<ConnectorToWire> GetByWire(int wire_id)
        {
            return dbSet.Where(x => x.wire_id == wire_id).ToList();
        }
        public List<ConnectorToWire> GetByConnector(int connector_id)
        {
            return dbSet.Where(x => x.connector_id == connector_id).ToList();
        }
    }
}
