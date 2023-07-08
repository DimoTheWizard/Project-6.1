using Microsoft.EntityFrameworkCore;
using System.Configuration;
using static System.Collections.Specialized.BitVector32;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace project6._1Api.Entities
{
    public class database: DbContext
    {

        public database(DbContextOptions<database> options)
        : base(options)
        {
        }
        public database()
        {
        }

        public virtual DbSet<Transactions> Transactions { get; set; }

    }
}
