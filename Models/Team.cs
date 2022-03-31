using System;
using System.ComponentModel.DataAnnotations;

namespace BowlingProject.Models
{
    public class Team
    {
       [Key]
       [Required]
       public int TeamID { get; set; }
       public string TeamName { get; set; }

    }
}
