using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FCA.API.Filters;

public class ApiExceptionFilter(ILogger<ApiExceptionFilter> _logger) : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, Constants.MENSAGEM_EXCECAO_NAO_TRATADA);

        context.Result = new ObjectResult(Constants.MENSAGEM_PROBLEMA_TRATAR_SUA_SOLICITACAO)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
