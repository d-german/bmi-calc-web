using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BmiCalcWeb.Models;
using BmiCalcWeb.Services;

namespace BmiCalcWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(WebPageModel model)
        {
            ICalculationService? calculationService = null;
            IInterpretationService interpretationService = new InterpretationService();
            if (ModelState.IsValid)
            {
                if(model.measurementSystem == MeasurementSystem.US)
                {
                    calculationService = new USCalculationService();
                }
                else
                {
                    calculationService = new MetricCalculationService();
                }
                model.person.Bmi = calculationService.CalculateBmi(model.person);
                model.person.BmiInterpretation = interpretationService.InterpretBmi(model.person.Bmi.Value);
            }
            
            return View(model);
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