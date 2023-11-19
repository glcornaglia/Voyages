using Xunit;

namespace Voyages.Domain.Tests.Unit
{
    public class ProductTests
    {
        

        [Fact]
        public void ProductContainsWellBehavedWritableProperties()
        {
            // Arrange
            var expected = new { Id = 1, Type = "Type", Name = "Name", Description = "Description", Address = "Address", Telephone = "Telephone", PhotoLink = "PhotoLink" };

            var sut = new Product();

            // Act
            sut.Id = expected.Id;
            sut.Type = expected.Type;
            sut.Name = expected.Name;
            sut.Description = expected.Description;
            sut.Address = expected.Address;
            sut.Telephone = expected.Telephone;
            sut.PhotoLink = expected.PhotoLink;

            var actual = new { Id = sut.Id, Type = sut.Type, Name = sut.Name, Description = sut.Description, Address = sut.Address, Telephone = sut.Telephone, PhotoLink = sut.PhotoLink };

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}