using System;
using ProAgil.Domain.Shared.ValueObjects;

namespace ProAgil.Domain.ValueObjects
{
    public class MaintenanceDate : ValueObject
    {
        protected MaintenanceDate() { }
        public MaintenanceDate(DateTime? registerDate, DateTime? lastUpdateDate)
        {
            RegisterDate = registerDate == null ? DateTime.Now : registerDate;
            LastUpdateDate = lastUpdateDate == null ? DateTime.Now : lastUpdateDate;
        }

        public DateTime? RegisterDate { get; protected set; }
        public DateTime? LastUpdateDate { get; protected set; }
    }
}