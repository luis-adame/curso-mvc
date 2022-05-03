using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class SubdepartmentRegistryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void ValidateId()
        {
            if (Id <= 0)
                throw new Exception("'Id' must be higher than 0.");
        }

        public void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("'Name' must not be empty.");
        }
    }
}
