using ProAgil.Domain.Shared.Dtos;

namespace ProAgil.Domain.Dtos
{
    public class LotDto : Dto
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public int? EventId { get; set; }
        public EventDto Event { get; set; }
        public bool? Active { get; set; }
        public bool? CurrentEvent { get; set; }
    }
}