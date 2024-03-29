using System.Collections.Generic;
using Domain.Entities;

namespace Infra.Repository.Interface
{
    public interface IRestaurantRepository
    {
        Restaurant Create(Restaurant restaurant);
        IEnumerable<Restaurant> List(IEnumerable<string> tags, double longitude, double latitude, double distance);
    }
}