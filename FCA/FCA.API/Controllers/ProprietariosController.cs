using FCA.Application.DTOs;
using FCA.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FCA.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProprietariosController(ILogger<ProprietariosController> _logger,
                                         IProprietarioService _proprietariosService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProprietarioDTO>>> Get()
        {
            var proprietariosDTO = await _proprietariosService.GetAllAsync();

            if (proprietariosDTO == null || proprietariosDTO.Any() == false)
            {
                LogCustomWarning(actionName: "GET/Proprietarios",
                                    message: Constants.PROPRIETARIO_NAO_ENCONTRADO);

                return NotFound(Constants.PROPRIETARIO_NAO_ENCONTRADO);
            }

            return Ok(proprietariosDTO);
        }

        [HttpGet]
        [Route("{id:guid}", Name = "GetProprietarioById")]
        public async Task<ActionResult<ProprietarioDTO>> Get(Guid id)
        {
            var proprietarioDTO = await _proprietariosService.GetByIdAsync(id);

            if (proprietarioDTO == null)
            {
                LogCustomWarning(actionName: "GET/Proprietarios/{id}",
                                    message: Constants.PROPRIETARIO_NAO_ENCONTRADO);

                return NotFound(Constants.PROPRIETARIO_NAO_ENCONTRADO);
            }

            return Ok(proprietarioDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProprietarioDTO>> Post(ProprietarioDTO proprietarioDTO)
        {
            if (proprietarioDTO == null)
            {
                LogCustomWarning(actionName: "POST/Proprietarios",
                                    message: $"{Constants.DADOS_INVALIDOS}");

                return BadRequest(Constants.DADOS_INVALIDOS);
            }

            var novoVeicutoDTO = await _proprietariosService.CreateAsync(proprietarioDTO);

            return new CreatedAtRouteResult(routeName: "GetProprietarioById",
                                            routeValues: new { id = novoVeicutoDTO.Id },
                                            value: novoVeicutoDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult<ProprietarioDTO>> Put(Guid id, ProprietarioDTO proprietarioDTO)
        {
            if (id != proprietarioDTO.Id)
            {
                LogCustomWarning(actionName: "PUT/Proprietarios/{id}",
                                    message: $"{Constants.DADOS_INVALIDOS} | {id} | {proprietarioDTO.Id}");

                return BadRequest(Constants.DADOS_INVALIDOS);
            }

            var veicutoAtualizadoDTO = await _proprietariosService.UpdateAsync(proprietarioDTO);

            return Ok(veicutoAtualizadoDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult<ProprietarioDTO>> Delete(Guid id)
        {
            var proprietarioDTO = await _proprietariosService.GetByIdAsync(id);

            if (proprietarioDTO == null)
            {
                LogCustomWarning(actionName: "DELETE/Proprietarios/{id}",
                                    message: $"{Constants.PROPRIETARIO_NAO_ENCONTRADO} | {id}");

                return NotFound(Constants.PROPRIETARIO_NAO_ENCONTRADO);
            }

            var veicutoDeletadoDTO = await _proprietariosService.DeleteAsync(proprietarioDTO);

            return Ok(veicutoDeletadoDTO);
        }

        void LogCustomWarning(string actionName, string message)
        {
            _logger.LogWarning($"{DateTime.Now} | " +
                               $"{Constants.PROPRIETARIOS_CONTROLLER} | " +
                               $"{actionName} | " +
                               $"{message}");
        }
    }
}
