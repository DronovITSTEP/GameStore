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
        private IOrderProcessor processor;
        public CartController (IGameRepository gameRepository,
            IOrderProcessor processor)
        {
            this.gameRepository = gameRepository;
            this.processor = processor;
        }

        public ViewResult Index(Cart cart, string returnUrl) {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(
            Cart cart, int Id, string returnUrl)
        {
            Game game = gameRepository.Games
                .FirstOrDefault(x => x.Id == Id);

            if (game != null) {
                cart.AddItem(game, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id,
            string returnUrl)
        {
            Game game = gameRepository.Games
               .FirstOrDefault(x => x.Id == Id);

            if (game != null)
            {
                cart.RemoveItem(game);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
      

        public PartialViewResult Summary (Cart cart)
        {
            return PartialView(cart);
        }

        
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Ваша корзина пуста!");

            if (ModelState.IsValid)
            {
                processor.ProcessorOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}