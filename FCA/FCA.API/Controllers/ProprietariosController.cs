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
        /// <summary>
        /// Obtém uma lista de proprietários.
        /// </summary>
        /// <returns>Uma lista de objetos ProprietarioDTO.</returns>
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

        /// <summary>
        /// Obtém um proprietário pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador único do proprietário (guid).</param>
        /// <returns>Um objeto ProprietarioDTO.</returns>
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

        /// <summary>
        /// Adiciona um novo prorietário.
        /// </summary>
        /// <remarks>
        /// {
        ///   "nome": "Fábio Couto Araújo",
        ///   "cpf": "258.819.050-24",
        ///   "dataNascimento": "1992-05-07"
        /// }        
        /// </remarks>
        /// <param name="proprietarioDTO">Objeto ProprietarioDTO com os argumentos do novo proprietário.</param>
        /// <returns>Um novo objeto ProprietarioDTO adicionado.</returns>
        [HttpPost]
        public async Task<ActionResult<ProprietarioDTO>> Post(ProprietarioDTO proprietarioDTO)
        {
            if (proprietarioDTO == null)
            {
                LogCustomWarning(actionName: "POST/Proprietarios",
                                    message: $"{Constants.DADOS_INVALIDOS}");

                return BadRequest(Constants.DADOS_INVALIDOS);
            }

            var novoProprietarioDTO = await _proprietariosService.CreateAsync(proprietarioDTO);

            return new CreatedAtRouteResult(routeName: "GetProprietarioById",
                                            routeValues: new { id = novoProprietarioDTO.Id },
                                            value: novoProprietarioDTO);
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

            var proprietarioAtualizadoDTO = await _proprietariosService.UpdateAsync(proprietarioDTO);

            return Ok(proprietarioAtualizadoDTO);
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

            var proprietarioDeletadoDTO = await _proprietariosService.DeleteAsync(proprietarioDTO);

            return Ok(proprietarioDeletadoDTO);
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
