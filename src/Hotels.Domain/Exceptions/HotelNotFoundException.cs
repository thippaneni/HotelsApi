using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Domain.Exceptions
{
    public class HotelNotFoundException : Exception
    {
        public Guid HotelId { get; }
        public HotelNotFoundException(Guid hotelId) 
            : base($"Hotel with ID {hotelId} was not found.")
        {
            HotelId = hotelId;
        }
        public HotelNotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        public HotelNotFoundException()
        {
        }
    }
}
