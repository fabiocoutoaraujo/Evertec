using FCA.Application.DTOs;

namespace FCA.Application.Interfaces;

public interface IVeiculoService
{
    Task<IEnumerable<VeiculoDTO>> GetAllAsync();
    Task<VeiculoDTO> GetByIdAsync(Guid id);
    Task<VeiculoDTO> GetByPlacaAsync(VeiculoFiltroPlacaDTORequest veiculoFiltroPlacaDTORequest);
    Task<VeiculoDTO> GetByModeloAsync(VeiculoFiltroModeloDTORequest veiculoFiltroModeloDTORequest);
    Task<IEnumerable<VeiculoDTO>> GetByNomeProprietarioAsync(ProprietarioFiltroNomeDTORequest proprietarioFiltroNomeDTORequest);
    Task<VeiculoDTO> CreateAsync(VeiculoDTO veiculoDTO);
    Task<VeiculoDTO> UpdateAsync(VeiculoDTO veiculoDTO);
    Task<VeiculoDTO> DeleteAsync(VeiculoDTO veiculoDTO);
}
