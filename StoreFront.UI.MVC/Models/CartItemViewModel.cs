using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreFront.DATA.EF;


namespace StoreFront.UI.MVC.Models
{
    public class CartItemViewModel
    {
        public int Qty { get; set; }
        public MovieTitle Product { get; set; }

        public CartItemViewModel(int qty, MovieTitle product)
        {
            Qty = qty;
            Product = product;
        }
    }
}