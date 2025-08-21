using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ActionBudgetRequestEntity;
using Domain.Allocation;
using Domain.AllocationActionBudgetRequest;
//using Domain.ActionBudgetRequestEntity;
//using Domain.Allocation;
//using Domain.AllocationActionBudgetRequest;
using Domain.BudgetRequest;
using Domain.FundingSource;
//using Domain.Payment;
//using Domain.PaymentMethod;
using Domain.RequestingDepartment;
using Domain.RequestType;
using Microsoft.EntityFrameworkCore;


namespace Persistance
{
    public class AppDbContext : DbContext
    {
        // کانستراکتور با دریافت گزینه‌های کانفیگ از DI
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AllocationActionBudgetRequest> AllocationActionBudgetRequests { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<ActionBudgetRequestEntity> ActionBudgetRequestEntitys { get; set; }
        public DbSet<BudgetRequest> BudgetRequests { get; set; }
        public DbSet<FundingSource> FundingSources { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<RequestingDepartment> RequestingDepartments { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // فقط یک بار، در اول

            // رابطه BudgetRequest با RequestType
            modelBuilder.Entity<BudgetRequest>()
                .HasOne(r => r.RequestType)
                .WithMany(rt => rt.BudgetRequests)
                .HasForeignKey(r => r.RequestTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BudgetRequest>()
                .HasOne(r => r.RequestingDepartment)
                .WithMany(rd => rd.BudgetRequests)
                .HasForeignKey(r => r.RequestingDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BudgetRequest>()
                .HasOne(r => r.FundingSource)
                .WithMany(f => f.BudgetRequests)
                .HasForeignKey(r => r.FundingSourceId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔑 تصحیح کلید مرکب: فقط با فیلدهای اسکالر (مثلاً Id)
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasKey(x => new { x.AllocationId, x.ActionBudgetRequestEntityId });

            // رابطه با Allocation
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasOne(x => x.Allocation)
                .WithMany(x => x.AllocationActionBudgetRequests)
                .HasForeignKey(x => x.AllocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // رابطه با ActionBudgetRequestEntity
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasOne(x => x.ActionBudgetRequestEntity)
                .WithMany() // یا باش: .WithMany(ar => ar.AllocationActionBudgetRequests) اگر navigation داشته باشه
                .HasForeignKey(x => x.ActionBudgetRequestEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            // تنظیم دقت عددی
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .Property(p => p.AllocatedAmount)
                .HasPrecision(18, 2);

            // ❌ ننویس: base.OnModelCreating(modelBuilder); دوباره در آخر
        }
    }
}
