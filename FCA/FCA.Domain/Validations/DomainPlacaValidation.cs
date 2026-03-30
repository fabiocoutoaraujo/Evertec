using System.Text.RegularExpressions;

namespace FCA.Domain.Validations;

internal class DomainPlacaValidation
{
    /// <summary>
    /// Valida uma placa no formato ABC-1234
    /// </summary>
    /// <param name="placa">A placa do veículo</param>
    /// <returns>Verdadeiro caso a placa informada esteja no formato correto, caso contrário retorna falso.</returns>
    public static bool Validar(string placa)
    {
        return Regex.IsMatch(placa, Constants.VEICULO_PLACA_EXPRESSAO_REGULAR);
    }
}
