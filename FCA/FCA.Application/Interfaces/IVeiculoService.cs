using FCA.Application.DTOs;

namespace FCA.Application.Interfaces;

public interface IVeiculoService
{
    Task<IEnumerable<VeiculoDTO>> GetAllAsync();
    Task<VeiculoDTO> GetByIdAsync(VeiculoDTO veiculoDTO);
    Task<VeiculoDTO> CreateAsync(VeiculoDTO veiculoDTO);
    Task<VeiculoDTO> UpdateAsync(VeiculoDTO veiculoDTO);
    Task<VeiculoDTO> DeleteAsync(VeiculoDTO veiculoDTO);
}
