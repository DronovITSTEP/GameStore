using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
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
        public ActionResult Edit(Game game, HttpPostedFileBase image = null )
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    game.ImageData = new byte[image.ContentLength];
                    game.ImageMimeType = image.ContentType;

                    image.InputStream.Read(game.ImageData,
                        0, image.ContentLength);
                }
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
        public ViewResult Create()
        {
            return View("Edit", new Game());
        }
        [HttpPost]
        public ActionResult Delete(int id) { 
            Game deleteGame = gameRepository.DeleteGame(id);
            if (deleteGame != null)
            {
                TempData["message"] =
                    string.Format("Игра \"{0}\" была удалена", deleteGame.Name);
            }
            return RedirectToAction("Index");
        }
    }
}