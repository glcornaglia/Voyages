using Xunit;

namespace Voyages.Domain.Tests.Unit
{
    public class FileTests
    {
        

        [Fact]
        public void FileContainsWellBehavedWritableProperties()
        {
            // Arrange
            var expected = new { Id = 1, IdProduct = 2, Type = "Type", ArrivalDate = "ArrivalDate", Duration = 3, FlightNumber = "FlightNumber", Place = "Place", Travelers = 4, Price = 123m};

            var sut = new File();

            // Act
            sut.Id = expected.Id;
            sut.IdProduct = expected.IdProduct;
            sut.Type = expected.Type;
            sut.ArrivalDate = expected.ArrivalDate;
            sut.Duration = expected.Duration;
            sut.FlightNumber = expected.FlightNumber;
            sut.Place = expected.Place;
            sut.Travelers = expected.Travelers;
            sut.Price = expected.Price;

            var actual = new { Id = sut.Id, IdProduct = sut.IdProduct, Type = sut.Type, ArrivalDate = sut.ArrivalDate, Duration = sut.Duration, FlightNumber = sut.FlightNumber, Place = sut.Place, Travelers = sut.Travelers, Price = sut.Price };

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}