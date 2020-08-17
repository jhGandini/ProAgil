using System;
using FluentValidation;
using FluentValidation.Results;
using Flunt.Notifications;

namespace Proagil.Domain.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity() { }

        public int? Id { get; set; }
    }
}