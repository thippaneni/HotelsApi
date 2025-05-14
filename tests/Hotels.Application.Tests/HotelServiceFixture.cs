using Hotels.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Tests
{
    public class HotelServiceFixture
    {
        public HotelServiceFixture()
        {
            // Initialize any shared resources or setup code here
        }
        public void Dispose()
        {
            // Clean up any shared resources here
        }
        public static IEnumerable<object[]> GetHotels()
        {
            yield return new object[] { new List<Hotel>() };
            yield return new object[] { new List<Hotel> { new Hotel() } };
            yield return new object[] { new List<Hotel> { new Hotel(), new Hotel() } };
        }

        public static Hotel GetHotel()
        {
            return new Hotel
            {
                Address = "Test Address",
                CreatedBy = "Test User",
                Name = "Test Hotel",
                Description = "Test Hotel Desc",
                Stars = 3
            };
        }
    }
}
