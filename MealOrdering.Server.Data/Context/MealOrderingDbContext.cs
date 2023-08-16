using MealOrdering.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrdering.Server.Data.Context
{
    public class MealOrderingDbContext : DbContext
    {
        public MealOrderingDbContext(DbContextOptions<MealOrderingDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.Id).HasName("pk_user_id");
                entity.Property(u => u.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()").IsRequired();
                entity.Property(u => u.FirstName).HasMaxLength(100);
                entity.Property(u => u.Email).HasMaxLength(100);
                entity.Property(u => u.LastName).HasMaxLength(100);
                entity.Property(u => u.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(u => u.IsActive).HasDefaultValue(true);
            });
            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.Property(u => u.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()").IsRequired();
                entity.Property(u => u.WebUrl).HasMaxLength(500);
                entity.Property(u => u.Name).HasMaxLength(100);
                entity.Property(u => u.CreateDate).HasDefaultValueSql("getdate()");
            });
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(u => u.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()").IsRequired();
                entity.Property(u => u.Name).HasMaxLength(10000);
                entity.Property(u => u.Description).HasMaxLength(100);
                entity.Property(u => u.CreateDate).HasDefaultValueSql("getdate()");
                entity.HasOne(o => o.User).WithMany(u => u.Orders).HasForeignKey(d=>d.CreateUserId).OnDelete(deleteBehavior:DeleteBehavior.Cascade);
                entity.HasOne(o => o.Supplier).WithMany(u => u.Orders).HasForeignKey(d=>d.SupplierId).OnDelete(deleteBehavior:DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.Property(u => u.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()").IsRequired();
                entity.Property(u => u.Description).HasMaxLength(100);
                entity.Property(u => u.CreateDate).HasDefaultValueSql("getdate()");
                entity.HasOne(o => o.Order).WithMany(u => u.OrderItems).HasForeignKey(d => d.OrderId).OnDelete(deleteBehavior: DeleteBehavior.Cascade);
                entity.HasOne(o => o.User).WithMany(u => u.OrderItems).HasForeignKey(d => d.CreateUserId).OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
