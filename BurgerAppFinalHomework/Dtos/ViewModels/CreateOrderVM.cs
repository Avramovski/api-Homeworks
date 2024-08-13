using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ViewModels
{
    public class CreateOrderVM
    {
        public int Id { get; set; }  // For edit scenarios; default to 0 for new orders
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public List<int> BurgerIds { get; set; }  // List of burger IDs associated with the order
    }
}
