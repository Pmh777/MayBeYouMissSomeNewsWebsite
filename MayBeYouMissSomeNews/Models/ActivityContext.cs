using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MayBeYouMissSomeNews.Models
{
    public partial class ActivityContext : DbContext
    {
        public ActivityContext()
            : base("name=ActivityContext")
        {
        }

        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<liked> likeds { get; set; }
        public virtual DbSet<saved> saveds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
