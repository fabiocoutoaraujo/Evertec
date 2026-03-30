namespace FCA.Domain.Entities;

public sealed class Proprietario : Entity
{
    public required string Nome { get; init; }

    public required string CPF { get; init; }

    public required DateOnly DataNascimento { get; init; }
}
