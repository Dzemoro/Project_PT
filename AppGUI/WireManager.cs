using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;
using AppFunctionsLibrary.DAL;

namespace AppGUI
{
    class WireManager
    {
        public WireRepository rep { get; set; }
        public WireAttenuationRepository repAtt { get; set; }
        public WireAttenuationManager wam;

        public WireManager(AppDatabaseContext context)
        {
            this.rep = new WireRepository(context);
            this.repAtt = new WireAttenuationRepository(context);
            this.wam = new WireAttenuationManager(context);
        }

        public Wire AddCustomWire(Wire w, WireAttenuation wa) {
            this.rep.Insert(w);
            rep.Commit();
            wa.wire_id = w.id;
            this.wam.AddCustomWireAttenuation(wa);
            return w;
        }
        public bool DeleteWire() { return false; }
        public bool UpdateWire() { return false; }
        public Wire GetWireByName (string name)
        {
            return this.rep.GetWireByName(name);
        }
        public Wire GetWire(int id) {
            return this.rep.GetWire(id);
        }
        public List<Wire> GetWires()
        {
            return this.rep.GetAllWires();
        }
        public List<Wire> GetWiresByFrequency(float frequency)
        {
            var wires = this.rep.GetAllWires();
            var wiresAttenuation = this.repAtt.GetWiresAttenuationByFrequency(frequency);

            List<Wire> result = new List<Wire>();
            foreach (var att in wiresAttenuation)
            {
                foreach( var w in wires)
                    if (att.wire_id == w.id)
                    {
                        result.Add(this.rep.GetWire(w.id));
                    }

            }

            return result;
        }
        public WireAttenuation GetWireAttenuationByNameFrequency(string name, int frequency)
        {
            var wires = this.rep.GetAllWires();
            var wiresAttenuation = this.repAtt.GetWiresAttenuationByFrequency(frequency);

            var result = wiresAttenuation.FirstOrDefault(i => i.wire_id == wires.FirstOrDefault(j => j.name == name).id);
            if (result == default)
                return null;
            else return result;
        }

        public WireAttenuation GetWireAttenuationByIdFrequency(int id, int frequency) {
            var wires = this.rep.GetAllWires();
            var wiresAttenuation = this.repAtt.GetWiresAttenuationByFrequency(frequency);

            var result = wiresAttenuation.FirstOrDefault(i => i.wire_id == wires.FirstOrDefault(j => j.id == id).id);

            if (result == default)
                return null;
            else return result;
        }
    }
}
