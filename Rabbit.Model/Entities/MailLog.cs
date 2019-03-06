using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Model.Entities
{
    [Table("MailLogs")]
    public class MailLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, StringLength(50)]
        public string Message { get; set; }
        [Required, StringLength(50)]
        public string Subject { get; set; }
        [Required, StringLength(11)]
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
