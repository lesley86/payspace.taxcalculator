using System;

namespace Tax.Core.Entities
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
    }
}