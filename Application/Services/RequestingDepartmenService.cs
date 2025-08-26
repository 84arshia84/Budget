using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dto.RequestingDepartmen;
using Application.Validators.Allocation;
using Application.Validators.RequestingDepartment;
using Domain.RequestingDepartment;

namespace Application.Services
{
    public class RequestingDepartmenService : IRequestingDepartmenService
    {
        private readonly IRequestingDepartmentRepository _repository;

        public RequestingDepartmenService(IRequestingDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(AddRequestingDepartmenDto dto)
        {
            var validator = new AddRequestingDepartmenDtoValidator();
            validator.Validate(dto);

            var entity = new RequestingDepartment
            {
                Description = dto.Description
            };
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<GetAllRequestingDepartmenDto>> GetAllAsync()
        {
            var departments = await _repository.GetAllAsync();
            return departments.Select(d => new GetAllRequestingDepartmenDto
            {
                Id = d.Id,
                Description = d.Description
            }).ToList();
        }

        public async Task<GetByIdRequestingDepartmenDto?> GetByIdAsync(long id)
        {
            var department = await _repository.GetByIdAsync(id);

            // بررسی اینکه آیا چنین رکوردی وجود دارد یا نه
            if (department == null)
                return null;

            // تبدیل مدل دامنه به DTO و بازگشت به UI
            return new GetByIdRequestingDepartmenDto
            {
                Id = department.Id,
                Description = department.Description
            };
        }

        public async Task UpdateAsync(long id, UpdateRequestingDepartmenDto dto)
        {
          

            var department = await _repository.GetByIdAsync(id);
            if (department == null)
                throw new KeyNotFoundException($"دپارتمان با شناسه {id} یافت نشد.");

            // ✅ فقط مقدار Description را تغییر می‌دهیم
            department.Description = dto.Description;

            // ✅ همان شیء قبلی را به ریپازیتوری می‌دهیم
            await _repository.UpdateAsync(department);
        }
    }
}
