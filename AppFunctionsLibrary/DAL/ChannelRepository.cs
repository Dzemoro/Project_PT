using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;

namespace AppFunctionsLibrary.DAL
{
    public class ChannelRepository : BaseRepository<Channel>
    {
        public ChannelRepository(AppDatabaseContext context) : base(context)
        {

        }
        public Channel GetChannel(int id)
        {
            return dbSet.SingleOrDefault(x => x.id == id);
        }
        public Channel GetChannelByBandFrequency(int band, int number)
        {
            return dbSet.SingleOrDefault(x => x.band == band && x.number == number);
        }

        public List<Channel> GetChannelsByBand (int band)
        {
            return dbSet.Where(x => x.band == band).ToList();
        }
        
        public List<Channel> GetAllChannels()
        {
            return dbSet.ToList();
        }
    }
}
