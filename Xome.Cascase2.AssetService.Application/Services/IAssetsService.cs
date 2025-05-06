﻿using Xome.Cascase2.AssetService.Domain.Entities;

namespace Xome.Cascase2.AssetService.Application.Services
{
    public interface IAssetsService
    {
        Task<IEnumerable<Asset>> GetAllAssets();
        Task<Asset> GetAssetById(string assetId);
        Task AddAsset(Asset asset);
        Task UpdateAsset(Asset asset);
        Task DeleteAsset(int id);

    }
}