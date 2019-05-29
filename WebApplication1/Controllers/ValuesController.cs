using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ShopStantly_Group_3;
using WebApplication2;
using WebApplication2.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public ShopStantlyGroup3 httpMachine = new ShopStantlyGroup3(new Uri("https://cyrill-fueglister.outsystemscloud.com/EAI/rest"), new AnonymousCredential());
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //InvoiceRequest invRequest = new InvoiceRequest(12,123,"testcustomer","testAddress");
            //t.Invoicepost(invRequest);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            InvoiceState invState = httpMachine.Invoiceget(id);
            return (invState.OrderId.ToString() + ";" + invState.PaymentState.ToString());
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] Order order)
        {
            Task.Run(() => mainFunction(order));
                        
            return order.OrderID.ToString();
        }

        private void mainFunction(Order order)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": POST Request received. OrderId: " + order.OrderID.Value.ToString());
            }

            //write data in DB
            MySqlConnection con = new MySqlConnection("server=localhost; user id = root; database = shopdb; password =");
            con.Open();
            string Query = "insert into shopdb.controller(OrderID,CustomerName,CustomerAddress,CustomerEmail,ArticleId,Quantity,Price,OrderSize,OrderWeight) values('" + order.OrderID + "','" + order.CustomerName + "','" + order.CustomerAddress + "','" + order.CustomerEMail + "','" + order.ArticleID + "','" + order.Quantity + "','" + order.Price + "','" + order.OrderSize + "','" + order.OrderWeight + "');";
            MySqlCommand command = new MySqlCommand(Query, con);
            command.ExecuteReader();
            con.Close();

            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Database Updated - initial Request");
            }

            //new Invoice Request
            InvoiceRequest invRequest = new InvoiceRequest(order.OrderID, order.Price, order.CustomerName, order.CustomerAddress);
            httpMachine.Invoicepost(invRequest);
            System.Threading.Thread.Sleep(1000);
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Sent POST to Invoice API. OrderId: " + order.OrderID.Value.ToString());
            }

            //warten, bis der Invoice Request abgeschlossen ist
            InvoiceState invState = httpMachine.Invoiceget(order.OrderID.Value);
            while (!invState.PaymentState.Equals("completed"))
            {
                using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Invoice not paid yet, waiting 5 Seconds. OrderId: " + order.OrderID.Value.ToString());
                }
                System.Threading.Thread.Sleep(5000);
                invState = httpMachine.Invoiceget(order.OrderID.Value);
            }
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Invoice paid");
            }

            //DB schreiben
            con = new MySqlConnection("server=localhost; user id = root; database = shopdb; password =");
            con.Open();
            Query = ("update controller set PaymentState = 1 where OrderId = " + order.OrderID.Value.ToString());
            MySqlCommand command2 = new MySqlCommand(Query, con);
            command2.ExecuteReader();
            con.Close();
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Database Updated - InvoiceState");
            }

            //new Inventory Request
            InventoryRequest ivtRequest = new InventoryRequest(order.OrderID, order.ArticleID, order.Quantity);
            httpMachine.Inventorypost(ivtRequest);
            System.Threading.Thread.Sleep(1000);
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Sent POST to Inventory API. OrderId: " + order.OrderID.Value.ToString());
            }

            //warten, bis der Inventory Request abgeschlossen ist
            InventoryState ivtState = httpMachine.Inventoryget(order.OrderID.Value);
            while (!ivtState.InventoryStateProperty.Equals("completed"))
            {
                using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Inventory not yet commissioned, waiting 5 Seconds. OrderId: " + order.OrderID.Value.ToString());
                }
                System.Threading.Thread.Sleep(5000);
                ivtState = httpMachine.Inventoryget(order.OrderID.Value);
            }
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Inventory commissioned");
            }

            //DB schreiben
            con = new MySqlConnection("server=localhost; user id = root; database = shopdb; password =");
            con.Open();
            Query = ("update controller set InventoryState = 1 where OrderId = " + order.OrderID.Value.ToString());
            MySqlCommand command3 = new MySqlCommand(Query, con);
            command3.ExecuteReader();
            con.Close();
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Database Updated - InventoryState");
            }

            //new Shipment Request
            ShipmentRequest shpRequest = new ShipmentRequest(order.OrderID, order.OrderSize, order.OrderWeight, order.CustomerName, order.CustomerAddress, order.CustomerEMail);
            httpMachine.Shipmentpost(shpRequest);
            System.Threading.Thread.Sleep(1000);
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Sent POST to Shipment API. OrderId: " + order.OrderID.Value.ToString());
            }

            //warten, bis der Shipment Request abgeschlossen ist
            ShipmentState shpState = httpMachine.Shipmentget(order.OrderID.Value);
            while (!shpState.Status.Equals("Delivered"))
            {
                using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Shipment not completed, waiting 5 Seconds. OrderId: " + order.OrderID.Value.ToString());
                }
                System.Threading.Thread.Sleep(5000);
                shpState = httpMachine.Shipmentget(order.OrderID.Value);
            }
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Shipment completed");
            }

            //DB schreiben
            con = new MySqlConnection("server=localhost; user id = root; database = shopdb; password =");
            con.Open();
            Query = ("update controller set ShipmentState = 1 where OrderId = " + order.OrderID.Value.ToString());
            MySqlCommand command4 = new MySqlCommand(Query, con);
            command4.ExecuteReader();
            con.Close();
            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Database Updated - ShipmentState");
            }

            using (StreamWriter sw = new StreamWriter(@"C:\temp\ShopStantly.log", true))
            {
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": _________________");
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": Request completed");
                sw.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + ": _________________");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
