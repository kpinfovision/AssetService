using Xome.Cascase2.AssetService.Domain.Entities;
using Xome.Cascase2.AssetService.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Azure.Messaging.ServiceBus;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Runtime;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Azure;
using System.Text;


namespace Xome.Cascase2.AssetService.Application.Services
{
    public class AssetsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _connectionString;
        private readonly ServiceBusPublisher _publisher;
        private readonly ExternalServiceSettings _settings;

        // , IUserService userService
        public AssetsService(IUnitOfWork unitOfWork, ServiceBusPublisher publisher, IOptions<ExternalServiceSettings> options)
        {
            _unitOfWork = unitOfWork;
            _publisher = publisher;
            _settings = options.Value;
        }

        public async Task<AssetUploadResponse> AddAsset(Asset asset)
        {
            //AssetUploadResponse assetUploadResponse = new AssetUploadResponse();
            //// todo: need to connect to DB
            //await _unitOfWork.ASSET.AddAsset(asset);
            //int result = await _unitOfWork.SaveChangesAsync();
            //if (result > 0)
            //{
            //    switch (asset.AssetType)
            //    {
            //        case "FCLT":
            //            // start workflow instance
            //            CamundaProcess camundaProcessData = await StartFCLTWorkflow(asset);
            //            if (camundaProcessData.processInstanceKey.Length > 0)
            //            {
            //                List<CamundaTask> camundaTaskList = new List<CamundaTask>();
            //                // get active camunda task list
            //                while (!camundaTaskList.Any())
            //                {
            //                    camundaTaskList = await getCamundaTaskList(camundaProcessData.processInstanceKey);
            //                }

            //                assetUploadResponse.assetId = asset.AssetId;
            //                assetUploadResponse.processDefinitionId = camundaProcessData.processDefinitionId;
            //                assetUploadResponse.processDefinitionKey = camundaProcessData.processDefinitionKey;
            //                assetUploadResponse.processInstanceKey = camundaProcessData.processInstanceKey;
            //                assetUploadResponse.workFlowTasks = camundaTaskList;
            //                Console.WriteLine(assetUploadResponse);
            //            }
            //            break;

            //        default:
            //            break;
            //    }
            //}

            //return assetUploadResponse;
            return null;
        }

        public async Task DeleteAsset(int id)
        {
            await _unitOfWork.ASSET.DeleteAsset(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Asset>> GetAllAssets()
        {
            return await _unitOfWork.ASSET.GetAllAssets();
        }

        public async Task<Asset> GetAssetById(string assetId)
        {
            return await _unitOfWork.ASSET.GetAssetById(assetId);
        }

        public async Task UpdateAsset(Asset asset)
        {
            await _unitOfWork.ASSET.UpdateAsset(asset);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<dynamic> UpdateAssetStatus(string assetId, string assetStatus, string processInstanceKey)
        {
            //await _unitOfWork.ASSET.UpdateAssetStatus(assetId, assetStatus);
            //await _unitOfWork.SaveChangesAsync();

            //var asset = await _unitOfWork.ASSET.GetAssetById(assetId);

            //if (asset != null)
            //{
            //    var updatedAsset = new { assetId = asset.AssetId, assetStatus = asset.AssetStatus, processInstanceKey = processInstanceKey };

            //    if (assetStatus.ToLower().Equals("cancel") || assetStatus.ToLower().Equals("hold"))
            //    {
            //        string messageBody = $@"{{
            //                              ""name"": ""remotebidding"",
            //                              ""correlationKey"": ""{asset.AssetId}""
            //                             }}";


            //        await _publisher.SendMessageAsync(messageBody);
            //    }

            //    return updatedAsset;
            //}

            return null;
        }

        public async Task TriggerExternalSystemEvent(string assetId, string eventName)
        {
            var messageBody = string.Empty;

            switch (eventName.ToLower())
            {
                case "sold":

                    messageBody = $@"{{
                                          ""name"": ""remotebidding"",
                                          ""correlationKey"": ""{assetId}"",
                                          ""variables"": {{
                                                            ""sold"": ""YES""
                                                         }}
                                         }}";
                    break;
                case "hold":
                    messageBody = $@"{{
                                          ""name"": ""holdOrCancel"",
                                          ""correlationKey"": ""{assetId}"",
                                          ""variables"": {{
                                                            ""hold"": true
                                                         }}
                                         }}";
                    break;
                case "unhold":
                    messageBody = $@"{{
                                          ""name"": ""unHold"",
                                          ""correlationKey"": ""{assetId}""
                                         }}";
                    break;
                case "cancel":
                    messageBody = $@"{{
                                          ""name"": ""holdOrCancel"",
                                          ""correlationKey"": ""{assetId}"",
                                          ""variables"": {{
                                                            ""hold"": false
                                                         }}
                                         }}";
                    break;
            }

            await _publisher.SendMessageAsync(messageBody);
        }

        public async Task TriggerExternalSystemEvent(string assetId)
        {
            string messageBody = $@"{{
                                          ""name"": ""remotebidding"",
                                          ""correlationKey"": ""{assetId}"",
                                          ""variables"": {{
                                                            ""sold"": ""YES""
                                                         }}
                                         }}";


            await _publisher.SendMessageAsync(messageBody);
        }

        #region Private Methods
        //public async Task<CamundaProcess> StartFCLTWorkflow(Asset asset)
        //{
        //    var handler = new HttpClientHandler
        //    {
        //        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        //    };

        //    // processDefinitionId = "AssetOnboardingBPM",              
        //    HttpClient _httpClient = new HttpClient(handler);
        //    var requestBody = new
        //    {
        //        auctionFlag = asset.AuctionFlag,
        //        assignee = asset.SellerCode.ToLower() == "pennymac" ? "Asset Manager" : "Auction Manager",
        //        productType = asset.AssetType,
        //        saleDate = asset.SaleDate,
        //        assetState = asset.State,
        //        assetId = asset.AssetId,
        //        user = "sujata.telang@infovision.com",
        //    };
        //    var url = $"{_settings.CamundaServiceBaseUrl}/api/Camunda/FCLTStartProcess";

        //    var response = await _httpClient.PostAsJsonAsync(url, requestBody);

        //    response.EnsureSuccessStatusCode(); // throws if not 2xx

        //    return await response.Content.ReadFromJsonAsync<CamundaProcess>();
        //}

        public async Task<List<CamundaTask>> getCamundaTaskList(string processInstanceKey)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            HttpClient _httpClient = new HttpClient(handler);

            var requestBody = new { };
            var url = $"{_settings.CamundaServiceBaseUrl}/api/Camunda/GetProcessInstanceTasks?processInstanceKey={processInstanceKey}";
            var response = await _httpClient.PostAsJsonAsync(url, requestBody);

            response.EnsureSuccessStatusCode(); // throws if not 2xx

            return await response.Content.ReadFromJsonAsync<List<CamundaTask>>();
        }
        #endregion
    }
}