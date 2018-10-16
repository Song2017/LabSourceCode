using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //public string Index()
        //{
        //    return "this is default string: hello world.";
        //}
        //public string Welcome()
        //{
        //    return "Welcome to Asp.Net.";
        //}
        //public string Welcome(string name, int numTimes = 1)
        //{
        //    return System.Text.Encodings.Web.HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        //}

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }


    }
}
