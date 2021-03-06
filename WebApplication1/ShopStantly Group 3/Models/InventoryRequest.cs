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

    public partial class InventoryRequest
    {
        /// <summary>
        /// Initializes a new instance of the InventoryRequest class.
        /// </summary>
        public InventoryRequest() { }

        /// <summary>
        /// Initializes a new instance of the InventoryRequest class.
        /// </summary>
        public InventoryRequest(int? orderId = default(int?), int? articleId = default(int?), int? quantity = default(int?))
        {
            OrderId = orderId;
            ArticleId = articleId;
            Quantity = quantity;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "orderId")]
        public int? OrderId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "articleId")]
        public int? ArticleId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int? Quantity { get; set; }

    }
}
