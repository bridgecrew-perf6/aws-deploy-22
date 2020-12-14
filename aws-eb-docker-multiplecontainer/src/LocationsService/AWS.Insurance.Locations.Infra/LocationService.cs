using AWS.Insurance.Locations.Domain.Interfaces;
using AWS.Insurance.Locations.Domain.Models;
using AWS.Insurance.Locations.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWS.Insurance.Locations.Infra
{
    public class LocationService : ILocationService
    {
        public async Task<Location> GetZone(int zipCode)
        {
            var locations = await LoadLocations();
            return locations.FirstOrDefault(x => x.ZipCode == zipCode);
        }

        private async Task<IEnumerable<Location>> LoadLocations()
        {
            var locations = new List<Location>();
            for (int i = 1; i <= 10000; i++)
            {
                locations.Add(new Location()
                {
                    ZipCode = i,
                    Zone = (Zone)GetRandomZone(1, 3)
                });
            }

            //simulate external delay
            await Task.Delay(1000);

            return await Task.FromResult(locations);
        }
        private int GetRandomZone(int minimum, int maximum)
        {
            Random random = new Random();
            return random.Next(minimum, maximum + 1);
        }
    }
}