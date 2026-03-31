using FCA.Domain.Entities;
using FCA.Domain.Interfaces;
using FCA.Infrastructure.Context;

namespace FCA.Infrastructure.Repositories;

public class ProprietarioRepository(ApplicationDbContext _dbContext) : Repository<Proprietario>(_dbContext),
                                                                       IProprietarioRepository
{
    public Task<Proprietario> GetByCPFAsync(string cpf)
    {
        throw new NotImplementedException();
    }
}