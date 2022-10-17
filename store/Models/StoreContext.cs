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

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.StreetName)
                    .HasMaxLength(50)
                    .HasColumnName("streetName");

                entity.Property(e => e.StreetNumber)
                    .HasMaxLength(50)
                    .HasColumnName("streetNumber");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(50)
                    .HasColumnName("zipCode");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Address_Account");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.Buyer).HasColumnName("buyer");

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(50)
                    .HasColumnName("deliveryAddress");

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(50)
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderPrice)
                    .HasMaxLength(50)
                    .HasColumnName("orderPrice");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50)
                    .HasColumnName("orderStatus");

                entity.HasOne(d => d.BuyerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Buyer)
                    .HasConstraintName("FK_Order_Account1");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemsId);

                entity.Property(e => e.OrderItemsId).HasColumnName("OrderItemsID");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.OrderItemName)
                    .HasMaxLength(50)
                    .HasColumnName("orderItemName");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
