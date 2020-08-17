using System;
using ProAgil.Domain.Interfaces;
using ProAgil.Domain.Shared.Selectors;

namespace ProAgil.Domain.Selectors
{
    public class EventSelector : Selector , ISelector
    {
        public int? EventId { get; set; }
        public DateTime? DateEventIni { get; set; }
        public DateTime? DateEventFin { get; set; }
        public string Theme { get; set; }
        public int? Capacity { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neigborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime? RegisterDateIni { get; set; }
        public DateTime? RegisterDateFin { get; set; }
        public DateTime? LastUpdateDateIni { get; set; }
        public DateTime? LastUpdateDateFin { get; set; }
        public bool? EventActive { get; set; }
        public int? BatchId { get; set; }
        public string BatchDescription { get; set; }                
        public bool? BatchActive { get; set; }
        public bool? BatchCurrentEvent { get; set; }
    }
}