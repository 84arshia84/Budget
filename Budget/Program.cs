
using Application.Contracts;
using Application.Mapper;
using Application.Mapper.Allocation;
using Application.Services;
using Application.Validators.Payment;
using Domain.AccessGroup;
using Domain.Allocation;
using Domain.BudgetRequest;
using Domain.FundingSource;
using Domain.Payment;
using Domain.PaymentMethod;
using Domain.RequestingDepartment;
using Domain.RequestType;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Repositories;

namespace Budget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IRequestingDepartmentRepository, RequestingDepartmentRepository>();
            builder.Services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
            builder.Services.AddScoped<IFundingSourceRepository, FundingSourceRepository>();
            builder.Services.AddScoped<IBudgetRequestRepository,BudgetRequestRepository>();
            builder.Services.AddScoped<IAllocationRepository,AllocationRepository>();
            builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IAccessGroupRepository, AccessGroupRepository>();

            builder.Services.AddScoped<AddPaymentDtoValidator>();


            builder.Services.AddScoped<IRequestingDepartmenService, RequestingDepartmenService>();
            builder.Services.AddScoped<IRequestTypeService, RequestTypeService>();
            builder.Services.AddScoped<IFundingSourceService, FundingSourceService>();
            builder.Services.AddScoped<IBudgetRequestService, BudgetRequestService>();
            builder.Services.AddScoped<IAllocationService, AllocationService>();
            builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IAccessGroupService, AccessGroupService>();


            builder.Services.AddScoped<BudgetRequestMapper>();
            builder.Services.AddScoped<BudgetRequestToDtoMapper>();
            builder.Services.AddScoped<ActionBudgetRequestMapper>();
            builder.Services.AddScoped<AllocationMapper>();







            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(x => x.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None));
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
