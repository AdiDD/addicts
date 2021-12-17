using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Guide
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string MentorID { get; set; }
        public ApplicationUser Mentor { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        public List<Step> Steps { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
