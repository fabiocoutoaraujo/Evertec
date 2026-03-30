using System.Text.RegularExpressions;

namespace FCA.Domain.Validations;

internal class DomainPlacaValidation
{
    /// <summary>
    /// Valida uma placa no formato ABC-1234
    /// </summary>
    /// <param name="placa">A informação da placa do veículo</param>
    /// <returns>Verdadeiro caso a placa informada esteja no formato correto, caso contrário retorna falso.</returns>
    public static bool Validar(string placa)
    {
        // Expressão regular para o formato ""
        string padrao = @"^[A-Z]{3}-\d{4}$";
        return Regex.IsMatch(placa, padrao);
    }
}
