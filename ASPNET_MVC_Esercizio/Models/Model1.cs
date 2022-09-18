using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ASPNET_MVC_Esercizio.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Order_Details_Extended> Order_Details_Extended { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Details_Extended>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order_Details_Extended>()
                .Property(e => e.ExtendedPrice)
                .HasPrecision(19, 4);
        }
    }
}
