using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Many_To_Many
{
    public class Participating
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int GamenightId { get; set; }
        public Gamenight Gamenight { get; set; }
    }
}
