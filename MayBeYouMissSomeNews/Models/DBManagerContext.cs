using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MayBeYouMissSomeNews.Models
{
    public partial class DBManagerContext : DbContext
    {
        public DBManagerContext()
            : base("name=DBManagerContext1")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<newsdetail> newsdetails { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.newsdetails)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.gmail)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<news>()
                .HasMany(e => e.newsdetails)
                .WithRequired(e => e.news)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<newsdetail>()
                .Property(e => e.image)
                .IsUnicode(false);

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
