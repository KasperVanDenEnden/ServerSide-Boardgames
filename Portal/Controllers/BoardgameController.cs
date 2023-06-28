using Domain;
using Domainservices.Interfaces.IRepositories;
using Domainservices.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;

namespace Portal.Controllers
{
    public class BoardgameController : Controller
    {
        private readonly IBoardgameRepository _boardgameRepository;
        private readonly IBoardgameService _boardgameService;

        public BoardgameController(IBoardgameRepository boardgameRepository, IBoardgameService boardgameService)
        {
            _boardgameRepository = boardgameRepository;
            _boardgameService = boardgameService;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> Boardgames()
        {
            var boardgames = await _boardgameRepository.GetBoardgamesAsync();
            return View(boardgames);
        }
        public IActionResult AddBoardgame() => View();

        [HttpPost]
        public async Task<IActionResult> AddBoardgame(BoardgameViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null && model.Image.Length > 0)
                {
                    var imageByteArray = await _boardgameService.ConfvertFileToByteArrayAsync(model.Image);

                    var newBoardgame = new Boardgame
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Image = imageByteArray,
                        IsPG18 = model.IsPG18,
                        Gametype = model.Gametype,
                        Genre = model.Genre
                    };

                    var result = await _boardgameRepository.AddBoardgameAsync(newBoardgame);
                    if (result)
                    {
                        return RedirectToAction("AddBoardgame");
                    }
                }
            }
            return View(model);
        }
    }
}
