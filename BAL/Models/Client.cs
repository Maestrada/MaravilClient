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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CellPhone { get; set; }
        public string CellPhone2 { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
      
        public int CreatedByUserId { get; set; }

        public int ModifiedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual User CreatedByUser { get; set; } 
        [ForeignKey("ModifiedByUserId")]
        public virtual User ModifiedByUser { get; set; }
    }
}
