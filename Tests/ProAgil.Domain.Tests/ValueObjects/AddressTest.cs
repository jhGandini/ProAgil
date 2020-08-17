using ProAgil.Domain.ValueObjects;
using Xunit;
namespace ProAgil.Domain.Tests.ValueObjects
{
    public class AddressTest
    {
        [Fact]
        public void DeveRetornarInvalidQuandoCriarNovoAddressParametrosNull()
        {
            var address = new Address(null, null, null, null, null, null, null);
            Assert.True(address.Invalid);
        }

        [Fact]
        public void DeveRetornarValidQuandoCriarNovoAddressZipCodeNull()
        {
            var address = new Address("Teste", "null", "Teste", "Teste", "Teste", "Teste", null);
            Assert.True(address.Valid);
        }
    }
}