using System.Collections.Generic;
using System.Linq;
using Domain;
using Infra.Repository.Interface;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Entities;

namespace Infra.Repository.Implementation
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IMongoCollection<Restaurant> _restaurants;

        public RestaurantRepository()
        {
            var client = new MongoClient("mongodb+srv://foodpiloto:FoodPiloto!012569@cluster0-9vkd9.gcp.mongodb.net/FoodPiloto?retryWrites=true&w=majority");
            var database = client.GetDatabase("FoodPiloto");

            //new DB("FoodPiloto", "mongodb+srv://foodpiloto:FoodPiloto!012569@cluster0-9vkd9.gcp.mongodb.net");

            _restaurants = database.GetCollection<Restaurant>("Restaurant");
        }

        public Restaurant Create(Restaurant restaurant)
        {
            _restaurants.InsertOne(restaurant);
            return restaurant;
        }

        public IEnumerable<Restaurant> List(IEnumerable<string> tags, double longitude, double latitude, double distance)
        {
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));
            var filter = Builders<Restaurant>.Filter.Near(r => r.Location, point, distance * 1000);

            if (tags != null)
            {
                var filter2 = Builders<Restaurant>.Filter.ElemMatch(x => x.Tags, y => tags.Contains(y.Name));
                filter = filter & filter2;
            }

            return _restaurants.Find(filter).ToList();
        }
    }
}