using FCA.Domain;
using System.ComponentModel.DataAnnotations;

namespace FCA.Application.DTOs;

public class VeiculoDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = Constants.VEICULO_PLACA_OBRIGATORIO)]
    [RegularExpression(@"^[A-Z]{3}-\d{4}$")]
    public string Placa { get; set; }
    
    [Required(ErrorMessage = Constants.VEICULO_MODELO_OBRIGATORIO)]
    public string Modelo { get; set; }
    
    [Required(ErrorMessage = Constants.VEICULO_ANO_OBRIGATORIO)]
    [MinLength(1980)]
    public ushort Ano { get; set; }
    
    [Required(ErrorMessage = Constants.VEICULO_PROPRIETARIO_OBRIGATORIO)]
    public Guid ProprietarioId { get; set; }
}
