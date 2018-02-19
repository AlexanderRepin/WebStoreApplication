using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biggy.Core;
using Biggy.Data.Json;
using AutoMapper;

using WebStoreApplication.Models;


namespace WebStoreApplication.Controllers
{
    public class Manager
    {
        private JsonStore<ProduceOrderModel> orderStore;
        private BiggyList<ProduceOrderModel> orders;
        private JsonStore<Produce> produceStore;
        private BiggyList<Produce> producers;

        public IEnumerable<OrderBase> AllOrders
        {
            get { return Mapper.Map<IEnumerable<OrderBase>>(orders.OrderBy(orderId => orderId.Id)); }
        }

        internal object GetOrderById(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProduceBase> AllProduce
        {
            get { return Mapper.Map<IEnumerable<ProduceBase>>(producers.OrderBy(producersName => producersName.Name)); }

        }
        public IEnumerable<ProduceList> ListOfProduce
        {
            get { return Mapper.Map<IEnumerable<ProduceList>>(producers.OrderBy(producersName => producersName.Name)); }

        }

        public Manager()
        {
            Mapper.CreateMap<ProduceOrderModel, OrderBase>();
            Mapper.CreateMap<ProduceOrderModel, OrderBaseWithProduce>();
            Mapper.CreateMap<OrderAdd, ProduceOrderModel>();
            Mapper.CreateMap<Produce, ProduceBase>();
            Mapper.CreateMap<Produce, ProduceBaseWithOrder>();
            Mapper.CreateMap<Produce, ProduceList>();
            Mapper.CreateMap<ProduceAdd, Produce>();

            var localData = HttpContext.Current.Server.MapPath("~/App_Data");

            orderStore = new JsonStore<ProduceOrderModel>(localData, "WebStoreApplication", "orders");
            orders = new BiggyList<ProduceOrderModel>(orderStore);

            produceStore = new JsonStore<Produce>(localData, "WebStoreApplication", "producers");
            producers = new BiggyList<Produce>(produceStore);

        }

        public OrderBase AddOrder(OrderBase newItem)
        {
            /////
            int newId = (orders.Count > 0) ? newId = orders.Max(id => id.Id) + 1 : 1;

            // Ensure that the new item's association property is value
            var associatedObject = producers.SingleOrDefault(i => i.Id == newItem.Id);


            if (associatedObject == null)
            {

                return null;
            }

            var addedItem = new ProduceOrderModel
            {
                Id = newId,
                Produce = associatedObject
            };

            addedItem.Price = newItem.Price;
            addedItem.Quantity += 1;

            orders.Add(addedItem);

            return Mapper.Map<OrderBase>(addedItem);

        }

        public OrderBase AddToCart(ProduceBase newItem)
        {

            int newId = (orders.Count > 0) ? newId = orders.Max(id => id.Id) + 1 : 1;


            // Create a new item; notice the property mapping
            
            var addedItem = new ProduceOrderModel
            {
                Id = newId,
                Price = newItem.Price,


            };

            addedItem.Id = newId;
            addedItem.Price = newItem.Price;
            addedItem.Quantity += 1;


            // Return the new item
            return Mapper.Map<OrderBase>(addedItem);
        }

        public OrderBase GetOrderById(int id)
        {
            // Attempt to fetch the item
            var fetchedObject = orders.SingleOrDefault(i => i.Id == id);

            // Return the result
            return (fetchedObject == null) ? null : Mapper.Map<OrderBase>(fetchedObject);
        }


        public IEnumerable<OrderBaseWithProduce> AllOrdersWithProduce()
        {
            // Fetch the collection
            var fetchedObjects = orders.OrderBy(orderId => orderId.Id).AsEnumerable();
            return Mapper.Map<IEnumerable<OrderBaseWithProduce>>(fetchedObjects);
        }

        public ProduceBase AddProduce(ProduceAdd newItem)
        {

            int newId = (producers.Count > 0) ? newId = producers.Max(id => id.Id) + 1 : 1;

            // Create a new item; notice the property mapping
            var addedItem = new Produce
            {
                Id = newId,
                Name = newItem.Name,
                Location = newItem.Location,
                Price = newItem.Price
            };

            producers.Add(addedItem);

            return Mapper.Map<ProduceBase>(addedItem);

        }

        public ProduceBase GetProduceById(int id)
        {
            // Attempt to fetch the item
            var fetchedObject = producers.SingleOrDefault(i => i.Id == id);

            // Return the result
            return (fetchedObject == null) ? null : Mapper.Map<ProduceBase>(fetchedObject);
        }

    }
}