using FCA.Application.DTOs;
using FCA.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FCA.API.Controllers;

[Route("[controller]")]
[ApiController]
public class VeiculosController(ILogger<VeiculosController> _logger,
                                IVeiculoService _veiculoService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VeiculoDTO>>> Get()
    {
        var veiculos = await _veiculoService.GetAllAsync();

        if (veiculos == null || veiculos.Any() == false)
        {
            LogCustomWarning(actionName: "GET/Veiculos",
                                message: Constants.VEICULO_NAO_ENCONTRADO);

            return NotFound(Constants.VEICULO_NAO_ENCONTRADO);
        }

        return Ok(veiculos);
    }

    void LogCustomWarning(string actionName, string message)
    {
        _logger.LogWarning($"{DateTime.Now} | " +
                           $"{Constants.VEICULOS_CONTROLLER} | " +
                           $"{actionName} | " +
                           $"{message}");
    }
}
