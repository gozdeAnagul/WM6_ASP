using Admin.Models.Abstracts;
using Admin.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Models.Entities
{
    [Table("Orders")]
    public class Order:BaseEntities<long>
    {
        public OrderTypes OrderTypes { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
    }
}
