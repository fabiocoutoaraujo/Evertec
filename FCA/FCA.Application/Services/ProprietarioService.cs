using AutoMapper;
using FCA.Application.DTOs;
using FCA.Application.Interfaces;
using FCA.Domain.Entities;
using FCA.Domain.Interfaces;
using FCA.Domain.Validations;

namespace FCA.Application.Services;

public class ProprietarioService(IUnitOfWork _unitOfWork,
                                 IMapper _mapper) : IProprietarioService
{
    public async Task<IEnumerable<ProprietarioDTO>> GetAllAsync()
    {
        var proprietarios = await _unitOfWork.ProprietarioRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<ProprietarioDTO>>(proprietarios);
    }

    public async Task<ProprietarioDTO> GetByIdAsync(Guid id)
    {
        var proprietario = await _unitOfWork.ProprietarioRepository.GetAsync(p => p.Id == id);

        return _mapper.Map<ProprietarioDTO>(proprietario);
    }

    public async Task<ProprietarioDTO> CreateAsync(ProprietarioDTO proprietarioDTO)
    {
        var proprietario = _mapper.Map<Proprietario>(proprietarioDTO);

        var novoProprietario = _unitOfWork.ProprietarioRepository.Create(proprietario);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<ProprietarioDTO>(novoProprietario);
    }       

    public async Task<ProprietarioDTO> UpdateAsync(ProprietarioDTO proprietarioDTO)
    {
        var proprietario = _mapper.Map<Proprietario>(proprietarioDTO);

        var proprietarioAtualizado = _unitOfWork.ProprietarioRepository.Update(proprietario);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<ProprietarioDTO>(proprietarioAtualizado);
    }

    public async Task<ProprietarioDTO> DeleteAsync(ProprietarioDTO proprietarioDTO)
    {
        var veiculo = await _unitOfWork.VeiculoRepository.GetAsync(p => p.ProprietarioId == proprietarioDTO.Id);
        if (veiculo != null) 
            throw new ProprietarioPossuiVeiculoException();

        var proprietario = _mapper.Map<Proprietario>(proprietarioDTO);

        var proprietarioDeletado = _unitOfWork.ProprietarioRepository.Delete(proprietario);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<ProprietarioDTO>(proprietarioDeletado);
    }
}
