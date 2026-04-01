using FCA.Domain;
using System.ComponentModel.DataAnnotations;

namespace FCA.Application.DTOs;

public class ProprietarioFiltroNomeDTORequest
{
    [Required(ErrorMessage = Constants.PROPRIETARIO_NOME_OBRIGATORIO)]
    [Length(3, 100)]
    public required string Nome { get; set; }
}
