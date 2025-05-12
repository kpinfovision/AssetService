using Microsoft.AspNetCore.Mvc;
using System;
using Xome.Cascase2.AssetService.Application.Services;
using Xome.Cascase2.AssetService.Domain.Entities;

namespace Xome.Cascase2.AssetService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        public readonly AssetsService _assetService;
        public AssetController(AssetsService assetService)
        {
            _assetService = assetService;
        }
        [HttpGet]
        public async Task<IEnumerable<Asset>> GetAllAssets()
        {
            return await _assetService.GetAllAssets();
        }

        [HttpGet("{assetId}")]
        public async Task<Asset> GetAssetById(string assetId)
        {
            return await _assetService.GetAssetById(assetId);
        }

        [HttpPost]
        public async Task<AssetUploadResponse> AddAsset(Asset asset)
        {
            return await _assetService.AddAsset(asset);
        }

        [HttpPut]
        public async Task UpdateAsset(Asset asset)
        {
            await _assetService.UpdateAsset(asset);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsset(int id)
        {
            await _assetService.DeleteAsset(id);
        }

        [HttpPut("UpdateAssetStatus")]
        public async Task<dynamic> UpdateAssetStatus(string assetId, string assetStatus, string processInstanceKey)
        {
            var asset = await _assetService.UpdateAssetStatus(assetId, assetStatus, processInstanceKey);
            return asset;
        }

        [HttpPost("TriggerExternalSystemEvent")]
        public async Task TriggerExternalSystemEvent(string assetId, string eventName)
        {
            await _assetService.TriggerExternalSystemEvent(assetId, eventName);
        }
    }
}