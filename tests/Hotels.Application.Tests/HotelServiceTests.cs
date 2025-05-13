using FluentAssertions;
using Hotels.Application.Interafces;
using Hotels.Application.Services;
using Hotels.Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;


namespace Hotels.Application.Tests
{
    public class HotelServiceTests
    {
        private readonly Mock<IHotelRepository> _hotelRepo;
        private readonly Mock<ILogger<HotelService>> _logger;

        private readonly HotelService _hotelService;
        public HotelServiceTests()
        {
            _hotelRepo = new Mock<IHotelRepository>();
            _logger = new Mock<ILogger<HotelService>>();
            _hotelService = new HotelService(_hotelRepo.Object, _logger.Object);
        }

        [Fact]
        public async Task CreateAsync_Should_Add_Hotel_And_Return_It()
        {
            // Arrange
            var hotel = new Hotel
            {
                Address = "Test Address",
                CreatedBy = "Test User",
                Name = " Test Hotel1",
                Description = "Test Hotel Desc",
                Stars = 3
            };

            _hotelRepo
              .Setup(r => r.AddAsync(It.IsAny<Hotel>()))
              .ReturnsAsync(hotel);

            // Act
            var result = await _hotelService.CreateAsync(hotel);
            
            // Assert
            result.Should().BeSameAs(hotel);
            _hotelRepo.Verify(r => r.AddAsync(hotel), Times.Once);
        }
       
        [Fact]
        public async Task CreateAsync_Should_Throws_Exception_When_Hotel_Is_Empty()
        {
            // Arrange
            var hotel = new Hotel
            {
                Address = "Test Address",
                CreatedBy = "Test User",
                Name = "",
                Description = "Test Hotel Desc",
                Stars = 3
            };
            _hotelRepo
              .Setup(r => r.AddAsync(It.IsAny<Hotel>()))
              .ReturnsAsync(hotel);

            // Act
            Func<Task> result = async () => await _hotelService.CreateAsync(hotel);


            // Assert
            await result.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Hotel name cannot be null or empty");
            _hotelRepo.Verify(r => r.AddAsync(hotel), Times.Never);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public async Task CreateAsync_WithInvalidStars_ThrowsArgumentOutOfRangeException(int stars)
        {
            // Arrange
            var hotel = new Hotel { Name = "Invalid Stars Hotel", Stars = stars };

            // Act
            Func<Task> act = async () => await _hotelService.CreateAsync(hotel);

            // Assert
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>()                
                .WithMessage("Hotel stars must be between 1 and 5 (Parameter 'Stars')");

            _hotelRepo.Verify(r => r.AddAsync(hotel), Times.Never);
        }
    }
}
