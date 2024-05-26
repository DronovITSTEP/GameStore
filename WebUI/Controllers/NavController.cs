using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IGameRepository repository;
        public NavController(IGameRepository repository)
        {
            this.repository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = 
                repository.Games
                .Select(x => x.Category.Name)
                .Distinct()
                .OrderBy(x=>x);

            return PartialView(categories);
        }
    }
}