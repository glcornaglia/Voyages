using Xunit;

namespace Voyages.Domain.Tests.Unit
{
    public class ClientTests
    {
        

        [Fact]
        public void ClientContainsWellBehavedWritableProperties()
        {
            // Arrange
            var expected = new { Id = 1, Name = "Name", LastName = "LastName", Address = "Address", Telephone = "Telephone", Email = "Email", BirthDate = "BirthDate", IdFile = 1};

            var sut = new Client();

            // Act
            sut.Id = expected.Id;
            sut.Name = expected.Name;
            sut.LastName = expected.LastName;
            sut.Address = expected.Address;
            sut.Telephone = expected.Telephone;
            sut.Email = expected.Email;
            sut.BirthDate = expected.BirthDate;
            sut.IdFile = expected.IdFile;

            var actual = new { Id = sut.Id, Name = sut.Name, LastName = sut.LastName, Address = sut.Address, Telephone = sut.Telephone, Email = sut.Email, BirthDate = sut.BirthDate, IdFile = sut.IdFile };

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}