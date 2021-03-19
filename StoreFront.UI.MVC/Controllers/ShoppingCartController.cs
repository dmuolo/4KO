using StoreFront.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA.EF;

namespace StoreFront.UI.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            if (shoppingCart == null || shoppingCart.Count == 0)
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
                ViewBag.Message = "There are no movies in your cart.";
            }
            else
            {
                ViewBag.Message = null;
            }

            return View(shoppingCart);
        }

        public ActionResult UpdateCart(int movieID, int qty)
        {
            if (qty == 0)
            {
                RemoveFromCart(movieID);

                return RedirectToAction("Index");
            }

            Dictionary<int, CartItemViewModel> shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            shoppingCart[movieID].Qty = qty;

            Session["cart"] = shoppingCart;

            if (shoppingCart.Count == 0)
            {
                ViewBag.Message = "There are no movies in your cart";
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            Dictionary<int, CartItemViewModel> shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            shoppingCart.Remove(id);

            if (shoppingCart.Count == 0)
            {
                Session["cart"] = null;
            }

            return RedirectToAction("Index");
        }
    }
}