using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStoreApplication.Models
{
    public class ProduceOrderModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Produce Produce { get; set; }

    }

    public class Produce
    {
        public Produce()
        {
            this.ProduceOrderModels = new List<ProduceOrderModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }

        public ICollection<ProduceOrderModel> ProduceOrderModels { get; set; }

    }





}