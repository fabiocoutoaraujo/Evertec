using FCA.Domain;
using System.ComponentModel.DataAnnotations;

namespace FCA.Application.DTOs;

public class ProprietarioDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = Constants.PROPRIETARIO_NOME_OBRIGATORIO)]
    [Length(3, 100)]
    public required string Nome { get; set; }

    [Required(ErrorMessage = Constants.PROPRIETARIO_CPF_OBRIGATORIO)]
    [Length(11, 14, ErrorMessage = Constants.PROPRIETARIO_CPF_TAMANHO_INVALIDO)]
    public required string CPF { get; set; }

    [Required(ErrorMessage = Constants.PROPRIETARIO_NASCIMENTO_OBRIGATORIO)]
    [DataType(DataType.Date)]
    public DateOnly DataNascimento { get; set; }
}
