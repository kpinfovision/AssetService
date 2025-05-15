using Xome.Cascase2.AssetService.Domain.Interfaces;
using Xome.Cascase2.AssetService.Infrastructure.Data;

namespace Xome.Cascase2.AssetService.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IAssetRepository ASSET { get; }        
        public UnitOfWork(
            AppDbContext context,
            IAssetRepository assetRepository            
            )
        {
            _context = context;
            ASSET = assetRepository;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
