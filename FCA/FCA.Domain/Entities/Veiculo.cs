namespace FCA.Domain.Entities;

public sealed class Veiculo : Entity
{
    public required string Placa { get; init; }

    public required string Modelo { get; init; }

    public required int Ano { get; init; }

    public required Guid ProprietarioId { get; init; }

    public Proprietario Proprietario { get; set; }
}
