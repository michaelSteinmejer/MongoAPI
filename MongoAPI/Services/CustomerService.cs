using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoAPI.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("myfirstmongodb"));
            var database = client.GetDatabase("myfirstmongodb");
            _customers = database.GetCollection<Customer>("customer");
        }

        public List<Customer> Get()
        {
            return _customers.Find(Customer => true).ToList();
        }

        public Customer Get(string id)
        {
            var docId = new ObjectId(id);

            return _customers.Find<Customer>(Customer => Customer.Id == docId).FirstOrDefault();
        }

        public Customer Create(Customer Customer)
        {
            _customers.InsertOne(Customer);
            return Customer;
        }

        public void Update(string id, Customer CustomerIn)
        {
            var docId = new ObjectId(id);

            _customers.ReplaceOne(Customer => Customer.Id == docId, CustomerIn);
        }

        public void Remove(Customer CustomerIn)
        {
            _customers.DeleteOne(Customer => Customer.Id == CustomerIn.Id);
        }

        public void Remove(ObjectId id)
        {
            _customers.DeleteOne(Customer => Customer.Id == id);
        }
    }
}
