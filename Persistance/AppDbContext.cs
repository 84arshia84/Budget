using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AccessGroup;
using Domain.ActionBudgetRequestEntity;
using Domain.Allocation;
using Domain.AllocationActionBudgetRequest;
using Domain.BudgetRequest;
using Domain.FundingSource;
using Domain.Payment;
using Domain.PaymentMethod;
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
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<AccessGroup> AccessGroups { get; set; }
        public DbSet<AccessGroupUser> AccessGroupUsers { get; set; }
        public DbSet<AccessGroupRequestType> AccessGroupRequestTypes { get; set; }
        public DbSet<AccessGroupRequestingDepartment> AccessGroupRequestingDepartments { get; set; }
        public DbSet<AccessGroupFundingSource> AccessGroupFundingSources { get; set; }
        public DbSet<AccessGroupProperties> AccessGroupProperties { get; set; }

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

            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasKey(x => new { x.AllocationId, x.ActionBudgetRequestEntityId });



            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasOne(x => x.Allocation)
                .WithMany(x => x.AllocationActionBudgetRequests)
                .HasForeignKey(x => x.AllocationId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ پاک شدن وابسته‌ها همراه با Allocation

            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasOne(x => x.ActionBudgetRequestEntity)
                .WithMany() // اگه Navigation داری می‌تونی اینجا وصلش کنی
                .HasForeignKey(x => x.ActionBudgetRequestEntityId)
                .OnDelete(DeleteBehavior.Cascade);


            // 🔑 کلید مرکب AllocationActionBudgetRequest
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .HasKey(x => new { x.AllocationId, x.ActionBudgetRequestEntityId });


            // ActionBudgetRequestEntity → AllocationActionBudgetRequests

            // تنظیم دقت عددی
            modelBuilder.Entity<AllocationActionBudgetRequest>()
                .Property(p => p.AllocatedAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentMethod)
                .WithMany()
                .HasForeignKey(p => p.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict); // جلوگیری از حذف PaymentMethod در صورت وجود Payment

            // تعریف رابطه بین Payment و Allocation
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Allocation)
                .WithMany()
                .HasForeignKey(p => p.AllocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentAmount)
                .HasColumnType("decimal(18,2)");




            modelBuilder.Entity<AccessGroup>()
                .HasOne(a => a.Properties)
                .WithOne(p => p.AccessGroup)
                .HasForeignKey<AccessGroupProperties>(p => p.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // AccessGroup → Users (1-n)
            modelBuilder.Entity<AccessGroup>()
                .HasMany(a => a.Users)
                .WithOne(u => u.AccessGroup)
                .HasForeignKey(u => u.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // AccessGroup → RequestTypes (1-n)
            modelBuilder.Entity<AccessGroup>()
                .HasMany(a => a.RequestTypes)
                .WithOne(rt => rt.AccessGroup)
                .HasForeignKey(rt => rt.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // AccessGroup → RequestingDepartments (1-n)
            modelBuilder.Entity<AccessGroup>()
                .HasMany(a => a.RequestingDepartments)
                .WithOne(rd => rd.AccessGroup)
                .HasForeignKey(rd => rd.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // AccessGroup → FundingSources (1-n)
            modelBuilder.Entity<AccessGroup>()
                .HasMany(a => a.FundingSources)
                .WithOne(fs => fs.AccessGroup)
                .HasForeignKey(fs => fs.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);






            modelBuilder.Entity<AccessGroup>()
                .HasMany(a => a.Users)
                .WithOne(u => u.AccessGroup)
                .HasForeignKey(u => u.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccessGroup>()
                .HasMany(a => a.RequestTypes)
                .WithOne(rt => rt.AccessGroup)
                .HasForeignKey(rt => rt.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccessGroup>()
                .HasMany(a => a.RequestingDepartments)
                .WithOne(rd => rd.AccessGroup)
                .HasForeignKey(rd => rd.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccessGroup>()
                .HasMany(a => a.FundingSources)
                .WithOne(fs => fs.AccessGroup)
                .HasForeignKey(fs => fs.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccessGroup>()
                .HasOne(a => a.Properties)
                .WithOne(p => p.AccessGroup)
                .HasForeignKey<AccessGroupProperties>(p => p.AccessGroupId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
