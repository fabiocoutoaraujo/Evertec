using FCA.Domain.Entities;
using FCA.Domain.Interfaces;
using FCA.Infrastructure.Context;
using System.Linq.Expressions;

namespace FCA.Infrastructure.Repositories;

public class ProprietarioRepository(ApplicationDbContext _dbContext) : IProprietarioRepository
{
    public Proprietario Create(Proprietario entity)
    {
        throw new NotImplementedException();
    }

    public Proprietario Delete(Proprietario entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Proprietario>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Proprietario?> GetAsync(Expression<Func<Proprietario, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<Proprietario> GetByCPFAsync(string cpf)
    {
        throw new NotImplementedException();
    }

    public Proprietario Update(Proprietario entity)
    {
        throw new NotImplementedException();
    }
}
