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
        public Measurement GetMeasurement(int id) {
            return dbSet.SingleOrDefault(x => x.id == id);
        }
        public Measurement GetMeasurementeByName(string name) {
            return dbSet.SingleOrDefault(x => x.name == name);
        }
        public List<Measurement> GetAllMeasurements() {
            return dbSet.ToList();
        }
        public bool AddMeasurement(Measurement m) {
            Insert(m);
            //dbSet.Add(m);
            return true;
        }
    }
}
