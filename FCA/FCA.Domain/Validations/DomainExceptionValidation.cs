namespace FCA.Domain.Validations;

internal class DomainExceptionValidation(string errorMessage) : Exception(errorMessage)
{
    public static void When(bool hasError, string errorMessage)
    {
        if (hasError)
            throw new DomainExceptionValidation(errorMessage);
    }
}
