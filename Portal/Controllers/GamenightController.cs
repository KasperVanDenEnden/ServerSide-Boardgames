using Domainservices.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Controllers
{
    public class GamenightController : Controller
    {
        private readonly IGamenightRepository _gamenightRepository;
        public GamenightController(IGamenightRepository gamenightRepository) {
            _gamenightRepository = gamenightRepository;
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
            var participating = await _gamenightRepository.GetGamenightsParticipatingAsync(User.Identity.Name);
            // You probably get List of Id numbers above, so we need to get the actual gamenights based on the Id's
            // First we have to implement participating tough!
            return View(participating);
        }

        public IActionResult Organise()
        {
            return View();
        }

        //[HttpPost]
        //public Task<IActionResult> Organise(GamenightViewModel model)
        //{
        //    return
        //}
    }
}
