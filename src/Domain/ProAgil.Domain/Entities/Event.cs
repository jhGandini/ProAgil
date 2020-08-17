using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using Proagil.Domain.Shared.Entities;
using ProAgil.Domain.ValueObjects;

namespace ProAgil.Domain.Entities
{
    public class Event : Entity
    {

        //Constructor generated for EFcore
        protected Event() : base()
        {
            _Lotes = new List<Lot>();
        }

        public Event(int? id, Address address, DateTime? dateEvent, string theme, int capacity, MaintenanceDate maintenanceDate, Activater activater)
        {
            Id = id;
            Address = address;
            DateEvent = dateEvent;
            Theme = theme;
            Capacity = capacity;
            _Lotes = new List<Lot>();
            MaintenanceDate = maintenanceDate == null ? new MaintenanceDate(null, null) : maintenanceDate;
            Activater = activater == null ? new Activater(null) : activater;

            AddNotifications(
                new Contract()
                    .Requires()
                    .IsLowerOrEqualsThan(1, Capacity, "Capacity", "A capacidade deve ser informada.")
            );

            AddNotifications(Address);

        }

        private List<Lot> _Lotes;

        public Address Address { get; private set; }
        public DateTime? DateEvent { get; private set; }
        public string Theme { get; private set; }
        public int Capacity { get; private set; }
        public MaintenanceDate MaintenanceDate { get; private set; }
        public Activater Activater { get; private set; }
        public IReadOnlyList<Lot> Lots { get { return _Lotes.ToArray(); } }

        public void ChangeCurrentLot(Lot Lot)
        {
            try
            {
                var LotExists = _Lotes.Exists(b => b.Description.Equals(Lot.Description) || b.Description.Equals(Lot.Description));
                if (LotExists)
                {
                    _Lotes.Where(b => b.Id.Equals(Lot.Id) || b.Description.Equals(Lot.Description)).FirstOrDefault().Current();
                    _Lotes.Where(b => !b.Id.Equals(Lot.Id) && !b.Description.Equals(Lot.Description)).FirstOrDefault().Current(false);
                }
                else
                    AddNotification("CurrentLot", "O lote indormado não pertence a esse evento.");
            }
            catch (System.Exception ex)
            {
                AddNotification("CurrentLot", ex.Message);
            }
        }

        public void AddLot(Lot Lot)
        {
            if (Lot.Valid)
            {
                if (!_Lotes.Exists(b => b.Description.Equals(Lot.Description)))
                {
                    _Lotes.Add(Lot);
                    return;
                }
            }
            AddNotifications(Lot);
            AddNotification("Lotes", $"Lot { Lot.Description } não pode ser adiciona.");
        }

        public void AddLots(List<Lot> Lotes)
        {
            foreach (var Lot in Lotes)
            {
                if (Lot.Valid)
                {
                    if (!_Lotes.Exists(b => b.Description.Equals(Lot.Description)))
                    {
                        _Lotes.Add(Lot);
                    }
                    return;
                }
                AddNotifications(Lot);
                AddNotification("Lotes", $"Lot { Lot.Description } não pode ser adiciona.");
            }
        }
    }
}