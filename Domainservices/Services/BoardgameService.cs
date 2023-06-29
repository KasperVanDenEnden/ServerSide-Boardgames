using Domain;
using Domainservices.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Services
{
    public class BoardgameService : IBoardgameService
    {
        public async Task<byte[]> ConfvertFileToByteArrayAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public async Task<Boardgame> CreateFromModel(dynamic model)
        {
            if (model.Image != null && model.Image.Length > 0)
            {
                var imageByteArray = await this.ConfvertFileToByteArrayAsync(model.Image);
                var newBoardgame = new Boardgame
                {
                    Name = model.Name,
                    Description = model.Description,
                    Image = imageByteArray,
                    IsPG18 = model.IsPG18,
                    Gametype = model.Gametype,
                    Genre = model.Genre
                };
                return newBoardgame;
            }
            throw new NotImplementedException();
        }
    }
}
