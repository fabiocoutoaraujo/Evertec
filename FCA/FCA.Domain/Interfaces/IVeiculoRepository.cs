using FCA.Domain.Entities;
using System.Collections;

namespace FCA.Domain.Interfaces;

public interface IVeiculoRepository : IRepository<Veiculo>
{
    Task<IEnumerable> GetAllByProprietarioAsync(Guid id);
}
