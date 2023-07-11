using Domain;
using Domainservices.Interfaces.IRepositories;
using Domainservices.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace Portal.Controllers
{
    public class GamenightController : Controller
    {
        private readonly IGamenightRepository _gamenightRepository;
        private readonly IBoardgameRepository _boardgameRepository;
        private readonly IParticipatingRepository _participatingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReviewRepository _reviewRepository;

        private readonly IGamenightService _gamenightService;
        private readonly IParticipatingService _participatingService;
        private readonly IReviewService _reviewService;

        public GamenightController(
            IGamenightRepository gamenightRepository,
            IBoardgameRepository boardgameRepository,
            IParticipatingRepository participatingRepository,
            IUserRepository userRepository,
            IReviewRepository reviewRepository,
            IGamenightService gamenightService,
            IParticipatingService participatingService,
            IReviewService reviewService)
        {
            _gamenightRepository = gamenightRepository;
            _boardgameRepository = boardgameRepository;
            _participatingRepository = participatingRepository;
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
            _gamenightService = gamenightService;
            _participatingService = participatingService;
            _reviewService = reviewService;
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
            var boardgameList = await _boardgameRepository.GetBoardgamesAsync();
            if (ModelState.IsValid)
            {
                var host = await _userRepository.GetUserAsync(User.Identity.Name);
                if (host != null)
                {
                    var newGamenight = _gamenightService.CreateFromModel(model, host.Id, boardgameList);
                    // Process the submitted form data
                    var gamenight = await _gamenightRepository.AddGamenightAsync(newGamenight);
                    await _gamenightRepository.AddGamenightBoardgameAsync(gamenight.Id, model.SelectedBoardgameIds);
                    // Redirect to a success page or perform other actions
                    return RedirectToAction("Hosted", "Gamenight");
                }
            }
            ViewBag.Boardgames = boardgameList;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] int gamenightId)
        {
            var gamenight = await _gamenightRepository.GetGamenightAsync(gamenightId);
            if (_gamenightService.EditOrDeleteAllowed(gamenight))
            {

                var viewModel = new GamenightViewModel
                {
                    Id = gamenight.Id,
                    Title = gamenight.Name,
                    Description = gamenight.Description,
                    Date = gamenight.DateTime,
                    Time = new TimeSpan(gamenight.DateTime.Hour, gamenight.DateTime.Minute, gamenight.DateTime.Second),
                    IsPG18 = gamenight.IsPG18,
                    MaxParticipants = gamenight.MaxParticipants,
                    Street = gamenight.Address.Street,
                    Housenumber = gamenight.Address.Housenumber,
                    City = gamenight.Address.City,
                    Postal = gamenight.Address.Postal,
                    SelectedBoardgameIds = gamenight.Boardgames?.Select(p => p.BoardgameId).ToList() ?? new List<int>()
                };
                var boardgamesList = await _boardgameRepository.GetBoardgamesAsync();
                ViewBag.Boardgames = boardgamesList;
                return View((GamenightViewModel)viewModel);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Update(GamenightViewModel updatedModel)
        {
            if (ModelState.IsValid)
            {
                var gamenight = await _gamenightRepository.GetGamenightAsync(updatedModel.Id);
                var boardgameList = await _boardgameRepository.GetBoardgamesAsync();
                var updatedGamenight = _gamenightService.CreateUpdatedGamenightFromModel(updatedModel, gamenight, boardgameList);

                await _gamenightRepository.UpdateGamenightAsync(gamenight);

                return RedirectToAction("Detail", new { gamenightId = updatedGamenight.Id });
            }
            return RedirectToAction("Edit", updatedModel);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int gamenightId)
        {
            var gamenight = await _gamenightRepository.GetGamenightAsync(gamenightId);

            var viewModel = new GamenightDetailViewModel
            {
                Gamenight = gamenight,
                Review = new ReviewViewModel
                {
                    GamenightId = gamenightId,
                }
            };
            var hostReviews = await _reviewRepository.GetAllReviewsForHost(await _gamenightRepository.GetHostGamenightIds(gamenight.HostId));
            ViewBag.ReviewCalculations = _reviewService.CalculateTotalAndAverageScoreForHost(hostReviews);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(ReviewViewModel reviewModel)
        {
                if (ModelState.IsValid)
            {
                var userId = await _userRepository.GetUserIdAsync(User.Identity.Name);
                var review = _reviewService.CreateFromModel(reviewModel, userId, reviewModel.GamenightId, User.Identity.Name);

                var posted = await _reviewRepository.AddReview(review);

                return RedirectToAction("Detail", new { gamenightId = reviewModel.GamenightId });
            }

            var gamenight = await _gamenightRepository.GetGamenightAsync(reviewModel.GamenightId);
            var viewModel = new GamenightDetailViewModel
            {
                Gamenight = gamenight,
                Review = reviewModel
            };
            var hostReviews = await _reviewRepository.GetAllReviewsForHost(await _gamenightRepository.GetHostGamenightIds(gamenight.HostId));
            ViewBag.ReviewCalculations = _reviewService.CalculateTotalAndAverageScoreForHost(hostReviews);

            // Manually validate the ReviewViewModel to display the validation errors
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(viewModel.Review);
            Validator.TryValidateObject(viewModel.Review, validationContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                ModelState.AddModelError($"Review.{validationResult.MemberNames.First()}", validationResult.ErrorMessage);
            }
            
            return View(viewModel);
        }

        // Detail page button actions
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int gamenightId)
        {
            var gamenight = await _gamenightRepository.GetGamenightAsync(gamenightId);
            if (_gamenightService.EditOrDeleteAllowed(gamenight))
            {
                await _gamenightRepository.RemoveGamenightAsync(gamenightId);
            }
            return RedirectToAction("Hosted", "Gamenight");
        }

        [HttpPost]
        public async Task<IActionResult> Participate([FromForm] int gamenightId)
        {
            var gamenight = await _gamenightRepository.GetGamenightAsync(gamenightId);
            var user = await _userRepository.GetUserAsync(User.Identity.Name);
            if (user != null || gamenight != null)
            {
                if (_participatingService.ParticipateAllowed(gamenight, user))
                {
                    var participating = await _participatingRepository.Participate(_gamenightService.CreateNewParticipatingClass(gamenightId, user.Id));
                }
            }
            return RedirectToAction("Detail", gamenightId);
        }


        [HttpPost]
        public async Task<IActionResult> UnParticipate([FromForm] int gamenightId)
        {
            var gamenight = await _gamenightRepository.GetGamenightAsync(gamenightId);
            var userId = await _userRepository.GetUserIdAsync(User.Identity.Name);
            if (userId != null || gamenight != null)
            {
                if (_participatingService.UnParticipateAllowed(gamenight, userId))
                {
                    var unparticipating = await _participatingRepository.UnParticipate(gamenightId, userId);
                }
            }
            return RedirectToAction("Detail", gamenightId);
        }
    }
}
