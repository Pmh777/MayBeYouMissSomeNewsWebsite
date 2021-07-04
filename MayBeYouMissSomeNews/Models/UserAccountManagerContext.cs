using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MayBeYouMissSomeNews.Models
{
    public partial class UserAccountManagerContext : DbContext
    {
        public UserAccountManagerContext()
            : base("name=UserAccountManagerContext1")
        {
        }

        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.gmail)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
