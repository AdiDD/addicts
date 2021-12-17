using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string UserID { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
