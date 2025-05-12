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
        public int Id { get; set; }
        public string AssetId { get; set; }
        public string LoanNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        // public string TransactionType { get; set; }
        public string AssetType { get; set; } // ProductType / Client
        public string SellerCode { get; set; } // req
        public string AssetStatus { get; set; }
        // public string PropertyType { get; set; }
        public string AuctionFlag { get; set; } // req // Yes / No
        public string SaleDate { get; set; } // req

        //   ASSET_ID INT IDENTITY(1,1), 
        //   POOL_ID INT NOT NULL,
        //   AM_FIRM_ID INT NOT NULL,
        //   STATUS_ID INT NOT NULL,
        //   LOAN_NUMBER VARCHAR(30) NOT NULL,
        //   BORROWER_NAME VARCHAR(50) NOT NULL,
        //   ADDRESS VARCHAR(50) NOT NULL,
        //   CITY VARCHAR(30) NOT NULL,
        //   STATE VARCHAR(2) NOT NULL,
        //   ZIP VARCHAR(10) NOT NULL,
        //   COUNTY VARCHAR(50) NOT NULL,
        //   LATITUDE DECIMAL(9,6),
        //   LONGITUDE DECIMAL(9,6),
        //   FILE_NUMBER VARCHAR(50) NOT NULL,
        //   VESTED_NAME VARCHAR(MAX) NOT NULL,
        //   PRINCIPAL_BALANCE NUMERIC(18,2),
        //   INTEREST_RATE NUMERIC(5,2),
        //   PAID_THROUGH_DATE DATETIME,
        //   LIEN_POSITION INT,
        //   DUE_DIL_VALUE NUMERIC(18,2),
        //   DUE_DIL_DATE DATETIME,
        //   BID_PURCHASE_VALUE NUMERIC(18,2),
        //   CREATED_ON DATETIME NOT NULL,
        //   CREATED_BY INT NOT NULL,
        //   MODIFIED_ON DATETIME NOT NULL,
        //   MODIFIED_BY INT NOT NULL,
        //   ACTIVE BIT NOT NULL
    }
}
