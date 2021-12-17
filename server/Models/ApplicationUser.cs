using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "varchar(250)")]
        public string ProfilePicture { get; set; }
        public List<Badge> Badges { get; set; }
        public DateTime StepStartDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string LastName { get; set; }
    }
}
