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
        var veiculosDTO = await _veiculoService.GetAllAsync();

        if (veiculosDTO == null || veiculosDTO.Any() == false)
        {
            LogCustomWarning(actionName: "GET/Veiculos",
                                message: Constants.VEICULO_NAO_ENCONTRADO);

            return NotFound(Constants.VEICULO_NAO_ENCONTRADO);
        }

        return Ok(veiculosDTO);
    }

    [HttpGet]
    [Route("{id:guid}", Name = "GetById")]
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

        return new CreatedAtRouteResult(routeName: "GetById",
                                        routeValues: new { id = novoVeicutoDTO.Id },
                                        value: novoVeicutoDTO);
    }

    [HttpPut]
    [Route("{id:guid}")]
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
