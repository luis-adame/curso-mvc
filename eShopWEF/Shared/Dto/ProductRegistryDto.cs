using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class ProductRegistryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public int SubdepartmentId { get; set; }

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

        public void ValidateStock()
        {
            if (Stock < 0)
                throw new Exception("'Stock' must be higher than 0.");
        }

        public void ValidatePrice()
        {
            if (Price < 0)
                throw new Exception("'Price' must be higher than 0.");
        }

        public void ValidateSku()
        {
            if (string.IsNullOrEmpty(Sku))
                throw new ArgumentNullException("'Sku' must not be empty.");
        }

        public void ValidateBrand()
        {
            if (string.IsNullOrEmpty(Brand))
                throw new ArgumentNullException("'Brand' must not be empty.");
        }

        public void ValidateSubdepartmentId()
        {
            if (SubdepartmentId <= 0)
                throw new Exception("'SubdepartmentId' must be higher than 0.");
        }
    }
}
