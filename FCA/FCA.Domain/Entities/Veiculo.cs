using FCA.Domain.Validations;
using System.Text.Json.Serialization;

namespace FCA.Domain.Entities;

public sealed class Veiculo : Entity
{
    public required string Placa { get; init; }

    public required string Modelo { get; init; }

    public required int Ano { get; init; }

    #region | Relacionamento |
    public required Guid ProprietarioId { get; init; }

    [JsonIgnore]
    public Proprietario? Proprietario { get; set; }
    #endregion

    public Veiculo(string placa, string modelo, int ano, Guid proprietarioId)
    {
        ValidateDomain(placa, modelo, ano, proprietarioId);
        
        Placa = placa;
        Modelo = modelo;
        Ano = ano;
        ProprietarioId = proprietarioId;
    }

    private void ValidateDomain(string placa, string modelo, int ano, Guid proprietarioId)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(placa),
                                       Constants.VEICULO_PLACA_OBRIGATORIO);

        DomainExceptionValidation.When(placa.Length != 8,
                                       Constants.VEICULO_PLACA_TAMANHO_INVALIDO);
        
        DomainExceptionValidation.When(DomainPlacaValidation.Validar(placa) == false,
                                       Constants.VEICULO_PLACA_INVALIDA);

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(modelo),
                                       Constants.VEICULO_MODELO_OBRIGATORIO);

        DomainExceptionValidation.When(placa.Length > 100,
                                       Constants.VEICULO_MODELO_TAMANHO_INVALIDO);

        DomainExceptionValidation.When(ano == ushort.MinValue || ano == ushort.MaxValue,
                                       Constants.VEICULO_ANO_OBRIGATORIO);

        DomainExceptionValidation.When(ano < 1980,
                                       Constants.VEICULO_ANO_INVALIDO);

        DomainExceptionValidation.When(proprietarioId == Guid.Empty,
                                       Constants.VEICULO_PROPRIETARIO_OBRIGATORIO);
    }
}
