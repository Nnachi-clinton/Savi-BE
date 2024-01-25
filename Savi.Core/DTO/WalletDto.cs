﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Savi.Core.DTO
{
    public class WalletDto
    {
        //public string WalletNumber { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public string Reference { get; set; }
        public string PaystackCustomerCode { get; set; }
        public string AppUserId { get; set; }
        public string TransactionPin { get; set; }
    }
}
