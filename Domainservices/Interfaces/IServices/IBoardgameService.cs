using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IServices
{
    public interface IBoardgameService
    {
        public Task<Boardgame> CreateFromModel(dynamic model);
        public Task<byte[]> ConfvertFileToByteArrayAsync(IFormFile file);
    }
}
