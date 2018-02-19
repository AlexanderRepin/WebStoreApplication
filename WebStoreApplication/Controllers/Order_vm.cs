using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStoreApplication.Controllers
{
    /*
    public class OrderAddForm
    {
        public int Quantity { get; set; }
        //public double Price { get; set; }
    }
    */
    public class OrderAdd
    {
        public int ProduceId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class OrderBase
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class OrderBaseWithProduce : OrderBase
    {
        public ProduceBase Produce { get; set; }

    }
}