using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;
using AppFunctionsLibrary.DAL;

namespace AppGUI {
    class ConnectorManager {
        public ConnectorRepository rep { get; set; }

        public ConnectorManager(AppDatabaseContext context) {
            this.rep = new ConnectorRepository(context);
        }

        public Connector AddCustomConnector(Connector c) {
            this.rep.Insert(c);
            rep.Commit();
            return c;
        }
        public bool DeleteConnector() { return false; }
        public bool UpdateConnector() { return false; }
        public Connector GetConnectorByName(string name) {
            return this.rep.GetConnectorByName(name);
        }
        public Connector GetConnector(int id) {
            return this.rep.GetConnector(id);
        }
        public List<Connector> GetConnectors() {
            return this.rep.GetAllConnectors();
        }
    }
}
