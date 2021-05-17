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
        public Wire GetWire(int id)
        {
            return dbSet.SingleOrDefault(x => x.id == id);
        }
        public Wire GetWireByName(string name)
        {
            return dbSet.SingleOrDefault(x => x.name == name);
        }
        public List<Wire> GetAllWires()
        {
            return dbSet.ToList();
        }

    }
}
