using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        IGameRepository gameRepository;

        public AdminController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public ViewResult Index()
        {
            return View(gameRepository.Games);
        }
        public ViewResult Edit(int id)
        {
            Game game = gameRepository.Games
                .FirstOrDefault(x => x.Id == id);
            return View(game);
        }
        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                gameRepository.SaveGame(game);
                TempData["message"] = string.Format("Изменения в игре " +
                    "\"{0}\" были сохранены", game.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(game);
            }
        }
    }
}