using AWS.Insurance.Locations.Domain.Models.Enums;

namespace AWS.Insurance.Locations.Domain.Models
{
    public class Location
    {
        public int ZipCode { get; set; }
        public Zone Zone { get; set; }
    }
}