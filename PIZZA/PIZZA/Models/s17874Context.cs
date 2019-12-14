using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PIZZA.Models
{
    public partial class s17874Context : DbContext
    {
        public s17874Context()
        {
        }

        public s17874Context(DbContextOptions<s17874Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderPizza> OrderPizza { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaSauce> PizzaSauce { get; set; }
        public virtual DbSet<PizzaTopping> PizzaTopping { get; set; }
        public virtual DbSet<Promo> Promo { get; set; }
        public virtual DbSet<Sauce> Sauce { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17874;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.IdCustomer)
                    .HasColumnName("idCustomer")
                    .ValueGeneratedNever();

                entity.Property(e => e.BuildingNumber).HasColumnName("Building Number");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First Name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlatNumber).HasColumnName("Flat Number");

                entity.Property(e => e.LastName)
                    .HasColumnName("Last Name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Street).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder)
                    .HasColumnName("idOrder")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnName("Total ");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("Customer_Order_FK1");

                entity.HasOne(d => d.DriverNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Driver)
                    .HasConstraintName("Staff_Order_FK1");

                entity.HasOne(d => d.PromoNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Promo)
                    .HasConstraintName("Promo_Order_FK1");
            });

            modelBuilder.Entity<OrderPizza>(entity =>
            {
                entity.HasKey(e => e.IdOrderPizza);

                entity.ToTable("order_pizza");

                entity.Property(e => e.IdOrderPizza)
                    .HasColumnName("idOrderPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Crust)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Size)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrderNavigation)
                    .WithMany(p => p.OrderPizza)
                    .HasForeignKey(d => d.Order)
                    .HasConstraintName("Order_order_pizza_FK1");

                entity.HasOne(d => d.PizzaNavigation)
                    .WithMany(p => p.OrderPizza)
                    .HasForeignKey(d => d.Pizza)
                    .HasConstraintName("Pizza_order_pizza_FK1");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza);

                entity.Property(e => e.IdPizza)
                    .HasColumnName("idPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Desc).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaSauce>(entity =>
            {
                entity.HasKey(e => e.IdPizzaSauce);

                entity.ToTable("Pizza_sauce");

                entity.Property(e => e.IdPizzaSauce)
                    .HasColumnName("idPizzaSauce")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.PizzaNavigation)
                    .WithMany(p => p.PizzaSauce)
                    .HasForeignKey(d => d.Pizza)
                    .HasConstraintName("Pizza_Pizza Sauce_FK1");

                entity.HasOne(d => d.SauceNavigation)
                    .WithMany(p => p.PizzaSauce)
                    .HasForeignKey(d => d.Sauce)
                    .HasConstraintName("Sauce_Pizza Sauce_FK1");
            });

            modelBuilder.Entity<PizzaTopping>(entity =>
            {
                entity.HasKey(e => e.IdPizzaTopping);

                entity.ToTable("Pizza_topping");

                entity.Property(e => e.IdPizzaTopping)
                    .HasColumnName("idPizza_Topping")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.PizzaNavigation)
                    .WithMany(p => p.PizzaTopping)
                    .HasForeignKey(d => d.Pizza)
                    .HasConstraintName("Pizza_Pizza Topping_FK1");

                entity.HasOne(d => d.ToppingNavigation)
                    .WithMany(p => p.PizzaTopping)
                    .HasForeignKey(d => d.Topping)
                    .HasConstraintName("Topping_Pizza Topping_FK1");
            });

            modelBuilder.Entity<Promo>(entity =>
            {
                entity.HasKey(e => e.IdPromo);

                entity.Property(e => e.IdPromo)
                    .HasColumnName("idPromo")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Requirement)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.To).HasColumnType("datetime");
            });

            modelBuilder.Entity<Sauce>(entity =>
            {
                entity.HasKey(e => e.IdSauce);

                entity.Property(e => e.IdSauce)
                    .HasColumnName("idSauce")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.IdStaff);

                entity.Property(e => e.IdStaff)
                    .HasColumnName("idStaff")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.HasKey(e => e.IdTopping);

                entity.Property(e => e.IdTopping)
                    .HasColumnName("idTopping")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PriceItem).HasColumnName("Price_item");
            });
        }
    }
}
