using FCA.Domain.Entities;
using FCA.Domain.Interfaces;
using System.Linq.Expressions;

namespace FCA.Infrastructure.Repositories;

public class ProprietarioRepository : IProprietarioRepository
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
