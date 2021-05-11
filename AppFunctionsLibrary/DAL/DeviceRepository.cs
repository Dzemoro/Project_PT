using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;

namespace AppFunctionsLibrary.DAL
{
    public class DeviceRepository : BaseRepository<Device>
    {
        public DeviceRepository(AppDatabaseContext context) : base(context)
        {

        }
        public Device GetDevice(int id)
        {
            return dbSet.SingleOrDefault(x => x.id == id);
        }
    }
}
