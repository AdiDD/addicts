using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Badge
    {
        [Required]
        public int ID { get; set; }

        public string Title { get; set; }
    }
}
