using Flunt.Validations;
using ProAgil.Domain.Shared.ValueObjects;

namespace ProAgil.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        private Address() { }
        public Address(string street, string number, string neigborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neigborhood = neigborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()

                .HasMinLen(Street, 3, "Address.Street", "A Rua deve ter pelo menos 3 caracteres.")
                .HasMaxLen(Street, 150, "Address.Street", "A Rua deve ter no maximo 150 caracteres.")
                .IsNotNullOrEmpty(Street, "Address.Street", "A rua não pode estar em branco")

                .IsNotNullOrEmpty(Number, "Address.Number", "O npumero não pode estar em branco")

                .HasMinLen(Neigborhood, 3, "Address.Neigborhood", "O bairro deve ter pelo menos 3 caracteres.")
                .HasMaxLen(Neigborhood, 150, "Address.Neigborhood", "O bairro deve ter no maximo 150 caracteres.")
                .IsNotNullOrEmpty(Neigborhood, "Address.Neigborhood", "O bairro não pode estar em branco")

                .HasMinLen(City, 3, "Address.City", "A cidade deve ter pelo menos 3 caracteres.")
                .HasMaxLen(City, 150, "Address.City", "A cidade deve ter no maximo 150 caracteres.")
                .IsNotNullOrEmpty(City, "Address.City", "A cidade não pode estar em branco")

                .HasMinLen(State, 2, "Address.State", "O estado deve ter pelo menos 2 caracteres.")
                .HasMaxLen(State, 150, "Address.State", "O estado deve ter no maximo 150 caracteres.")
                .IsNotNullOrEmpty(State, "Address.State", "O estado não pode estar em branco")

                .HasMinLen(Country, 2, "Address.State", "O pais deve ter pelo menos 2 caracteres.")
                .HasMaxLen(Country, 150, "Address.State", "O pais deve ter no maximo 150 caracteres.")
                .IsNotNullOrEmpty(Country, "Address.State", "O pais não pode estar em branco")


            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neigborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}