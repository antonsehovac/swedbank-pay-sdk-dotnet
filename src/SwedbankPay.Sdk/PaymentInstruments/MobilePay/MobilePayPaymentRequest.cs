﻿using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentRequest
    {
        public MobilePayPaymentRequest(Operation operation,
                              PaymentIntent intent,
                              Currency currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              Uri shopslogoUrl,
                              string payerReference = null,
                              MetadataResponse metadata = null,
                              PrefillInfo prefillInfo = null)

        {
            Payment = new MobilePayPaymentDetails(operation, intent, currency, prices, description, payerReference, userAgent, language, urls, payeeInfo, metadata, prefillInfo);
            MobilePay = new MobilePayPaymentRequestDetails(shopslogoUrl);
        }

        /// <summary>
        /// Information about the payment to be created.
        /// </summary>
        public IMobilePayPaymentDetails Payment { get; }

        /// <summary>
        /// MobilePay specific payment data, making a custom logo for the merchant available.
        /// </summary>
        public MobilePayPaymentRequestDetails MobilePay { get; }
    }
}
