using FCA.Domain;
using System.ComponentModel.DataAnnotations;

namespace FCA.Application.DTOs;

public class VeiculoDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = Constants.VEICULO_PLACA_OBRIGATORIO)]
    [Length(8, 8, ErrorMessage = Constants.VEICULO_PLACA_INVALIDA)]
    [RegularExpression(Constants.VEICULO_PLACA_EXPRESSAO_REGULAR)]
    public required string Placa { get; set; }
    
    [Required(ErrorMessage = Constants.VEICULO_MODELO_OBRIGATORIO)]
    [MaxLength(100)]
    public required string Modelo { get; set; }
    
    [Required(ErrorMessage = Constants.VEICULO_ANO_OBRIGATORIO)]
    [Range(1980, 2999, ErrorMessage = Constants.VEICULO_ANO_INVALIDO)]
    public int Ano { get; set; }
    
    [Required(ErrorMessage = Constants.VEICULO_PROPRIETARIO_OBRIGATORIO)]
    public Guid ProprietarioId { get; set; }
}
