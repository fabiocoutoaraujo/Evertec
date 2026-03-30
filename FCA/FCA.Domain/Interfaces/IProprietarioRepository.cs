using FCA.Domain.Entities;

namespace FCA.Domain.Interfaces;

public interface IProprietarioRepository : IRepository<Proprietario>
{
    Task<Proprietario> GetByCPFAsync(string cpf);
}
