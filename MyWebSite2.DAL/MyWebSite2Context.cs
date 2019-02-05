using MyWebSite2.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite2.DAL
{
    class MyWebSite2Context:DbContext
    {
        public MyWebSite2Context()
        {

        }
        public DbSet<User> User { get; set; }
    }
}
