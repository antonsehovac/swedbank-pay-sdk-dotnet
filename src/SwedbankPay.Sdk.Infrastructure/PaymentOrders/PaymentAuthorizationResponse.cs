﻿using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentAuthorizationResponse : IPaymentAuthorizationResponse
    {
        public PaymentAuthorizationResponse(PaymentOrderAuthorizationsDto dto)
        {
            Id = new Uri(dto.Id, UriKind.RelativeOrAbsolute);
            Created = dto.Created;
            Updated = dto.Updated;
            Type = dto.Type;
            State = dto.State;
            Number = dto.Number;
            Amount = dto.Amount;
            VatAmount = dto.VatAmount;
            Description = dto.Description;
            PayeeReference = dto.PayeeReference;
        }

        public Uri Id { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public PaymentType Type { get; }

        public State State { get; }

        public string Number { get; }

        public Amount Amount { get; }

        public Amount VatAmount { get; }

        public string Description { get; }

        public string PayeeReference { get; }
    }
}