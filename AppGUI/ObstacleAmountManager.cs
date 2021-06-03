using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;
using AppFunctionsLibrary.DAL;

namespace AppGUI {
    class ObstacleAmountManager {
        public ObstacleAmountRepository rep { get; set; }

        public ObstacleAmountManager(AppDatabaseContext context) {
            this.rep = new ObstacleAmountRepository(context);
        }
        public void AddObstacleAmount(ObstacleAmount om) {
            this.rep.Insert(om);
            rep.Commit();

        }
        public List<ObstacleAmount> GetObstacleAmounts() {
            return this.rep.GetAllObstacleAmounts();
        }
        public List<ObstacleAmount> GetObstaleAmountsByMID(int m_id) {
            var all = GetObstacleAmounts();
            List<ObstacleAmount> result = new List<ObstacleAmount>();
            foreach (var el in all) {
                if (el.measurements_id == m_id)
                    result.Add(el);
            }
            return result;

        }

    }
}
