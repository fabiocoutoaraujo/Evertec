using System.Text.RegularExpressions;

namespace FCA.Domain.Validations;

internal class DomainCPFValidation
{
    /// <summary>
    /// Método extraido do Claude Code - NÃO VALIDADO
    /// </summary>
    /// <param name="cpf">CPF do proprietário</param>
    /// <returns>verdadeiro caso informado corretamente, caso contrário retorna falso.</returns>
    public static bool Validar(string cpf)
    {
        // Remover caracteres não numéricos
        cpf = Regex.Replace(cpf, @"[^\d]", "");

        // Verificar se o CPF tem 11 dígitos
        if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
            return false;

        // Cálculo do primeiro dígito verificador
        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (int)(cpf[i] - '0') * (10 - i);

        int primeiroDigito = (soma * 10) % 11;
        if (primeiroDigito == 10) primeiroDigito = 0;

        // Cálculo do segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (int)(cpf[i] - '0') * (11 - i);

        int segundoDigito = (soma * 10) % 11;
        if (segundoDigito == 10) segundoDigito = 0;

        // Comparar os dígitos verificadores
        return cpf[9] == (char)(primeiroDigito + '0') && cpf[10] == (char)(segundoDigito + '0');
    }
}
