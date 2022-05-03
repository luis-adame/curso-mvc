using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Services.Abstractions
{
    public interface IDepartmentService
    {
        public List<DepartmentDto> GetDepartments();
        public DepartmentDto GetDepartment(DepartmentRegistryDto departmentRegistry);
        public List<SubdepartmentDto> GetSubdepartments();
        public List<SubdepartmentDto> GetDepartmentSubdepartments(DepartmentRegistryDto departmentRegistry);
        public SubdepartmentDto GetSubdepartment(SubdepartmentRegistryDto subdepartmentRegistry);
    }
}
