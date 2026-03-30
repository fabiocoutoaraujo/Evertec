using FCA.Domain.Validations;

namespace FCA.Domain.Entities;

public sealed class Proprietario : Entity
{
    public required string Nome { get; init; }

    public required string CPF { get; init; }

    public required DateOnly DataNascimento { get; init; }

    public Proprietario(string nome, string cpf, DateOnly dataNascimento)
    {
        ValidateDomain(nome, cpf, dataNascimento);

        Nome = nome;
        CPF = cpf;
        DataNascimento = dataNascimento;
    }

    private void ValidateDomain(string nome, string cpf, DateOnly dataNascimento)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome),
                                       Constants.PROPRIETARIO_NOME_OBRIGATORIO);

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(cpf),
                                       Constants.PROPRIETARIO_CPF_OBRIGATORIO);

        DomainExceptionValidation.When(dataNascimento == DateOnly.MinValue || dataNascimento == DateOnly.MaxValue,
                                       Constants.PROPRIETARIO_NASCIMENTO_OBRIGATORIO);
    }
}
