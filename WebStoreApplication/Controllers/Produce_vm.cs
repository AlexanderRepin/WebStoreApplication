using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStoreApplication.Controllers
{
    public class ProduceList
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
    }

    public class ProduceAdd
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
    }

    public class ProduceBase : ProduceAdd
    {
        public int Id { get; set; }
    }

    public class ProduceBaseWithOrder : ProduceBase
    {
        public ProduceBaseWithOrder()
        {
            this.ProduceOrderModels = new List<OrderBase>();

        }
        public IEnumerable<OrderBase> ProduceOrderModels { get; set; }
    }
}