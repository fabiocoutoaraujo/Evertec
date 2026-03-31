using AutoMapper;
using FCA.Application.DTOs;
using FCA.Application.Interfaces;
using FCA.Domain.Interfaces;

namespace FCA.Application.Services;

public class ProprietarioService(IUnitOfWork _unitOfWork,
                                 IMapper _mapper) : IProprietarioService
{
    public async Task<IEnumerable<ProprietarioDTO>> GetAllAsync()
    {
        var proprietarios = await _unitOfWork.ProprietarioRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<ProprietarioDTO>>(proprietarios);                                              
    }

    public async Task<ProprietarioDTO> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ProprietarioDTO> CreateAsync(ProprietarioDTO proprietarioDTO)
    {
        throw new NotImplementedException();
    }       

    public async Task<ProprietarioDTO> UpdateAsync(ProprietarioDTO proprietarioDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<ProprietarioDTO> DeleteAsync(ProprietarioDTO proprietarioDTO)
    {
        throw new NotImplementedException();
    }
}
