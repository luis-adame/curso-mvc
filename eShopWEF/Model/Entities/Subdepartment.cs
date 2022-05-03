using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Subdepartment
    {
        public int Id { get; set; }
        public string Name { get; set; } //tenia private set
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }  //tenia private set
        public virtual ICollection<Product> Products { get; set; }

        public Subdepartment(string name, int departmentId)
        {
            Name = name;
            DepartmentId = departmentId;
        }
    }
}
