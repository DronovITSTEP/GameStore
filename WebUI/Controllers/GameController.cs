using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

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
        public ViewResult List(string category, int page = 1)
        {
            GamesListViewModel model = new GamesListViewModel
            {
                Games = repository.Games
                .ToList()
                .Where(p => category == null || p.Category.Name == category)
                .OrderBy(game => game.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? 
                    repository.Games.Count() :
                    repository.Games
                    .ToList()
                    .Where(game => game.Category.Name == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}