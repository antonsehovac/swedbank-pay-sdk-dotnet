﻿using SwedbankPay.Sdk.PaymentInstruments.Card;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class CardPaymentResponseDto
    {
        public PaymentOperationsDto Operations { get; set; }

        public CardPaymentDto Payment { get; set; }

        public ICardPaymentResponse Map(HttpClient httpClient)
        {
            return new CardPaymentResponse(this, httpClient);
        }
    }
}