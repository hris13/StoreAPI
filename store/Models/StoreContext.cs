using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace store.Models
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Temp> Temps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\Local;Database=store;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("AddressID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .HasColumnName("city")
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(10)
                    .HasColumnName("country")
                    .IsFixedLength();

                entity.Property(e => e.StreetName)
                    .HasMaxLength(10)
                    .HasColumnName("streetName")
                    .IsFixedLength();

                entity.Property(e => e.StreetNumber)
                    .HasMaxLength(10)
                    .HasColumnName("streetNumber")
                    .IsFixedLength();

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .HasColumnName("zipCode")
                    .IsFixedLength();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Address_Account");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("orderID");

                entity.Property(e => e.Buyer).HasColumnName("buyer");

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(10)
                    .HasColumnName("deliveryAddress")
                    .IsFixedLength();

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(10)
                    .HasColumnName("orderDate")
                    .IsFixedLength();

                entity.Property(e => e.OrderPrice)
                    .HasMaxLength(10)
                    .HasColumnName("orderPrice")
                    .IsFixedLength();

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(10)
                    .HasColumnName("orderStatus")
                    .IsFixedLength();

                entity.HasOne(d => d.BuyerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Buyer)
                    .HasConstraintName("FK_Order_Account");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemsId);

                entity.Property(e => e.OrderItemsId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderItemsID");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.OrderItemName)
                    .HasMaxLength(10)
                    .HasColumnName("orderItemName")
                    .IsFixedLength();

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderItems_Order");
            });

            modelBuilder.Entity<Temp>(entity =>
            {
                entity.ToTable("temp");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
