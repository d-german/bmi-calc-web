using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using BmiCalcWeb.Data;
using BmiCalcWeb.Models;

namespace BmiCalcWeb.Controllers
{
    [SuppressMessage("Usage", "CA2254:Template should be a static expression")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBmiRepository _bmiRepository;

        public HomeController(ILogger<HomeController> logger, IBmiRepository bmiRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bmiRepository = bmiRepository ?? throw new ArgumentNullException(nameof(bmiRepository));
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index page visited");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(WebPageModel model)
        {
            _logger.LogInformation(model.ToString());
            try
            {
                model = model with { Person = await _bmiRepository.GetBmiAsync(model.Person, model.MeasurementSystem) };

                _logger.LogInformation(model.ToString());

                return View(model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Request encountered an error, {StatusCodes.Status500InternalServerError} response sent.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
