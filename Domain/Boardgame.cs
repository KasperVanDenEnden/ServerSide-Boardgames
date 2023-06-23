using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Boardgame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EGenre Genre { get; set; }
        public bool IsPG18 { get; set; }
        public byte[] Image { get; set; }
        public EGametype Gametype { get; set; }
    }
}
