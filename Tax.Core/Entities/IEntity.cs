using System;

namespace Tax.Core.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
