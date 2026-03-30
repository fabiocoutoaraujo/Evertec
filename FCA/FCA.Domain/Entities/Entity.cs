namespace FCA.Domain.Entities;

internal abstract class Entity
{
    public required Guid Id { get; init; } = Guid.NewGuid();
}
