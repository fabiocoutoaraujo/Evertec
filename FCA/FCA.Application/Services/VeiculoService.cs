using AutoMapper;
using FCA.Application.DTOs;
using FCA.Application.Interfaces;
using FCA.Domain.Entities;
using FCA.Domain.Interfaces;

namespace FCA.Application.Services;

public class VeiculoService(IUnitOfWork _unitOfWork,
                            IMapper _mapper) : IVeiculoService
{
    public async Task<IEnumerable<VeiculoDTO>> GetAllAsync()
    {
        var veiculos = await _unitOfWork.ProprietarioRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculos);
    }

    public async Task<VeiculoDTO> GetByIdAsync(Guid id)
    {
        var proprietario = await _unitOfWork.ProprietarioRepository.GetAsync(p => p.Id == id);

        return _mapper.Map<VeiculoDTO>(proprietario);
    }

    public async Task<VeiculoDTO> CreateAsync(VeiculoDTO veiculoDTO)
    {
        var veiculo = _mapper.Map<Proprietario>(veiculoDTO);

        var novoVeiculo = _unitOfWork.ProprietarioRepository.Create(veiculo);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<VeiculoDTO>(novoVeiculo);
    }

    public async Task<VeiculoDTO> UpdateAsync(VeiculoDTO veiculoDTO)
    {
        var veiculo = _mapper.Map<Proprietario>(veiculoDTO);

        var veiculoAtualizado = _unitOfWork.ProprietarioRepository.Update(veiculo);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<VeiculoDTO>(veiculoAtualizado);
    }

    public async Task<VeiculoDTO> DeleteAsync(VeiculoDTO veiculoDTO)
    {
        var veiculo = _mapper.Map<Proprietario>(veiculoDTO);

        var veiculoDeletado = _unitOfWork.ProprietarioRepository.Delete(veiculo);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<VeiculoDTO>(veiculoDeletado);
    }
}