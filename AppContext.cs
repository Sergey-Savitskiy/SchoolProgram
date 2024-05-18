using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject
{
    class AppContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Event> Events { get; set; }

        public AppContext() : base("DefaultConnection") { }
    }
}
