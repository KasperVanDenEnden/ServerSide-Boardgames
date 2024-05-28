using Domain.Many_To_Many;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User 
    {
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public List<Gamenight> HostedGamenights { get; set; }
        public List<Participating> ParticipatingGamenights { get; set; }

    }
}