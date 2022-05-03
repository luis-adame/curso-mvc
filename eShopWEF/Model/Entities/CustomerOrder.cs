using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class CustomerOrder
    {
		public int Id { get; set; }
		public decimal Total { get; set; } //tenia private set
		public DateTime OrderDate { get; set; }
		public virtual ICollection<CustomerOrderDetail> CustomerOrderDetail { get; set; }

		public CustomerOrder(decimal total)
        {
			Total = total;
			OrderDate = DateTime.Now;
        }
	}
}
