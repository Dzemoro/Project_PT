using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFunctionsLibrary.Models;

namespace AppFunctionsLibrary.DAL
{
    public class WireAttenuationRepository : BaseRepository<WireAttenuation>
    {
        public WireAttenuationRepository(AppDatabaseContext context) : base(context)
        {

        }

        public List<WireAttenuation> GetWiresAttenuationByFrequency(float frequency)
        {
            List<WireAttenuation> result = new List<WireAttenuation>();
            var wires= dbSet.Select(i => i.wire_id).Distinct().ToList();
            foreach (var wire in wires)
            {
                var singleResult = dbSet.SingleOrDefault(x => x.wire_id == GetWireAttenuation(wire).wire_id && x.value == frequency);
                if (singleResult == default)
                {
                    var min = dbSet.Where(x => x.wire_id == wire).Where(x => x.frequency < frequency).OrderByDescending(x => x.frequency).FirstOrDefault();
                    var max = dbSet.Where(x => x.wire_id == wire).FirstOrDefault(x => x.frequency > frequency);

                    if (min == default)
                        result.Add(max);
                    else if (max == default)
                        result.Add(min);
                    else
                    {
                        if (Math.Abs(frequency - min.frequency) < Math.Abs(frequency - max.frequency))
                            result.Add(min);
                        else
                            result.Add(max);
                    }
                        
                }
            }
            return result;
        }

        public WireAttenuation GetWireAttenuation(int id)
        {
            return dbSet.SingleOrDefault(x => x.id == id);
        }
        public List<WireAttenuation> GetAll()
        {
            return dbSet.ToList();
        }
    }
}