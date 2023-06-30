using Domain;
using Domainservices.Interfaces.IRepositories;
using Domainservices.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;

namespace Portal.Controllers
{
    public class GamenightController : Controller
    {
        private readonly IGamenightRepository _gamenightRepository;
        private readonly IBoardgameRepository _boardgameRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGamenightService _gamenightService;

        public GamenightController(IGamenightRepository gamenightRepository, IBoardgameRepository boardgameRepository, IUserRepository userRepository, IGamenightService gamenightService) {
            _gamenightRepository = gamenightRepository;
            _boardgameRepository = boardgameRepository;
            _userRepository = userRepository;
            _gamenightService = gamenightService;
        }


        public async Task<IActionResult> Gamenights()
        {
            var gamenights = await _gamenightRepository.GetGamenightsAsync();
            return View(gamenights);
        }

        public async Task<IActionResult> Hosted()
        {
            var hosted = await _gamenightRepository.GetGamenightsHostingAsync(User.Identity.Name);
            return View(hosted);
        }

        public async Task<IActionResult> Participating()
        {
            var userId = await _userRepository.GetUserIdAsync(User.Identity.Name);
            var participating = await _gamenightRepository.GetGamenightsParticipatingAsync(userId);
            // You probably get List of Id numbers above, so we need to get the actual gamenights based on the Id's
            // First we have to implement participating tough!
            return View(participating);
        }
        public async Task<IActionResult> Organise()
        {
            ViewBag.Boardgames = await _boardgameRepository.GetBoardgamesAsync();
            var viewModel = new GamenightViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Organise(GamenightViewModel model)
        {
            var boardgamesList = await _boardgameRepository.GetBoardgamesAsync();
            if (ModelState.IsValid)
            {
                var host = await _userRepository.GetUserAsync(User.Identity.Name);

                if (host != null)
                {
                    var newGamenight = _gamenightService.CreateFromModel(model, host.Id, boardgamesList);
                    // Process the submitted form data
                    var gamenight = await _gamenightRepository.AddGamenightAsync(newGamenight);

                    await _gamenightRepository.AddGamenightBoardgameAsync(gamenight.Id, model.SelectedBoardgameIds);

                    // Redirect to a success page or perform other actions
                    return RedirectToAction("Hosted","Gamenight");
                }
            }

            ViewBag.Boardgames = boardgamesList;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Detail([FromForm] int gamenightId)
        {
            var gamenight = await _gamenightRepository.GetGamenightAsync(gamenightId);
            return View(gamenight);
        }

        // Detail page button actions
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int gamenightId)
        {
            var gamenight = await _gamenightRepository.GetGamenightAsync(gamenightId);
            if (_gamenightService.DeleteAllowed(gamenight))
            {

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Participate([FromForm] int gamenightId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UnParticipate([FromForm] int gamenightId)
        {
            return View();
        }



    }
}
