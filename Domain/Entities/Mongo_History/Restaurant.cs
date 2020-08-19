using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace Domain.Entities

{
    public class Restaurant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[] Thumbnail { get; set; }
        public double Rating { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public TimeSpan TimeOpen { get; set; }
        public TimeSpan TimeClose { get; set; }
        public Coordinates2D Location { get; set; }
        public IEnumerable<RestaurantTag> Tags { get; set; }
        public IEnumerable<RestaurantWorkDay> WorkDays { get; set; }
        public IEnumerable<RestaurantSpecificOff> DaysOff { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public Restaurant(string name, byte[] thumbnail, double latitude, double longitude, TimeSpan timeOpen, TimeSpan timeClose, IEnumerable<string> tags)
        {
            Name = name;
            Thumbnail = thumbnail;
            Location = new Coordinates2D(longitude, latitude);
            Latitude = latitude;
            Longitude = longitude;
            Rating = new Random().Next(1, 5);
            WorkDays = new List<RestaurantWorkDay>();
            DaysOff = new List<RestaurantSpecificOff>();
            Comments = new List<Comment>();
            TimeOpen = timeOpen;
            TimeClose = timeClose;

            if (tags != null && tags.Count() > 0) Tags = tags.Select(x => new RestaurantTag { Name = x });
        }
    }
}