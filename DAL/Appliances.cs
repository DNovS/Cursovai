using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class Appliances : DbContext
    {
        public Appliances()
            : base("name=AppliancesContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<LineOrder> LineOrder { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<PromoCode> PromoCode { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Technic> Technic { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Technic)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LineOrder>()
                .Property(e => e.cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.LineOrder)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PromoCode>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Technic>()
                .Property(e => e.specifications)
                .IsUnicode(false);

            modelBuilder.Entity<Technic>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Technic>()
                .Property(e => e.cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Technic>()
                .HasMany(e => e.LineOrder)
                .WithRequired(e => e.Technic)
                .WillCascadeOnDelete(false);
        }
    }
}
