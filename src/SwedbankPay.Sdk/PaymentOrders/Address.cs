﻿namespace SwedbankPay.Sdk.PaymentOrders
{
    public class Address
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Msisdn { get; set; }
        public string StreetAddress { get; set; }
        public string CoAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }
    }
}