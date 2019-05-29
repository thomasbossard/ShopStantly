﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace WebApplication2.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class InvoiceState
    {
        /// <summary>
        /// Initializes a new instance of the InvoiceState class.
        /// </summary>
        public InvoiceState() { }

        /// <summary>
        /// Initializes a new instance of the InvoiceState class.
        /// </summary>
        public InvoiceState(int? orderId = default(int?), string paymentState = default(string))
        {
            OrderId = orderId;
            PaymentState = paymentState;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "orderId")]
        public int? OrderId { get; set; }

        /// <summary>
        /// Possible values include: 'PENDING', 'COMPLETED'
        /// </summary>
        [JsonProperty(PropertyName = "paymentState")]
        public string PaymentState { get; set; }

    }
}