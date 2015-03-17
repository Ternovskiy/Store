using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModul.DomainModel
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Data { get; set; }
        public int CartId { get; set; }
        public int StateId { get; set; }
        public int AdresId { get; set; }
    }
}
