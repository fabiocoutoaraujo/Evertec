using FCA.Domain;
using System.ComponentModel.DataAnnotations;

namespace FCA.Application.DTOs;

public class VeiculoFiltroModeloDTORequest
{
    [Required(ErrorMessage = Constants.VEICULO_MODELO_OBRIGATORIO)]
    [MaxLength(100)]
    public required string Modelo { get; set; }
}
