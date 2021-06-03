using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;
using AppFunctionsLibrary.DAL;

namespace AppGUI
{
    class WireAttenuationManager
    {
        public WireAttenuationRepository rep { get; set; }

        public WireAttenuationManager(AppDatabaseContext context)
        {
            this.rep = new WireAttenuationRepository(context);
        }

        public WireAttenuation AddCustomWireAttenuation(WireAttenuation wa) {
            this.rep.Insert(wa);
            rep.Commit();
            return wa;
        }
        public List<WireAttenuation> GetAll()
        {
            return this.rep.GetAll();
        }

    }
}
