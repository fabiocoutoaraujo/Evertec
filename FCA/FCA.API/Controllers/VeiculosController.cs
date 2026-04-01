using FCA.Application.DTOs;
using FCA.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FCA.API.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
[ApiConventionType(typeof(DefaultApiConventions))]
public class VeiculosController(ILogger<VeiculosController> _logger,
                                IVeiculoService _veiculoService) : ControllerBase
{
    /// <summary>
    /// Obtém uma lista de veículos.
    /// </summary>
    /// <returns>Uma lista de objetos VeiculoDTO.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<IEnumerable<VeiculoDTO>>> Get()
    {
        var veiculosDTO = await _veiculoService.GetAllAsync();

        if (veiculosDTO == null || veiculosDTO.Any() == false)
        {
            LogCustomWarning(actionName: "GET/Veiculos",
                                message: Constants.VEICULO_NAO_ENCONTRADO);

            return NotFound(Constants.VEICULO_NAO_ENCONTRADO);
        }

        return Ok(veiculosDTO);
    }

    /// <summary>
    /// Obtém um veículo pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador único do veículo (guid).</param>
    /// <returns>Um objeto VeiculoDTO.</returns>
    [HttpGet]
    [Route("{id:guid}", Name = "GetVeiculoById")]
    public async Task<ActionResult<VeiculoDTO>> Get(Guid id)
    {
        var veiculoDTO = await _veiculoService.GetByIdAsync(id);

        if (veiculoDTO == null)
        {
            LogCustomWarning(actionName: "GET/Veiculos/{id}",
                                message: Constants.VEICULO_NAO_ENCONTRADO);

            return NotFound(Constants.VEICULO_NAO_ENCONTRADO);
        }

        return Ok(veiculoDTO);
    }

    /// <summary>
    /// Adiciona um novo veículo.
    /// </summary>
    /// <remarks>
    /// {
    ///     "placa": "FGQ-4249",
    ///     "modelo": "Fox 1.6",
    ///     "ano": 2014,
    ///     "proprietarioId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    /// }
    /// </remarks>
    /// <param name="veiculoDTO">Objeto VeiculoDTO com os argumentos do novo veículo.</param>
    /// <returns>Um novo objeto VeiculoDTO adicionado.</returns>
    [HttpPost]
    public async Task<ActionResult<VeiculoDTO>> Post(VeiculoDTO veiculoDTO)
    {
        if (veiculoDTO == null)
        {
            LogCustomWarning(actionName: "POST/Veiculos",
                                message: $"{Constants.DADOS_INVALIDOS}");

            return BadRequest(Constants.DADOS_INVALIDOS);
        }

        var novoVeicutoDTO = await _veiculoService.CreateAsync(veiculoDTO);

        return new CreatedAtRouteResult(routeName: "GetVeiculoById",
                                        routeValues: new { id = novoVeicutoDTO.Id },
                                        value: novoVeicutoDTO);
    }

    [HttpPut]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<VeiculoDTO>> Put(Guid id, VeiculoDTO veiculoDTO)
    {
        if (id != veiculoDTO.Id)
        {
            LogCustomWarning(actionName: "PUT/Veiculos/{id}",
                                message: $"{Constants.DADOS_INVALIDOS} | {id} | {veiculoDTO.Id}");

            return BadRequest(Constants.DADOS_INVALIDOS);
        }

        var veicutoAtualizadoDTO = await _veiculoService.UpdateAsync(veiculoDTO);

        return Ok(veicutoAtualizadoDTO);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ActionResult<VeiculoDTO>> Delete(Guid id)
    {
        var veiculoDTO = await _veiculoService.GetByIdAsync(id);

        if (veiculoDTO == null)
        {
            LogCustomWarning(actionName: "DELETE/Veiculos/{id}",
                                message: $"{Constants.VEICULO_NAO_ENCONTRADO} | {id}");

            return NotFound(Constants.VEICULO_NAO_ENCONTRADO);
        }

        var veicutoDeletadoDTO = await _veiculoService.DeleteAsync(veiculoDTO);

        return Ok(veicutoDeletadoDTO);
    }

    void LogCustomWarning(string actionName, string message)
    {
        _logger.LogWarning($"{DateTime.Now} | " +
                           $"{Constants.VEICULOS_CONTROLLER} | " +
                           $"{actionName} | " +
                           $"{message}");
    }
}
