using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //public DbSet<AllocationActionBudgetRequest> AllocationActionBudgetRequests { get; set; }
        //public DbSet<Allocation> Allocations { get; set; }
        //public DbSet<ActionBudgetRequestEntity> ActionBudgetRequestEntitys { get; set; }
        public DbSet<BudgetRequest> BudgetRequests { get; set; }
        public DbSet<FundingSource> FundingSources { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<RequestingDepartment> RequestingDepartments { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BudgetRequest>()
                .HasOne(r => r.RequestType)
                .WithMany(rt => rt.BudgetRequests)
                .HasForeignKey(r => r.RequestTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<BudgetRequest>()
                .HasOne(r=>r.RequestingDepartment)
                .WithMany(rd=>rd.BudgetRequests)
                .HasForeignKey(r=>r.RequestingDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BudgetRequest>()
                .HasOne(r=>r.FundingSource)
                .WithMany(f=>f.BudgetRequests)
                .HasForeignKey(r=>r.FundingSourceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
