using eShop.Services.Abstractions;
using Model;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService()
        {
            _context = new AppDbContext();
        }

        public DepartmentDto GetDepartment(DepartmentRegistryDto departmentRegistry)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentDto> GetDepartments()
        {
            var departments = _context.Departments.Select(e => new DepartmentDto
            {
                Id = e.Id,
                Name = e.Name,
            }).ToList();

            if(!departments.Any())
                throw new Exception("There are no departments to list.");

            return departments;
        }

        public List<SubdepartmentDto> GetDepartmentSubdepartments(DepartmentRegistryDto departmentRegistry)
        {
            var subdepartments = _context.Subdepartments
                .Where(e => e.DepartmentId.Equals(departmentRegistry.Id))
                .Select(e => new SubdepartmentDto
                {
                    Id = e.Id,
                    Name = e.Name,
                }).ToList();

            if (!subdepartments.Any())
                throw new Exception("There are no subdepartments to list.");

            return subdepartments;
        }

        public SubdepartmentDto GetSubdepartment(SubdepartmentRegistryDto subdepartmentRegistry)
        {
            var subdepartment = _context.Subdepartments
                .Where(e => e.Id.Equals(subdepartmentRegistry.Id)).Select(e => new SubdepartmentDto
                {
                    Id = e.Id,
                    Name = e.Name,
                }).FirstOrDefault();

            if (subdepartment is null)
                throw new Exception("Subdepartment does not exist.");

            return subdepartment;
        }

        public List<SubdepartmentDto> GetSubdepartments()
        {
            var subdepartments = _context.Subdepartments.Select(e => new SubdepartmentDto
            {
                Id = e.Id,
                Name = e.Name,
            }).ToList();

            if (!subdepartments.Any())
                throw new Exception("There are no subdepartments to list.");

            return subdepartments;
        }
    }
}
