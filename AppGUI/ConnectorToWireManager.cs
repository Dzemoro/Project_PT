using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;
using AppFunctionsLibrary.DAL;

namespace AppGUI
{
    class ConnectorToWireManager
    {
        public ConnectorToWireRepository rep { get; set; }
        public ConnectorRepository repConn { get; set; }
        public WireRepository repWire { get; set; }

        public ConnectorToWireManager(AppDatabaseContext context)
        {
            this.rep = new ConnectorToWireRepository(context);
            this.repConn = new ConnectorRepository(context);
            this.repWire = new WireRepository(context);
        }

        public bool AddConnectorToWire() { return false; }
        public bool DeleteConnectorToWire() { return false; }
        public bool UpdateConnectorToWire() { return false; }

        public List<ConnectorToWire> GetWires()
        {
            return this.rep.GetAllConnectorsToWires();
        }

        public List<Connector> GetConnectorsByWire(int wire_id)
        {
            var result = new List<Connector>();
            var connToWireList = this.rep.GetByWire(wire_id);

            foreach (var connToWire in connToWireList)
            {
                result.Add(this.repConn.GetByID(connToWire.connector_id));
            }
            return result;
        }

        public List<Wire> GetWiresByConnectors(int connector_id)
        {
            var result = new List<Wire>();
            var connToWireList = this.rep.GetByWire(connector_id);

            foreach (var connToWire in connToWireList)
            {
                result.Add(this.repWire.GetByID(connToWire.wire_id));
            }
            return result;
        }
    }
}
