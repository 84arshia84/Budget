using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ActionBudgetRequestEntity;
using Domain.Allocation;
using Domain.AllocationActionBudgetRequest;
using Domain.BudgetRequest;
using Domain.FundingSource;
using Domain.RequestingDepartment;
using Domain.RequestType;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AllocationActionBudgetRequest> AllocationActionBudgetRequests { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<ActionBudgetRequestEntity> ActionBudgetRequestEntitys { get; set; }
        public DbSet<BudgetRequest> BudgetRequests { get; set; }
        public DbSet<FundingSource> FundingSources { get; set; }
        public DbSet<RequestingDepartment> RequestingDepartments { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BudgetRequest → RequestType
            modelBuilder.Entity<BudgetRequest>()
                .HasOne(r => r.RequestType)
                .WithMany(rt => rt.BudgetRequests)
                .HasForeignKey(r => r.RequestTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // BudgetRequest → RequestingDepartment
            modelBuilder.Entity<BudgetRequest>()
                .HasOne(r => r.RequestingDepartment)
                .WithMany(rd => rd.BudgetRequests)
                .HasForeignKey(r => r.RequestingDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // BudgetRequest → FundingSource
            modelBuilder.Entity<BudgetRequest>()
                .HasOne(r => r.FundingSource)
                .WithMany(f => f.BudgetRequests)
                .HasForeignKey(r => r.FundingSourceId)
                .OnDelete(DeleteBehavior.Restrict);

            // BudgetRequest → Allocation
            modelBuilder.Entity<Allocation>()
                .HasOne(a => a.BudgetRequest)
                .WithMany(b => b.Allocations)
                .HasForeignKey(a => a.BudgetRequestId)
                .OnDelete(DeleteBehavior.Restrict); // ✅ جلوگیری از حذف BudgetRequest در صورت وجود Allocation

            // 🔑 کلید مرکب AllocationActionBudgetRequest
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasKey(x => new { x.AllocationId, x.ActionBudgetRequestEntityId });

            // Allocation → AllocationActionBudgetRequests
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasOne(x => x.Allocation)
                .WithMany(x => x.AllocationActionBudgetRequests)
                .HasForeignKey(x => x.AllocationId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ پاک شدن وابسته‌ها همراه با Allocation

            // ActionBudgetRequestEntity → AllocationActionBudgetRequests
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasOne(x => x.ActionBudgetRequestEntity)
                .WithMany() // اگه Navigation داری می‌تونی اینجا وصلش کنی
                .HasForeignKey(x => x.ActionBudgetRequestEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            // تنظیم دقت عددی
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .Property(p => p.AllocatedAmount)
                .HasPrecision(18, 2);
        }
    }
}
