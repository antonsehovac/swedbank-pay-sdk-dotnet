﻿using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    class MobilePayPaymentDto
    {
        public int Amount { get; set; }
        public MobilePayPaymentAuthorizationListResponseDto Authorizations { get; set; }
        public CancellationsListResponseDto Cancellations { get; set; }
        public CaptureTransactionResponseDto Captures { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public Uri Id { get; set; }
        public string Instrument { get; set; }
        public string Intent { get; set; }
        public Language Language { get; set; }
        public long Number { get; set; }
        public string Operation { get; set; }
        public PayeeInfoDto PayeeInfo { get; set; }
        public string PayerReference { get; set; }
        public string InitiatingSystemUserAgent { get; set; }
        public PricesListResponseDto Prices { get; set; }
        public ReversalsListResponseDto Reversals { get; set; }
        public State State { get; set; }
        public TransactionListResponseDto Transactions { get; set; }
        public UrlsDto Urls { get; set; }
        public string UserAgent { get; set; }
        public MetadataDto Metadata { get; set; }
        public int VatAmount { get; set; }
        public int RemainingCancellationAmount { get; set; }
        public int RemainingCaptureAmount { get; set; }
        public int RemainingReversalAmount { get; set; }
    }
}