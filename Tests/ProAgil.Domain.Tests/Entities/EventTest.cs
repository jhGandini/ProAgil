using System;
using System.Collections.Generic;
using System.Linq;
using ProAgil.Domain.Entities;
using ProAgil.Domain.ValueObjects;
using Xunit;

namespace Proagil.Domain.Tests.Entities
{
    public class EventTest
    {

        private Event Event;
        private Address Adrress;
        private IList<Lot> Lots;
        private Lot LotOuterEvent;
        public EventTest()
        {
            Adrress = new Address("Orlando Silva", "423", "Santo Inacio", "Esteio", "RS", "Brasil", "93290320");

            Event = new Event(null, Adrress, DateTime.Now, "Festa dos Testes", 200, null, null);

            Lots = new List<Lot>();
            Lots.Add(new Lot(1, "Primeiro Lote", true, Event, new Activater()));
            Lots.Add(new Lot(2, "Segundo Lote", false, Event, new Activater()));
            Lots.Add(new Lot(3, "Terceiro Lote", false, Event, new Activater()));
            Lots.Add(new Lot(4, "Quarto Lote", false, Event, new Activater()));

            foreach (var Lot in Lots)
            {
                Event.AddLot(Lot);
            }

            LotOuterEvent = new Lot(5, "Lote de evento qualyqre", false, null, new Activater());
        }

        [Fact]
        public void DeveRetornarErrorQuandoChangeCurrentLotNaoExistirNoEvento()
        {
            Event.ChangeCurrentLot(LotOuterEvent);
            Assert.False(Event.Valid);
        }

        [Fact]
        public void DeveAtivarCurrentBachDesativarOutrasQuandoChangeCurrentLotForExecutado()
        {
            Event.ChangeCurrentLot(Lots[2]);
            var currentTrue = Event.Lots.ToList().Exists(b => b.Id.Value.Equals(3) && b.CurrentEvent.Value);
            var totalFalse = Event.Lots.AsQueryable().Where(b => !b.Id.Value.Equals(3) && !b.CurrentEvent.Value).Count() == 3 ? true : false;
            Assert.True(currentTrue && totalFalse);
        }

        [Fact]
        public void DeveRetornarInvalidQuandoAdicionarLotInvalida()
        {
            Event.AddLot(new Lot(5, "inv", false, Event, new Activater()));
            Assert.True(Event.Invalid);
        }

        [Fact]
        public void DeveRetornarInvalidQuandoAdicionarLotMesmaDescricao()
        {
            Event.AddLot(new Lot(5, "Primeiro Lote", false, Event, new Activater()));
            Assert.True(Event.Invalid);
        }
    }
}