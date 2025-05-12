using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascase2.AssetService.Domain.Entities
{
    public class AssetUploadResponse
    {
        public string processDefinitionKey { get; set; }
        public string processInstanceKey { get; set; }
        public string processDefinitionId { get; set; }
        public string assetId { get; set; }
        public List<CamundaTask> workFlowTasks { get; set; }
    }
}
