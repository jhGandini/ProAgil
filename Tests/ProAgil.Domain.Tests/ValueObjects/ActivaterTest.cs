using ProAgil.Domain.ValueObjects;
using Xunit;

namespace ProAgil.Domain.Tests.ValueObjects
{
    public class ActivaterTest
    {

        [Fact]
        public void DeveRetornarObjectQuandoCriarNovoActivater()
        {
            var activater = new Activater();
            Assert.IsType<Activater>(activater);
        }

        [Fact]
        public void DeveRetornarTrueQuandoCriarNovoActivaterSemParametros()
        {
            var activater = new Activater();
            Assert.True(activater.Active);
        }

        [Fact]
        public void DeveRetornarTrueQuandoCriarNovoActivaterComParametroTrue()
        {
            var activater = new Activater(true);
            Assert.True(activater.Active);
        }

        [Fact]
        public void DeveRetornarFalseQuandoCriarNovoActivaterComParametroFalse()
        {
            var activater = new Activater(false);
            Assert.False(activater.Active);
        }

        [Fact]
        public void DeveRetornarTrueQuandoActivaterActivate()
        {
            var activater = new Activater(false);
            activater.Activate();
            Assert.True(activater.Active);
        }


        //public void ShouldReturnFalseWhenInactivate()
        [Fact]
        public void DeveReotnarFalseQuandoActivaterInactivate()
        {
            var activater = new Activater(true);
            activater.Inactivate();
            Assert.False(activater.Active);
        }

    }
}