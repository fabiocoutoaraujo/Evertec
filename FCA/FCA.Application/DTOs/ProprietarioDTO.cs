using FCA.Domain;
using System.ComponentModel.DataAnnotations;

namespace FCA.Application.DTOs;

public class ProprietarioDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = Constants.PROPRIETARIO_NOME_OBRIGATORIO)]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required(ErrorMessage = Constants.PROPRIETARIO_CPF_OBRIGATORIO)]
    [MinLength(11)]
    [MaxLength(14)]
    public string CPF { get; set; }

    [Required(ErrorMessage = Constants.PROPRIETARIO_NASCIMENTO_OBRIGATORIO)]
    [DataType(DataType.Date)]
    public DateOnly DataNascimento { get; set; }
}
