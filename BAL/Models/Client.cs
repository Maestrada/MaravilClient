using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class Client
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string? CellPhone2 { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }      
        public int CreatedByUserId { get; set; }
        public int ModifiedByUserId { get; set; }
        public int TownId { get; set; }
        public string Reference { get; set; }
        public virtual Town Town { get; set; }
        public virtual User CreatedByUser { get; set; } 
        public virtual User ModifiedByUser { get; set; }
        public List<Order> Orders { get; set; }
    }
}
