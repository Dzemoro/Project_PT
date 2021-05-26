using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;
using AppFunctionsLibrary.DAL;

namespace AppGUI {
    class MeasurementManager {
        public MeasurementRepository rep { get; set; }

        public MeasurementManager(AppDatabaseContext context) {
            this.rep = new MeasurementRepository(context);
        }

        public bool AddMeasurement(Measurement m) {
            this.rep.Insert(m);
            rep.Commit();

            return true;
        }
        public bool DeleteMeasurement() { return false; }
        public bool UpdateMeasurement() { return false; }
        public Measurement GetMeasurementByName(string name) {
            return this.rep.GetMeasurementeByName(name);
        }
        public List<Measurement> GetMeasurements() {
            return this.rep.GetAllMeasurements();
        }
    }
}
