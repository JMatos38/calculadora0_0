using calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Calculadora.Controllers
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
            //prepara o valor inicial do visor
            ViewBag.Visor = "0";
            return View();
        }

        [HttpPost]
        public IActionResult Index(string botao, string visor)
        {

            switch (botao)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    //atribui ao 'visor' o valor do 'botão'
                    if (visor == "0") visor = botao;
                    else visor = visor + botao;
                    break;

                case "+/-":
                    //faz a inversão do valor do visor
                    if (visor.StartsWith('-')) visor = visor.Substring(1);
                    else visor = '-' + visor;
                    break;

                case ",":
                    if (!visor.Contains(',')) visor += ",";
                    break;

                case "+":
                case "-":
                case "x":
                case ":":
                    string primeiroOperando = '';
                    string Operador = "";
                    string limpaVisor ="Sim"



                    break;
            }//fim do switch

            //enviar o valor do visor para a view
            ViewBag.Visor = visor;
            ViewBag.PrimeiroOperador = "Nao";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}