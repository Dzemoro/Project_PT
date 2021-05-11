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
        public DeviceRepository dr { get; set; }

        public DeviceManager(AppDatabaseContext context)
        {
            this.dr = new DeviceRepository(context);
        }

        public bool AddDevice() { return false; }
        public bool DeleteDevice() { return false; }
        public bool UpdateDevice() { return false; }


    }
}
