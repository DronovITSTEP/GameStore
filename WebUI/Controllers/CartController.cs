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
    public class CartController : Controller
    {
        private IGameRepository gameRepository;
        public CartController (IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public ViewResult Index(string returnUrl) {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(
            int Id, string returnUrl)
        {
            Game game = gameRepository.Games
                .FirstOrDefault(x => x.Id == Id);

            if (game != null) {
                GetCart().AddItem(game, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }
        public RedirectToRouteResult RemoveFromCart(int Id,
            string returnUrl)
        {
            Game game = gameRepository.Games
               .FirstOrDefault(x => x.Id == Id);

            if (game != null)
            {
                GetCart().RemoveItem(game);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public PartialViewResult Summary (Cart cart)
        {
            return PartialView(GetCart());
        }
    }
}