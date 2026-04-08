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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get()
    {
        var veiculosDTO = await _veiculoService.GetAllAsync();

        if (veiculosDTO == null || veiculosDTO.Any() == false)
        {
            LogCustomWarning(actionName: "GET/Veiculos",
                                message: Constants.VEICULO_NAO_ENCONTRADO);
            return NotFound();
        }
        return Ok(veiculosDTO);
    }

    /// <summary>
    /// Obtém um veículo pelo seu identificador.
    /// </summary>
    /// <param name="id">Identificador único do veículo (guid).</param>
    /// <returns>Um objeto VeiculoDTO.</returns>
    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get(Guid id)
    {
        var veiculoDTO = await _veiculoService.GetByIdAsync(id);

        if (veiculoDTO == null)
        {
            LogCustomWarning(actionName: "GET/Veiculos/{id}",
                                message: Constants.VEICULO_NAO_ENCONTRADO);
            return NotFound();
        }
        return Ok(veiculoDTO);
    }

    /// <summary>
    /// Obtém um veículo pela placa.
    /// </summary>
    /// <param name="veiculoFiltroPlacaDTORequest">Objeto VeiculoFiltroPlacaDTORequest com a informação da placa do veículo.</param>
    /// <returns>Um objeto VeiculoDTO.</returns>
    [HttpGet]
    [Route("Placa")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get([FromQuery] VeiculoFiltroPlacaDTORequest veiculoFiltroPlacaDTORequest)
    {
        var veiculoDTO = await _veiculoService.GetByPlacaAsync(veiculoFiltroPlacaDTORequest);

        if (veiculoDTO == null)
        {
            LogCustomWarning(actionName: "GET/Veiculos/Placa",                                
                                message: $"{Constants.VEICULO_NAO_ENCONTRADO} | {veiculoFiltroPlacaDTORequest.Placa}");
            return NotFound();
        }
        return Ok(veiculoDTO);
    }

    /// <summary>
    /// Obtém um veículo pelo modelo.
    /// </summary>
    /// <param name="veiculoFiltroModeloDTORequest">Objeto VeiculoFiltroModeloDTORequest com a informação do modelo do veículo.</param>
    /// <returns>Um objeto VeiculoDTO.</returns>
    [HttpGet]
    [Route("Modelo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get([FromQuery] VeiculoFiltroModeloDTORequest veiculoFiltroModeloDTORequest)
    {
        var veiculoDTO = await _veiculoService.GetByModeloAsync(veiculoFiltroModeloDTORequest);

        if (veiculoDTO == null)
        {
            LogCustomWarning(actionName: "GET/Veiculos/Modelo",
                                message: $"{Constants.VEICULO_NAO_ENCONTRADO} | {veiculoFiltroModeloDTORequest.Modelo}");
            return NotFound();
        }
        return Ok(veiculoDTO);
    }

    /// <summary>
    /// Obtém uma lista de veículos pelo nome do proprietário.
    /// </summary>
    /// <param name="proprietarioFiltroNomeDTORequest">Objeto ProprietarioFiltroNomeDTORequest com o nome do proprietário.</param>
    /// <returns>Uma lista de objetos VeiculoDTO.</returns>
    [HttpGet]
    [Route("NomeProprietario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Get([FromQuery] ProprietarioFiltroNomeDTORequest proprietarioFiltroNomeDTORequest)
    {
        var veiculosDTO = await _veiculoService.GetByNomeProprietarioAsync(proprietarioFiltroNomeDTORequest);

        if (veiculosDTO == null || veiculosDTO.Any() == false)
        {
            LogCustomWarning(actionName: "GET/Veiculos/NomeProprietario",
                                message: $"{Constants.VEICULO_NAO_ENCONTRADO} | {proprietarioFiltroNomeDTORequest.Nome}");
            return NotFound();
        }
        return Ok(veiculosDTO);
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post([FromBody] VeiculoDTO veiculoDTO)
    {
        if (veiculoDTO == null)
        {
            LogCustomWarning(actionName: "POST/Veiculos",
                                message: $"{Constants.DADOS_INVALIDOS}");
            return BadRequest();
        }

        var novoVeicutoDTO = await _veiculoService.CreateAsync(veiculoDTO);

        return CreatedAtAction(nameof(Get),
                               new { id = novoVeicutoDTO.Id },
                               novoVeicutoDTO);
    }

    [HttpPut]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]    
    public async Task<IActionResult> Put(Guid id, VeiculoDTO veiculoDTO)
    {
        if (id != veiculoDTO.Id)
        {
            LogCustomWarning(actionName: "PUT/Veiculos/{id}",
                                message: $"{Constants.DADOS_INVALIDOS} | {id} | {veiculoDTO.Id}");
            return BadRequest();
        }

        var existeVeiculoDTO = _veiculoService.GetByIdAsync(id);
        if (existeVeiculoDTO == null)
        {
            LogCustomWarning(actionName: "PUT/Veiculos/{id}",
                                message: $"{Constants.VEICULO_NAO_ENCONTRADO} | {id}");
            return NotFound();
        }

        await _veiculoService.UpdateAsync(veiculoDTO);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(Guid id)
    {
        var veiculoDTO = await _veiculoService.GetByIdAsync(id);

        if (veiculoDTO == null)
        {
            LogCustomWarning(actionName: "DELETE/Veiculos/{id}",
                                message: $"{Constants.VEICULO_NAO_ENCONTRADO} | {id}");
            return NotFound();
        }

        await _veiculoService.DeleteAsync(veiculoDTO);

        return NoContent();
    }

    void LogCustomWarning(string actionName, string message)
    {
        _logger.LogWarning($"{DateTime.Now} | " +
                           $"{Constants.VEICULOS_CONTROLLER} | " +
                           $"{actionName} | " +
                           $"{message}");
    }
}
