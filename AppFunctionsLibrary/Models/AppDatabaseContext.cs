using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;

namespace AppFunctionsLibrary.Models
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext() : base("name=AppDatabaseContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    }
}
