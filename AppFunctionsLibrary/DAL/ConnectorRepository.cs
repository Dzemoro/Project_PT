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

        public Connector GetConnector(int id)
        {
            return dbSet.SingleOrDefault(x => x.id == id);
        }
        public Connector GetConnectorByName(string name)
        {
            return dbSet.SingleOrDefault(x => x.name == name);
        }
        public List<Connector> GetAllConnectors()
        {
            return dbSet.ToList();
        }
    }
}
