using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;
using AppFunctionsLibrary.DAL;

namespace AppGUI {
    class ObstacleManager {
        public ObstacleRepository rep { get; set; }

        public ObstacleManager(AppDatabaseContext context) {
            this.rep = new ObstacleRepository(context);
        }
        public Obstacle AddCustomObstacle(Obstacle o) {
            this.rep.Insert(o);
            rep.Commit();
            return o;
        }
        public bool DeleteObstacle() { return false; }
        public bool UpdateObstacle() { return false; }
        public List<Obstacle> GetObstacles() {
            return this.rep.GetAllObstacles();
        }
        public Obstacle GetObstacle (int id) {
            return this.rep.GetObstacle(id);
        }
        public Obstacle GetObstacleByName(string name) {
            return this.rep.GetObstacleByName(name);
        }
    }
}
