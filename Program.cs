using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using L1FEOutdoors.Forms;
using Square;
using Square.Exceptions;
using Square.Models;

namespace L1FEOutdoors
{
    internal static class Program
    {
        private static ISquareClient _client;

        [STAThread]
        static void Main()
        {
            _client = new SquareClient.Builder()
                .Environment(Square.Environment.Production)
                .AccessToken(Properties.Settings.Default.token)
                .Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormProvider.ModernMenu);
        }

        public class FormProvider
        {
            public static ModernMenu ModernMenu => _modernmenu ??= new ModernMenu();
            private static ModernMenu _modernmenu;
        }

        public static async Task<DataTable> RetrieveItemsAsync()
        {
            var data = new DataTable();
            data.Columns.Add("Item Name");
            data.Columns.Add("SKU");
            data.Columns.Add("Category");
            data.Columns.Add("Option Name 1");//Qty
            data.Columns.Add("Option Value 1");//Count

            var catData = new DataTable();
            catData.Columns.Add("ID");
            catData.Columns.Add("Name");


            try
            {
                
                var item = await _client.CatalogApi.ListCatalogAsync(types: "item");
                var category = await _client.CatalogApi.ListCatalogAsync(types: "category");
                var inventory = await RetrieveInventoryAsync();

                var cursor = item.Cursor;

                //Find all categories first
                foreach (var catalog in category.Objects)
                {
                    if (catalog.Type != "CATEGORY") continue;
                    
                    catData.Rows.Add(catalog.Id, catalog.CategoryData.Name);
                }

                //Go through all items
                foreach (var catalog in item.Objects)
                {
                    if (catalog.ItemData.Variations.Count <= 0) continue;

                    foreach (var variation in catalog.ItemData.Variations)
                    {
                        foreach (DataRow row in inventory.Rows)
                        {
                            if (!string.Equals((string) row[0], variation.Id)) continue;

                            foreach (DataRow catid in catData.Rows)
                            {
                                if(string.Equals((string)catid[0], catalog.ItemData.CategoryId))
                                    data.Rows.Add(catalog.ItemData.Name + " " + variation.ItemVariationData.Name,
                                        variation.ItemVariationData.Sku, (string)catid[1],row[1], "0");
                            }
                        }
                    }
                    
                }

                while (cursor != null)
                {
                    var item2 = await _client.CatalogApi.ListCatalogAsync(cursor: cursor, types: "item");

                    cursor = item2.Cursor;

                    foreach (var catalog in item2.Objects)
                    {
                        if (catalog.ItemData.Variations.Count <= 0) continue;
                        foreach (var variation in catalog.ItemData.Variations)
                        {
                            foreach (DataRow row in inventory.Rows)
                            {
                                if (!string.Equals((string)row[0], variation.Id)) continue;

                                foreach (DataRow catid in catData.Rows)
                                {
                                    if (string.Equals((string)catid[0], catalog.ItemData.CategoryId))
                                        data.Rows.Add(catalog.ItemData.Name + " " + variation.ItemVariationData.Name,
                                            variation.ItemVariationData.Sku, (string)catid[1], row[1], "0");
                                }
                            }
                        }
                    }
                }
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

            return data;
        }

        public static async Task<DataTable> RetrieveInventoryAsync()
        {
            var data = new DataTable();
            var locationIds = new List<string> { "AM8KMXKM977CD" };

            var body = new BatchRetrieveInventoryCountsRequest.Builder()
                .LocationIds(locationIds)
                .Build();

            var inventory = await _client.InventoryApi.BatchRetrieveInventoryCountsAsync(body: body);
            var cursor = inventory.Cursor;

            try
            {
                data.Columns.Add("ObjectID");
                data.Columns.Add("Quantity");

                foreach (var obj in inventory.Counts)
                {
                    data.Rows.Add(obj.CatalogObjectId, obj.Quantity);
                }

                while (cursor != null)
                {
                    var body2 = new BatchRetrieveInventoryCountsRequest.Builder()
                        .LocationIds(locationIds)
                        .Cursor(cursor)
                        .Build();
                    var inventory2 = await _client.InventoryApi.BatchRetrieveInventoryCountsAsync(body: body2);
                    cursor = inventory2.Cursor;

                    foreach (var obj in inventory2.Counts)
                    {
                        data.Rows.Add(obj.CatalogObjectId, obj.Quantity);
                    }

                }
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
                    Console.WriteLine(@"Error Category:{0} Code:{1} Detail:{2}", error.Category, error.Code,
                        error.Detail);
                    Debug.Print("Error Category:{0} Code:{1} Detail:{2}", error.Category, error.Code, error.Detail);
                }
            }
            return data;
        }

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
