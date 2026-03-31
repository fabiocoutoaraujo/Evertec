using FCA.Domain.Entities;
using FCA.Domain.Interfaces;
using FCA.Infrastructure.Context;
using System.Collections;

namespace FCA.Infrastructure.Repositories;

public class VeiculoRepository(ApplicationDbContext _dbContext) : Repository<Veiculo>(_dbContext),
                                                                  IVeiculoRepository
{
    public Task<IEnumerable> GetAllByProprietarioAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
