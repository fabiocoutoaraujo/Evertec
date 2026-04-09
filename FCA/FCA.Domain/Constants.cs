
namespace FCA.Domain;

public static class Constants
{
    public const string PROPRIETARIO_NAO_ENCONTRADO = "O proprietário informado não foi encontrado!";

    public const string PROPRIETARIO_NOME_OBRIGATORIO = "O nome do proprietário é obrigatório!";
    
    public const string PROPRIETARIO_CPF_OBRIGATORIO = "O CPF do proprietário é obrigatório!";

    public const string PROPRIETARIO_CPF_TAMANHO_INVALIDO = "O CPF do proprietário deve conter entre 11 e 14 caracteres!";

    public const string PROPRIETARIO_NASCIMENTO_OBRIGATORIO = "A data de nascimento do proprietário é obrigatória!";

    public const string PROPRIETARIO_NOME_TAMANHO_INVALIDO = "O nome do proprietário deve conter entre 3 e 100 caracteres!";

    public const string PROPRIETARIO_CPF_INVALIDO = "O CPF do proprietário é inválido!";

    public const string PROPRIETARIO_POSSUI_VEICULO = "O proprietário poussi um ou mais veículos!";

    public const string VEICULO_PLACA_OBRIGATORIO = "A placa do veículo é obrigatória!";

    public const string VEICULO_MODELO_OBRIGATORIO = "O modelo do veículo é obrigatório!";

    public const string VEICULO_MODELO_TAMANHO_INVALIDO = "O modelo do veículo deve conter entre 1 e 100 caracteres!";

    public const string VEICULO_ANO_OBRIGATORIO = "O ano do veículo é obrigatório!";
    
    public const string VEICULO_PROPRIETARIO_OBRIGATORIO = "O identificador do proprietário do veículo é obrigatório!";

    public const string VEICULO_ANO_INVALIDO = "O ano do veículo deve ser maior que 1980!";

    public const string VEICULO_PLACA_TAMANHO_INVALIDO = "A placa do veículo deve conter entre 8 caracteres! Formato válido: ABC-1234";

    public const string VEICULO_PLACA_INVALIDA = "O formato da placa do veículo é inválida! Formato válido: ABC-1234";

    public const string VEICULO_PLACA_EXPRESSAO_REGULAR = @"^[A-Z]{3}-\d{4}$";
}
