using Xome.Cascase2.AssetService.Domain.Interfaces;

namespace Xome.Cascase2.AssetService.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAssetRepository ASSET { get; }       
        Task<int> SaveChangesAsync();
    }
}
