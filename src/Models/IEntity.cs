using System;

namespace WebApi.Models
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}