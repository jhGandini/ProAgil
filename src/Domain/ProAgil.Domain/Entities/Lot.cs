using System;
using Flunt.Validations;
using Proagil.Domain.Shared.Entities;
using ProAgil.Domain.ValueObjects;

namespace ProAgil.Domain.Entities
{
    public class Lot : Entity
    {
        private Lot() { }

        public Lot(int? id, string description, bool? currentEvent, Event _event, Activater activater)//)
        {
            Id = id;
            Description = description;
            CurrentEvent = currentEvent != null ? currentEvent : false;
            Event = _event;
            Activater = activater != null ? activater : new Activater(true);

            AddNotifications(new Contract()
                .Requires()

                .HasMinLen(Description, 5, "Lot.Description", $"A descrição do lote {Id}.{Description} deve ter pelo menos 3 caracteres.")
                .HasMaxLen(Description, 150, "Lot.Description", $"A descrição do lote {Id}.{Description} deve ter no maximo 150 caracteres.")
            //.IsNotNull(Event, "Lot.Event", "Deve ser informado o evento para o lote")
            );
        }

        public string Description { get; private set; }
        public int EventId { get; private set; }
        public Event Event { get; private set; }
        public bool? CurrentEvent { get; private set; }
        public Activater Activater { get; private set; }

        public void Current(bool val = true)
        {
            CurrentEvent = val;
        }
    }
}