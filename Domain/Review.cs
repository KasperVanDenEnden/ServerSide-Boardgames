using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Username { get; set; }





        // Relations
        public int GamenightId { get; set; }
        public Gamenight Gamenight { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
