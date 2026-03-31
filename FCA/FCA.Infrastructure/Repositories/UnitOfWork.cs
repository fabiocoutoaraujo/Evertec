using FCA.Domain.Interfaces;
using FCA.Infrastructure.Context;

namespace FCA.Infrastructure.Repositories;

public class UnitOfWork(ApplicationDbContext _dbContext) : IUnitOfWork
{
    // Não injeto as instâncias via construtor para não criar uma instância toda vez que UnitOfWork for chamado
    private IProprietarioRepository? _proprietarioRepository;
    private IVeiculoRepository? _veiculoRepository;

    // Lazy loading
    public IProprietarioRepository ProprietarioRepository
    {
        get 
        {
            return _proprietarioRepository ??= new ProprietarioRepository(_dbContext);
        }
    }

    public IVeiculoRepository VeiculoRepository
    {
        get
        {
            return _veiculoRepository ??= new VeiculoRepository(_dbContext);
        }
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    // No contexto do Entity Framework meu ApplicationDbContext aloca recursos não gerenciados
    // como conexões com o banco. Aqui estou garantindo que as alocações serão sinalizadas ao GC
    // para futura liberação de recursos.
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
