using AutoMapper;
using FCA.Application.DTOs;
using FCA.Application.Interfaces;
using FCA.Domain.Entities;
using FCA.Domain.Interfaces;
using System.Numerics;
using System.Reflection;

namespace FCA.Application.Services;

public class VeiculoService(IUnitOfWork _unitOfWork,
                            IMapper _mapper) : IVeiculoService
{
    public async Task<IEnumerable<VeiculoDTO>> GetAllAsync()
    {
        var veiculos = await _unitOfWork.VeiculoRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculos);
    }

    public async Task<VeiculoDTO> GetByIdAsync(Guid id)
    {
        var veiculo = await _unitOfWork.VeiculoRepository.GetAsync(p => p.Id == id);

        return _mapper.Map<VeiculoDTO>(veiculo);
    }

    public async Task<VeiculoDTO> GetByPlacaAsync(VeiculoFiltroPlacaDTORequest veiculoFiltroPlacaDTORequest)
    {
        var veiculo = await _unitOfWork.VeiculoRepository.GetAsync(p => p.Placa == veiculoFiltroPlacaDTORequest.Placa);

        return _mapper.Map<VeiculoDTO>(veiculo);
    }

    public async Task<VeiculoDTO> GetByModeloAsync(VeiculoFiltroModeloDTORequest veiculoFiltroModeloDTORequest)
    {
        var veiculo = await _unitOfWork.VeiculoRepository.GetAsync(p => p.Modelo == veiculoFiltroModeloDTORequest.Modelo);

        return _mapper.Map<VeiculoDTO>(veiculo);
    }

    public async Task<IEnumerable<VeiculoDTO>> GetByNomeProprietarioAsync(ProprietarioFiltroNomeDTORequest proprietarioFiltroNomeDTORequest)
    {
        var veiculos = await _unitOfWork.VeiculoRepository.GetAllByNomeProprietarioAsync(proprietarioFiltroNomeDTORequest.Nome); ;

        return _mapper.Map<IEnumerable<VeiculoDTO>>(veiculos);
    }

    public async Task<VeiculoDTO> CreateAsync(VeiculoDTO veiculoDTO)
    {
        var veiculo = _mapper.Map<Veiculo>(veiculoDTO);

        var novoVeiculo = _unitOfWork.VeiculoRepository.Create(veiculo);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<VeiculoDTO>(novoVeiculo);
    }

    public async Task<VeiculoDTO> UpdateAsync(VeiculoDTO veiculoDTO)
    {
        var veiculo = _mapper.Map<Veiculo>(veiculoDTO);

        var veiculoAtualizado = _unitOfWork.VeiculoRepository.Update(veiculo);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<VeiculoDTO>(veiculoAtualizado);
    }

    public async Task<VeiculoDTO> DeleteAsync(VeiculoDTO veiculoDTO)
    {
        var veiculo = _mapper.Map<Veiculo>(veiculoDTO);

        var veiculoDeletado = _unitOfWork.VeiculoRepository.Delete(veiculo);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<VeiculoDTO>(veiculoDeletado);
    }
}