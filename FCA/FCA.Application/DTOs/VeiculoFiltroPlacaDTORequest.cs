using FCA.Domain;
using System.ComponentModel.DataAnnotations;

namespace FCA.Application.DTOs;

public class VeiculoFiltroPlacaDTORequest
{
    [Required(ErrorMessage = Constants.VEICULO_PLACA_OBRIGATORIO)]
    [Length(8, 8, ErrorMessage = Constants.VEICULO_PLACA_INVALIDA)]
    [RegularExpression(Constants.VEICULO_PLACA_EXPRESSAO_REGULAR)]
    public required string Placa { get; set; }
}
