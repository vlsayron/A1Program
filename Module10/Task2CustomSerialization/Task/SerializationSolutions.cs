﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.DB;
using Task.TestHelpers;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

namespace Task
{
	[TestClass]
	public class SerializationSolutions
	{
        private Northwind _dbContext;

		[TestInitialize]
		public void Initialize()
		{
			_dbContext = new Northwind();
		}

		[TestMethod]
		public void SerializationCallbacks()
		{
			_dbContext.Configuration.ProxyCreationEnabled = false;

			var tester = new XmlDataContractSerializerTester<IEnumerable<Category>>(new NetDataContractSerializer(), true);
			var categories = _dbContext.Categories.ToList();

			var c = categories.First();

			tester.SerializeAndDeserialize(categories);
		}

		[TestMethod]
		public void ISerializable()
		{
			_dbContext.Configuration.ProxyCreationEnabled = false;

			var tester = new XmlDataContractSerializerTester<IEnumerable<Product>>(new NetDataContractSerializer(), true);
			var products = _dbContext.Products.ToList();

			tester.SerializeAndDeserialize(products);
		}


		[TestMethod]
		public void ISerializationSurrogate()
		{
			_dbContext.Configuration.ProxyCreationEnabled = false;

			var tester = new XmlDataContractSerializerTester<IEnumerable<OrderDetail>>(new NetDataContractSerializer(), true);
			var orderDetails = _dbContext.OrderDetails.ToList();

			tester.SerializeAndDeserialize(orderDetails);
		}

		[TestMethod]
        public void IDataContractSurrogate()
        {
            _dbContext.Configuration.ProxyCreationEnabled = true;
            _dbContext.Configuration.LazyLoadingEnabled = true;

            var knownTypes = new List<Type>
            {
                typeof(Category),
                typeof(Customer),
                typeof(CustomerDemographic),
                typeof(Employee),
                typeof(Northwind),
                typeof(Order),
                typeof(OrderDetail),
                typeof(Product),
                typeof(Region),
                typeof(Shipper),
                typeof(Supplier),
                typeof(Territory)
            };

			var typeSettings = new DataContractSerializerSettings()
            {
                DataContractResolver = new ProxyDataContractResolver(),
                KnownTypes = knownTypes
            };

            var tester = new XmlDataContractSerializerTester<IEnumerable<Order>>(new DataContractSerializer(typeof(IEnumerable<Order>), typeSettings), true);
            var orders = _dbContext.Orders.ToList();

            tester.SerializeAndDeserialize(orders);
        }
	}
}
