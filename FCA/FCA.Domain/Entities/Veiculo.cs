using FCA.Domain.Validations;

namespace FCA.Domain.Entities;

public sealed class Veiculo : Entity
{
    public required string Placa { get; init; }

    public required string Modelo { get; init; }

    public required ushort Ano { get; init; }

    public required Guid ProprietarioId { get; init; }

    public Proprietario? Proprietario { get; set; }

    public Veiculo(string placa, string modelo, ushort ano, Guid proprietarioId)
    {
        ValidateDomain(placa, modelo, ano, proprietarioId);

        Placa = placa;
        Modelo = modelo;
        Ano = ano;
        ProprietarioId = proprietarioId;
    }

    private void ValidateDomain(string placa, string modelo, ushort ano, Guid proprietarioId)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(placa),
                                       Constants.VEICULO_PLACA_OBRIGATORIO);

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(modelo),
                                       Constants.VEICULO_MODELO_OBRIGATORIO);

        DomainExceptionValidation.When(ano == ushort.MinValue || ano == ushort.MaxValue,
                                       Constants.VEICULO_ANO_OBRIGATORIO);

        DomainExceptionValidation.When(proprietarioId == Guid.Empty,
                                       Constants.VEICULO_PROPRIETARIO_OBRIGATORIO);
    }
}
