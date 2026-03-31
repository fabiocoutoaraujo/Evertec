using FCA.Application.DTOs;

namespace FCA.Application.Interfaces;

public interface IProprietarioService
{
    Task<IEnumerable<ProprietarioDTO>> GetAllAsync();
    Task<ProprietarioDTO> GetByIdAsync();
    Task<ProprietarioDTO> CreateAsync(ProprietarioDTO proprietarioDTO);
    Task<ProprietarioDTO> UpdateAsync(ProprietarioDTO proprietarioDTO);
    Task<ProprietarioDTO> DeleteAsync(ProprietarioDTO proprietarioDTO);
}
