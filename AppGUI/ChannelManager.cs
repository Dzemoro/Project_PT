using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;
using AppFunctionsLibrary.DAL;

namespace AppGUI
{
    class ChannelManager
    {
        public ChannelRepository rep { get; set; }

        public ChannelManager(AppDatabaseContext context)
        {
            this.rep = new ChannelRepository(context);
        }

        public bool AddChannel() { return false; }
        public bool DeleteChannel() { return false; }
        public bool UpdateChannel() { return false; }

        public Channel GetChannelByBandFrequency(int band, int number)
        {
            return this.rep.GetChannelByBandFrequency(band, number);
        }
        public List<Channel> GetChannelsByBand(int band)
        {
            return this.rep.GetChannelsByBand(band);
        }

        public List<Channel> GetChannels()
        {
            return this.rep.GetAllChannels();
        }
    }
}
