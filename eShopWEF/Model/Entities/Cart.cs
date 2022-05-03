using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<CartDetail> CartDetail { get; set; }
    }
}
