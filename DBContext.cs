using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD
{
    internal class DBContext : DbContext
    {
        public DBContext() : base("Conn") { }

        public DbSet<Auth> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
