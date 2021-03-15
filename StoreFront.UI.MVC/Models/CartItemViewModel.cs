using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreFront.DATA.EF;
using System.ComponentModel.DataAnnotations;


namespace StoreFront.UI.MVC.Models
{
    public class CartItemViewModel
    {
        [Range(1,byte.MaxValue,ErrorMessage = "* Please enter a Quantity between 1 and 255. *")]
        public int Qty { get; set; }

        public MovieTitle Product { get; set; }

        public CartItemViewModel(int qty, MovieTitle product)
        {
            Qty = qty;
            Product = product;
        }
    }
}