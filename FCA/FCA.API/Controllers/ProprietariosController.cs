using FCA.Application.DTOs;
using FCA.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FCA.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProprietariosController(ILogger<ProprietariosController> _logger,
                                         IProprietarioService _proprietariosService) : ControllerBase
    {
        /// <summary>
        /// Obtém uma lista de proprietários.
        /// </summary>
        /// <returns>Uma lista de objetos ProprietarioDTO.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get()
        {
            var proprietariosDTO = await _proprietariosService.GetAllAsync();

            if (proprietariosDTO is null || proprietariosDTO.Any() is false)
            {
                LogCustomWarning(actionName: "GET/Proprietarios",
                                    message: Constants.PROPRIETARIO_NAO_ENCONTRADO);
                return NotFound();
            }

            return Ok(proprietariosDTO);
        }

        /// <summary>
        /// Obtém um proprietário pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador único do proprietário (guid).</param>
        /// <returns>Um objeto ProprietarioDTO.</returns>
        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get(Guid id)
        {
            var proprietarioDTO = await _proprietariosService.GetByIdAsync(id);

            if (proprietarioDTO is null)
            {
                LogCustomWarning(actionName: "GET/Proprietarios/{id}",
                                    message: $"{Constants.PROPRIETARIO_NAO_ENCONTRADO} | {id}");
                return NotFound();
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post([FromBody] ProprietarioDTO proprietarioDTO)
        {
            if (proprietarioDTO is null)
            {
                LogCustomWarning(actionName: "POST/Proprietarios",
                                    message: Constants.DADOS_INVALIDOS);
                return BadRequest();
            }

            var novoProprietarioDTO = await _proprietariosService.CreateAsync(proprietarioDTO);

            return CreatedAtAction(nameof(Get),
                                   new { id = novoProprietarioDTO.Id },
                                   novoProprietarioDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProprietarioDTO proprietarioDTO)
        {
            if (id != proprietarioDTO.Id)
            {
                LogCustomWarning(actionName: "PUT/Proprietarios/{id}",
                                    message: $"{Constants.DADOS_INVALIDOS} | {id} | {proprietarioDTO.Id}");
                return BadRequest();
            }

            var existeProprietarioDTO = await _proprietariosService.GetByIdAsync(id);
            if (existeProprietarioDTO is null)
            {
                LogCustomWarning(actionName: "PUT/Proprietarios/{id}",
                                    message: $"{Constants.PROPRIETARIO_NAO_ENCONTRADO} | {id}");
                return NotFound();
            }

            await _proprietariosService.UpdateAsync(proprietarioDTO);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            var proprietarioExisteDTO = await _proprietariosService.GetByIdAsync(id);

            if (proprietarioExisteDTO is null)
            {
                LogCustomWarning(actionName: "DELETE/Proprietarios/{id}",
                                    message: $"{Constants.PROPRIETARIO_NAO_ENCONTRADO} | {id}");
                return NotFound();
            }

            await _proprietariosService.DeleteAsync(proprietarioExisteDTO);

            return NoContent();
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
