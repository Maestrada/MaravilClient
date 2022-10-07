using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class Order
    {
        public Int64 Id { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public  bool IsDelivered { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public decimal Amount { get; set; }
        public virtual Client Client { get; set; }

    }
}
