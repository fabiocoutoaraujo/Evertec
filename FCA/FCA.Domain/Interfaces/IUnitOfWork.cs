namespace FCA.Domain.Interfaces;

public interface IUnitOfWork
{    
    IProprietarioRepository ProprietarioRepository { get; }
    IVeiculoRepository VeiculoRepository { get; }
    Task CommitAsync();
}
