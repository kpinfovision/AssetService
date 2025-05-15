using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Xome.Cascase2.AssetService.Domain.Entities
{
    public class Asset
    {
        //public int Id { get; set; }
        //public string AssetId { get; set; }
        //public string LoanNumber { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Zip { get; set; }
        //// public string TransactionType { get; set; }
        //public string AssetType { get; set; } // ProductType / Client
        //public string SellerCode { get; set; } // req
        //public string AssetStatus { get; set; }
        //// public string PropertyType { get; set; }
        //public string AuctionFlag { get; set; } // req // Yes / No
        //public string SaleDate { get; set; } // req

        public int ASSET_ID { get; set; }
        public int POOL_ID { get; set; }
        public int AM_FIRM_ID { get; set; }
        public int STATUS_ID { get; set; }
        public string LOAN_NUMBER { get; set; }
        public string BORROWER_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string ZIP { get; set; }
        public string COUNTY { get; set; }
        public decimal LATITUDE { get; set; }
        public decimal LONGITUDE { get; set; }

        public string FILE_NUMBER { get; set; }
        public string VESTED_NAME { get; set; }
        public decimal PRINCIPAL_BALANCE { get; set; }
        public decimal INTEREST_RATE { get; set; }
        public DateTime PAID_THROUGH_DATE { get; set; }
        public int LIEN_POSITION { get; set; }
        public decimal DUE_DIL_VALUE { get; set; }
        public DateTime DUE_DIL_DATE { get; set; }
        public decimal BID_PURCHASE_VALUE { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime MODIFIED_ON { get; set; }
        public int MODIFIED_BY { get; set; }
        public bool ACTIVE { get; set; }
    }
}
