using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Step
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public List<ApplicationUser> Users { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string MeetLink { get; set; }
        public Badge Badge { get; set; }
    }
}
