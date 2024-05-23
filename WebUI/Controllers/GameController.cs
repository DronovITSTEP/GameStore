using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class GameController : Controller
    {
        private IGameRepository repository;
        public int pageSize = 4;
        public GameController(IGameRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult List(int page = 1)
        {
            return View(repository.Games
                .OrderBy(game =>game.Id)
                .Skip((page - 1)*pageSize).
                Take(pageSize));
        }
    }
}