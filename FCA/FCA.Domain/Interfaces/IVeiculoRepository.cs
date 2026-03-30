using FCA.Domain.Entities;

namespace FCA.Domain.Interfaces;

public interface IVeiculoRepository : IRepository<Veiculo>
{
    Task<IQueryable> GetAllByProprietarioAsync(Guid id);
}
