using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IServices
{
    public interface IGamenightService
    {
        public Gamenight CreateFromModel(dynamic model, int hostId, List<Boardgame> boardgameList);
        public Address CreateAddressFromModel(dynamic model);
        public Gamenight CheckOnPG18Boardgames(Gamenight gamenight, List<int> selectedBoardgames, List<Boardgame> boargameList);
        public byte[] SetImage(List<int> selectedBoardgameIds, List<Boardgame> boardgameList);
    }
}
