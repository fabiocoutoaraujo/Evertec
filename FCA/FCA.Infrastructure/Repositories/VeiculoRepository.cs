using FCA.Domain.Entities;
using FCA.Domain.Interfaces;
using FCA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FCA.Infrastructure.Repositories;

public class VeiculoRepository(ApplicationDbContext _dbContext) : Repository<Veiculo>(_dbContext),
                                                                  IVeiculoRepository
{ 
    public async Task<IEnumerable<Veiculo>>GetAllByNomeProprietarioAsync(string nomeProprietario)
    {
        var veiculos = _dbContext.Veiculos;
        var proprietarios = _dbContext.Proprietarios;
        
        var queryable = from v in veiculos
                        join p in proprietarios 
                          on v.ProprietarioId equals p.Id
                       where p.Nome == nomeProprietario
                     orderby v.Modelo
                      select v;
        
        return await queryable.AsNoTracking() // remove o overhead do Change Tracker
                              .ToListAsync();
    }
}
