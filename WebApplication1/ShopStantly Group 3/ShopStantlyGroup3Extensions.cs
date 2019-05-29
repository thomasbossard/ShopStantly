﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace WebApplication2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for ShopStantlyGroup3.
    /// </summary>
    public static partial class ShopStantlyGroup3Extensions
    {
            /// <summary>
            /// Startet den Workflow mit einer neuen Bestellung
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// Input ist ein Order-JSON File
            /// </param>
            public static void Order(this IShopStantlyGroup3 operations, Order body = default(Order))
            {
                Task.Factory.StartNew(s => ((IShopStantlyGroup3)s).OrderAsync(body), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Startet den Workflow mit einer neuen Bestellung
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// Input ist ein Order-JSON File
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task OrderAsync(this IShopStantlyGroup3 operations, Order body = default(Order), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.OrderWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Löst den Bezahlvorgang auf einer Bestellung aus
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// Input ist ein Order-JSON File
            /// </param>
            public static void Invoicepost(this IShopStantlyGroup3 operations, InvoiceRequest body = default(InvoiceRequest))
            {
                Task.Factory.StartNew(s => ((IShopStantlyGroup3)s).InvoicepostAsync(body), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Löst den Bezahlvorgang auf einer Bestellung aus
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// Input ist ein Order-JSON File
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task InvoicepostAsync(this IShopStantlyGroup3 operations, InvoiceRequest body = default(InvoiceRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.InvoicepostWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Fragt den Bezahlstatus einer Bestellung ab. Response sollte einfach nur
            /// abgeschlossen oder nicht abgeschlossen sein.  Die Statusveränderung
            /// passiert dann wieder beim ControlService
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='orderID'>
            /// Input ist eine orderID Nummer
            /// </param>
            public static InvoiceState Invoiceget(this IShopStantlyGroup3 operations, long orderID)
            {
                return Task.Factory.StartNew(s => ((IShopStantlyGroup3)s).InvoicegetAsync(orderID), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Fragt den Bezahlstatus einer Bestellung ab. Response sollte einfach nur
            /// abgeschlossen oder nicht abgeschlossen sein.  Die Statusveränderung
            /// passiert dann wieder beim ControlService
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='orderID'>
            /// Input ist eine orderID Nummer
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<InvoiceState> InvoicegetAsync(this IShopStantlyGroup3 operations, long orderID, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.InvoicegetWithHttpMessagesAsync(orderID, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Löst den Warenausgang aus.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// Input ist ein Order-JSON File
            /// </param>
            public static void Inventorypost(this IShopStantlyGroup3 operations, InventoryRequest body = default(InventoryRequest))
            {
                Task.Factory.StartNew(s => ((IShopStantlyGroup3)s).InventorypostAsync(body), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Löst den Warenausgang aus.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='body'>
            /// Input ist ein Order-JSON File
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task InventorypostAsync(this IShopStantlyGroup3 operations, InventoryRequest body = default(InventoryRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.InventorypostWithHttpMessagesAsync(body, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Fragt den Inventory einer Bestellung ab. Response ist
            /// InventoryState:completed oder InventoryState:pending
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='orderID'>
            /// Input ist eine orderID Nummer
            /// </param>
            public static InventoryState Inventoryget(this IShopStantlyGroup3 operations, long orderID)
            {
                return Task.Factory.StartNew(s => ((IShopStantlyGroup3)s).InventorygetAsync(orderID), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Fragt den Inventory einer Bestellung ab. Response ist
            /// InventoryState:completed oder InventoryState:pending
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='orderID'>
            /// Input ist eine orderID Nummer
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<InventoryState> InventorygetAsync(this IShopStantlyGroup3 operations, long orderID, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.InventorygetWithHttpMessagesAsync(orderID, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Löst das Versenden einer Bestellung aus.
            /// </summary>
            /// Mit diesem Service kann eine Bestellung versendet werden. Der Shipping
            /// Service lieftert dann Daten beim externen Versandpartner ein.
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='shipmentRequest'>
            /// Input ist ein ShipmentRequest-JSON File
            /// </param>
            public static void Shipmentpost(this IShopStantlyGroup3 operations, ShipmentRequest shipmentRequest = default(ShipmentRequest))
            {
                Task.Factory.StartNew(s => ((IShopStantlyGroup3)s).ShipmentpostAsync(shipmentRequest), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Löst das Versenden einer Bestellung aus.
            /// </summary>
            /// Mit diesem Service kann eine Bestellung versendet werden. Der Shipping
            /// Service lieftert dann Daten beim externen Versandpartner ein.
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='shipmentRequest'>
            /// Input ist ein ShipmentRequest-JSON File
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ShipmentpostAsync(this IShopStantlyGroup3 operations, ShipmentRequest shipmentRequest = default(ShipmentRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ShipmentpostWithHttpMessagesAsync(shipmentRequest, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Fragt den Versand-Status einer Bestellung ab.
            /// </summary>
            /// Response ist ein JSON mit mit der OrderID, der TrackingNummer und dem
            /// Status.  Falls die Bestellung noch nicht versendet wurde
            /// trackingNumber=null
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='orderID'>
            /// Input ist eine orderID Nummer
            /// </param>
            public static ShipmentState Shipmentget(this IShopStantlyGroup3 operations, int orderID)
            {
                return Task.Factory.StartNew(s => ((IShopStantlyGroup3)s).ShipmentgetAsync(orderID), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Fragt den Versand-Status einer Bestellung ab.
            /// </summary>
            /// Response ist ein JSON mit mit der OrderID, der TrackingNummer und dem
            /// Status.  Falls die Bestellung noch nicht versendet wurde
            /// trackingNumber=null
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='orderID'>
            /// Input ist eine orderID Nummer
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ShipmentState> ShipmentgetAsync(this IShopStantlyGroup3 operations, int orderID, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ShipmentgetWithHttpMessagesAsync(orderID, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }
    }
}
