using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;
using AppFunctionsLibrary.DAL;

namespace AppGUI
{
    class DeviceManager
    {
        public DeviceRepository rep { get; set; }

        public DeviceManager(AppDatabaseContext context)
        {
            this.rep = new DeviceRepository(context);
        }

        public bool AddDevice() { return false; }
        public bool DeleteDevice() { return false; }
        public bool UpdateDevice() { return false; }
        public Device GetDeviceByName (string name)
        {
            return this.rep.GetDeviceByName(name);
        }
        public List<Device> GetDevices()
        {
            return this.rep.GetAllDevices();
        }

    }
}
