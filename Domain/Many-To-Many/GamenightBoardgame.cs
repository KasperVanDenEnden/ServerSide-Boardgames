using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Many_To_Many
{
    public class GamenightBoardgame
    {
        public int GamenightId { get; set; }
        public Gamenight Gamenight { get; set; }

        public int BoardgameId { get; set; }
        public Boardgame Boardgame { get; set; }
    }
}
