using System;
using System.Collections.Generic;
using ProAgil.Domain.Shared.Dtos;

namespace ProAgil.Domain.Dtos
{
    public class EventDto : Dto
    {
        public int? Id { get; set; }
        public DateTime? DateEvent { get; set; }
        public string Theme { get; set; }
        public int Capacity { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neigborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public bool? Active { get; set; }
        public List<LotDto> Lots { get; set; }
    }
}