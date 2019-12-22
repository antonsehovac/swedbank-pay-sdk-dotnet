﻿using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.Payments
{
    public class Payment
    {
        private Payment(PaymentResponseContainer paymentResponseContainer, SwedbankPayHttpClient client)
        {
            PaymentResponse = paymentResponseContainer.Payment;
            var operations = new Operations();

            foreach (var httpOperation in paymentResponseContainer.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        operations.Update =
                            new ExecuteRequestWrapper<PaymentOrderUpdateRequestContainer, PaymentOrderResponseContainer>(
                                httpOperation.Request, client);
                        break;

                    case PaymentOperations.ViewAuthorization:
                        operations.ViewAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.RedirectAuthorization:
                        operations.RedirectAuthorization = httpOperation;
                        break;

                    case PaymentOperations.DirectAuthorization:
                        operations.DirectAuthorization =
                            new ExecuteRequestWrapper<TransactionRequestContainer, PaymentOrderResponseContainer>(
                                httpOperation.Request, client);
                        break;

                    case PaymentResourceOperations.CreateCapture:
                        operations.Capture =
                            new ExecuteRequestWrapper<TransactionRequestContainer, CaptureTransactionResponseContainer>(
                                httpOperation.Request, client);
                        break;

                    case PaymentResourceOperations.CreateCancellation:
                        operations.Cancel =
                            new ExecuteRequestWrapper<TransactionRequestContainer, CancellationTransactionResponseContainer>(
                                httpOperation.Request, client);
                        break;

                    case PaymentResourceOperations.CreateReversal:
                        operations.Reversal =
                            new ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer>(
                                httpOperation.Request, client);
                        break;

                    case PaymentOperations.RedirectVerification:
                        operations.RedirectVerification = httpOperation;
                        break;

                    case PaymentOperations.ViewVerification:
                        operations.ViewVerification = httpOperation;
                        break;

                    case PaymentOperations.DirectVerification:
                        operations.DirectVerification =
                            new ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer>(
                                httpOperation.Request, client);
                        break;

                    case PaymentResourceOperations.PaidPayment:
                        operations.PaidPayment =
                            new ExecuteRequestWrapper<TransactionRequestContainer, ReversalTransactionResponseContainer>(
                                httpOperation.Request, client);

                        break;
                }
            }

            Operations = operations;
        }


        public Operations Operations { get; }

        public PaymentResponse PaymentResponse { get; }


        internal static async Task<Payment> Create(PaymentType paymentType,
                                                   PaymentRequest paymentRequest,
                                                   SwedbankPayHttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/{paymentType}/payments{paymentExpand}", UriKind.Relative);

            var payload = new PaymentRequestContainer(paymentRequest);

            var paymentResponseContainer = await client.HttpPost<PaymentResponseContainer>(url, payload);
            return new Payment(paymentResponseContainer, client);
        }

        internal static async Task<Payment> Get(Uri id, SwedbankPayHttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.HttpGet<PaymentResponseContainer>(url);
            return new Payment(paymentResponseContainer, client); 
        }
    }
}