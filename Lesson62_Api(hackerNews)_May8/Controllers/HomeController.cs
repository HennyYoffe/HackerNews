using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson62_Api_hackerNews__May8.Models;
using ClassLibrary1;

namespace Lesson62_Api_hackerNews__May8.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var api = new HackerNewsApi();
            List<HackerNews> hn = api.Get20News();
            return View(hn);
        }

     

       
    }
}
