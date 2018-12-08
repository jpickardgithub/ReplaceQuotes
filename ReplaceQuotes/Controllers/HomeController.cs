using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReplaceQuotes.Models;

namespace ReplaceQuotes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            TextModel model = new TextModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult index(TextModel model)
        {
            TextModel output = new TextModel();
            if (!string.IsNullOrWhiteSpace(model.InputText))
            {
                output.InputText = model.InputText;
                string inputText = model.InputText;
                output.OutputText = Replace(inputText);
            }
            return View(output);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string Replace(string input)
        {
            string output = input.Replace("\"", "'");
            return output;
        }
    }
}
