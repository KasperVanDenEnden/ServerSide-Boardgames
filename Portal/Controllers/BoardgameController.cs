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
                var newBoardgame = await _boardgameService.CreateFromModel(model);
                
                var result = await _boardgameRepository.AddBoardgameAsync(newBoardgame);
                if (result)
                {
                    return RedirectToAction("AddBoardgame");
                }
                
            }
            return View(model);
        }
    }
}
