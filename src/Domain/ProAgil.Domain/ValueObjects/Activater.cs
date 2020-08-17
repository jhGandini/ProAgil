using ProAgil.Domain.Shared.ValueObjects;

namespace ProAgil.Domain.ValueObjects
{
    public class Activater : ValueObject
    {
        protected Activater() { }
        public Activater(bool? active = null)
        {
            Active = active == null ? true : active;
        }

        public bool? Active { get; protected set; }

        public void Activate()
        {
            Active = true;
        }

        public void Inactivate()
        {
            Active = false;
        }
    }
}