using FCA.Domain.Entities;

namespace FCA.Domain.Interfaces;

public interface IVeiculoRepository : IRepository<Veiculo>
{
    Task<IEnumerable<Veiculo>> GetAllByNomeProprietarioAsync(string nomeProprietario);
}
