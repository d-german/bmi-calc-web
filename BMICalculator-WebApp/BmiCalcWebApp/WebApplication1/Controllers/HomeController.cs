using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BmiCalcWeb.Models;
using BmiCalcWeb.Services;

namespace BmiCalcWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculationFactory _calculationFactory;
        private readonly IInterpretationService _interpretationService;

        public HomeController(ILogger<HomeController> logger, ICalculationFactory calculationFactory, IInterpretationService interpretationService)
        {
            _logger = logger;
            _calculationFactory = calculationFactory;
            _interpretationService = interpretationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index page visited");
            return View();
        }

        [HttpPost]
        public IActionResult Index(WebPageModel model)
        {
            _logger.LogInformation(model.ToString());
            try
            {
                if (!ModelState.IsValid) return View(model);
            
                var calculationService = _calculationFactory.Create(model.MeasurementSystem);

                if (calculationService == null) return View(model);

                model.Person.Bmi = calculationService.CalculateBmi(model.Person);
                model.Person.BmiInterpretation = _interpretationService.InterpretBmi(model.Person.Bmi.Value);
            
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
