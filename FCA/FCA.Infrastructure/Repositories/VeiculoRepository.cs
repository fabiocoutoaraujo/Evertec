using FCA.Domain.Entities;
using FCA.Domain.Interfaces;
using System.Linq.Expressions;

namespace FCA.Infrastructure.Repositories;

public class VeiculoRepository : IVeiculoRepository
{
    public Veiculo Create(Veiculo entity)
    {
        throw new NotImplementedException();
    }

    public Veiculo Delete(Veiculo entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Veiculo>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable> GetAllByProprietarioAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Veiculo?> GetAsync(Expression<Func<Veiculo, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Veiculo Update(Veiculo entity)
    {
        throw new NotImplementedException();
    }
}
