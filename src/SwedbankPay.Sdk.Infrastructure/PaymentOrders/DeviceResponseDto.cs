﻿namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class DeviceResponseDto
    {
        public int DetectionAccuracy { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string DeviceType { get; set; }
        public string HardwareFamily { get; set; }
        public string HardwareName { get; set; }
        public string HardwareVendor { get; set; }
        public string PlatformName { get; set; }
        public string PlatformVendor { get; set; }
        public string PlatformVersion { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVendor { get; set; }
        public string BrowserVersion { get; set; }
        public bool BrowserJavaEnabled { get; set; }
        
        internal IDeviceResponse Map()
        {
            return new DeviceResponse(this);
        }
    }
}
