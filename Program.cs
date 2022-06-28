using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using L1FEOutdoors.Forms;
using Square;
using Square.Exceptions;
using Square.Models;

namespace L1FEOutdoors
{
    internal class Program
    {
        private static ISquareClient _client;

        [STAThread]
        static void Main()
        {
            //Set Square Environment, Either Production Or Sandbox
            _client = new SquareClient.Builder()
                .Environment(Square.Environment.Production)
                .AccessToken(Properties.Settings.Default.token)
                .Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormProvider.ModernMenu); //Starting Form
        }

        //Make ModernMenu Singleton
        public class FormProvider
        {
            public static ModernMenu ModernMenu => _modernmenu ??= new ModernMenu();
            private static ModernMenu _modernmenu;
        }

        //Retrieve Items With Counts From Square
        public async Task<DataTable> RetrieveItemsAsync(IProgress<int> progress = null, Forms.BackgroundWorker backgroundWorker = null)
        {
            //Main Datatable To Return
            var data = new DataTable();
            data.Columns.Add("Item Name");
            data.Columns.Add("SKU");
            data.Columns.Add("Category");
            data.Columns.Add("Option Name 1");//Qty
            data.Columns.Add("Option Value 1");//Count

            //Square Catalog Data
            var catData = new DataTable();
            catData.Columns.Add("ID");
            catData.Columns.Add("Name");

            //Square Inventory Data
            var invData = new DataTable();
            invData.Columns.Add("ObjectID");
            invData.Columns.Add("Quantity");
            
            //Loading Bar Stuff
            var index = 0;
            double percentage = 0;
            var percentageInt = 0;
            
            try
            {
                backgroundWorker!.label1.Text = @"Getting Item Data...";
                //Get Square Catalog Items
                var item = await _client.CatalogApi.ListCatalogAsync(types: "item");
                //Set Catalog Item Cursor To Next Cursor
                string cursor = null;

                //Loading Bar Stuff
                index = 100;
                percentage = (double)index / 1500;
                percentage *= 100;
                percentageInt = (int)Math.Round(percentage, 0);
                progress.Report(percentageInt);
                
                backgroundWorker!.label1.Text = @"Getting Category Data...";

                //Get Square Catalog Categories
                var category = await _client.CatalogApi.ListCatalogAsync(types: "category");
                
                //Loading Bar Stuff
                index = 200;
                percentage = (double)index / 1500;
                percentage *= 100;
                percentageInt = (int)Math.Round(percentage, 0);
                progress.Report(percentageInt);
                
                backgroundWorker!.label1.Text = @"Getting Inventory Counts...";

                //Square Location ID's for Items
                var locationIds = new List<string> { "AM8KMXKM977CD" };//Main Location
                //Square Build Inventory Count Based On LocationIds
                var body = new BatchRetrieveInventoryCountsRequest.Builder()
                    .LocationIds(locationIds)
                    .Build();
                //Get Square Inventory Counts
                var inv = await _client.InventoryApi.BatchRetrieveInventoryCountsAsync(body: body);
                //Set Square Inventory Counts Cursor To Next Cursor
                string invCursor = null;

                //Loading Bar Stuff
                index = 300;
                percentage = (double)index / 1500;
                percentage *= 100;
                percentageInt = (int)Math.Round(percentage, 0);
                progress.Report(percentageInt);

                backgroundWorker!.label1.Text = @"Adding Categories To DataTable...";
                //Find all Square Categories First
                foreach (var catalog in category.Objects)
                {
                    if (catalog.Type != "CATEGORY") continue;
                    //Place Found Category ID & Name in catData DataTable
                    catData.Rows.Add(catalog.Id, catalog.CategoryData.Name);
                }

                backgroundWorker!.label1.Text = @"Adding Counts To DataTable...";

                //Square Item Counts
                do
                {
                    //Set Cursor
                    invCursor = inv.Cursor;

                    //Find All Square Items Counts
                    foreach (var obj in inv.Counts)
                    {
                        //Place ID and Quantity in invData DataTable
                        invData.Rows.Add(obj.CatalogObjectId, obj.Quantity);
                    }

                    //Set Data to Next Set of Items In Cursor.
                    body = new BatchRetrieveInventoryCountsRequest.Builder()
                        .LocationIds(locationIds)
                        .Cursor(invCursor)
                        .Build();
                    //Break Out If No More Items Exist
                    //if (invCursor == null) break;

                    //Set Next Cursor
                    inv = await _client.InventoryApi.BatchRetrieveInventoryCountsAsync(body: body);
                } while (invCursor != null);

                do
                {
                    backgroundWorker!.label1.Text = @"Combining DataTables...";

                    //Set cursor to next set of items
                    cursor = item.Cursor;

                    //Go Through All Square Items
                    foreach (var catalog in item.Objects)
                    {
                        //if (catalog.ItemData.Variations.Count <= 0) continue;

                        //Go Through Each Variation Of Each Item
                        foreach (var variation in catalog.ItemData.Variations)
                        {
                            //Start Searching In Inventory Count DataTable
                            foreach (DataRow row in invData.Rows)
                            {
                                //Find The Inventory Count ID That Matches The Variation ID
                                if (!string.Equals((string) row[0], variation.Id)) continue;
                                index++;
                                //Start Searching In Category DataTable
                                foreach (DataRow catid in catData.Rows)
                                {
                                    //Find The Category ID That Matches the Item Category ID
                                    if (string.Equals((string) catid[0], catalog.ItemData.CategoryId))
                                    {
                                        //Add All The Data Found To Main Data DataTable
                                        data.Rows.Add(catalog.ItemData.Name + " " + variation.ItemVariationData.Name,
                                            variation.ItemVariationData.Sku, (string) catid[1], row[1], "0");
                                    }

                                    //Update Progress Bar
                                    percentage = (double) index / 1500;
                                    percentage *= 100;
                                    percentageInt = (int) Math.Round(percentage, 0);
                                    progress.Report(percentageInt);
                                }
                            }
                        }
                    }
                    //If No More Items Exist Break
                    //if (cursor == null) break;

                    //Get Next Set Of Items
                    item = await _client.CatalogApi.ListCatalogAsync(cursor: cursor, types: "item");
                } while (cursor != null);
            }
            catch (ApiException e)
            {
                var errors = e.Errors;
                var statusCode = e.ResponseCode;
                var httpContext = e.HttpContext;
                Debug.Print("ApiException occurred:");
                Debug.Print("Headers:");
                Console.WriteLine(@"ApiException occurred:");
                Console.WriteLine(@"Headers:");
                foreach (var item in httpContext.Request.Headers.Where(item => item.Key != "Authorization"))
                {
                    Console.WriteLine(@"	{0}: 	{1}", item.Key, item.Value);
                    Debug.Print("\t{0}: \t{1}", item.Key, item.Value);
                }
                Console.WriteLine(@"Status Code: 	{0}", statusCode);
                foreach (var error in errors)
                {
                    Console.WriteLine(@"Error Category:{0} Code:{1} Detail:{2}", error.Category, error.Code, error.Detail);
                    Debug.Print("Error Category:{0} Code:{1} Detail:{2}", error.Category, error.Code, error.Detail);
                }

                // Your error handling code
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Exception occurred");
                Debug.Print("Exception: " + e);
                // Your error handling code
            }
            //Complete Loading Bar & Return Data
            progress.Report(100);
            backgroundWorker.label1.Text = @"Completed";
            backgroundWorker.Close();
            return data;
        }

        //Retrieve Square Payments
        public async Task<DataTable> RetriveOrdersAsync(string bTime, string eTime, IProgress<int> progress = null,
            BackgroundWorker backgroundWorker = null)
        {
            //Main Location
            var locationIds = new List<string> {"AM8KMXKM977CD"};

            var createdAt = new TimeRange.Builder()
                .StartAt(bTime)
                .EndAt(eTime)
                .Build();

            var dateTimeFilter = new SearchOrdersDateTimeFilter.Builder()
                .CreatedAt(createdAt)
                .Build();

            var filter = new SearchOrdersFilter.Builder()
                .DateTimeFilter(dateTimeFilter)
                .Build();

            var query = new SearchOrdersQuery.Builder()
                .Filter(filter)
                .Build();

            var body = new SearchOrdersRequest.Builder()
                .LocationIds(locationIds)
                .Query(query)
                .ReturnEntries(false)
                .Build();

            //Main Data
            var data = new DataTable();
            data.Columns.Add("Date");
            data.Columns.Add("Time");
            data.Columns.Add("State");
            data.Columns.Add("Amount");
            data.Columns.Add("Paid");
            data.Columns.Add("Note");

            //Loading Stuff
            var index = 0;
            double percentage = 0;
            int percentageInt = 0;

            backgroundWorker!.label1.Text = @"Getting Payments Data...";

            try
            {
                //Loading Stuff
                index = 100;
                percentage = (double)index / 1500;
                percentage *= 100;
                percentageInt = (int)Math.Round(percentage, 0);
                progress!.Report(percentageInt);

                //Get Orders From Square
                var orders = await _client.OrdersApi.SearchOrdersAsync(body: body);

                do
                {
                    //Get Each Order
                    foreach (var order in orders.Orders)
                    {
                        //Don't Show $0 Transactions
                        if(order.TotalMoney.Amount == 0) continue;
                        
                        //Change Date & Time To EST
                        var utcDateTime = DateTime.Parse(order.CreatedAt,
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.RoundtripKind);
                        var date = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime,
                            TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

                        string note = null;

                        if (order.LineItems != null)
                        {
                            note = order.LineItems[0].Note;
                        }
                        
                        //Add Order Details To DataTable
                        data.Rows.Add(date.ToString("MMMM dd, yyyy"), date.ToString("h:mm tt"), order.State,
                            "$" + order.TotalMoney.Amount / 100f, "$" + order.NetAmounts.TotalMoney.Amount / 100f, note);
                    }
                } while (orders.Cursor != null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            progress.Report(100);
            backgroundWorker.label1.Text = @"Completed";
            backgroundWorker.Close();
            return data;
        }

        //Check There's Internet Connection
        public static bool IsConnectedToInternet(int timeoutMs = 10000, string url = null)
        {
            try
            {
                url ??= CultureInfo.InstalledUICulture switch
                {
                    { Name: var n } when n.StartsWith("fa") => // Iran
                        "http://squareup.com",
                    { Name: var n } when n.StartsWith("zh") => // China
                        "http://squareup.com",
                    _ =>
                        "http://squareup.com",
                };

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
                throw;
            }
        }
        
    }

}
