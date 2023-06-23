using Domain.Many_To_Many;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User 
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

        public List<Gamenight> HostedGamenights { get; set; }
        public List<Participating> ParticipatingGamenights { get; set; }

    }
}