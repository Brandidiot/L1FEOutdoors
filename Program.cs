﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public async Task<DataTable> RetrieveItemsAsync(IProgress<int> progress = null, Forms.BackgroundWorker backgroundWorker = null)
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

            var invData = new DataTable();
            invData.Columns.Add("ObjectID");
            invData.Columns.Add("Quantity");
            
            var index = 0;
            double percentage = 0;
            int percentageInt = 0;
            
            try
            {
                backgroundWorker!.label1.Text = @"Getting Item Data...";
                var item = await _client.CatalogApi.ListCatalogAsync(types: "item");
                var cursor = item.Cursor;

                index = 100;
                percentage = (double)index / 1500;
                percentage *= 100;
                percentageInt = (int)Math.Round(percentage, 0);
                progress.Report(percentageInt);
                
                backgroundWorker!.label1.Text = @"Getting Category Data...";
                var category = await _client.CatalogApi.ListCatalogAsync(types: "category");
                
                index = 200;
                percentage = (double)index / 1500;
                percentage *= 100;
                percentageInt = (int)Math.Round(percentage, 0);
                progress.Report(percentageInt);
                
                backgroundWorker!.label1.Text = @"Getting Inventory Counts...";
                var locationIds = new List<string> { "AM8KMXKM977CD" };
                var body = new BatchRetrieveInventoryCountsRequest.Builder()
                    .LocationIds(locationIds)
                    .Build();
                var inv = await _client.InventoryApi.BatchRetrieveInventoryCountsAsync(body: body);
                var invCursor = inv.Cursor;

                index = 300;
                percentage = (double)index / 1500;
                percentage *= 100;
                percentageInt = (int)Math.Round(percentage, 0);
                progress.Report(percentageInt);

                backgroundWorker!.label1.Text = @"Adding Categories To DataTable...";
                //Find all categories first
                foreach (var catalog in category.Objects)
                {
                    if (catalog.Type != "CATEGORY") continue;

                    catData.Rows.Add(catalog.Id, catalog.CategoryData.Name);
                }

                backgroundWorker!.label1.Text = @"Adding Counts To DataTable...";
                while (invCursor != null)
                {
                    foreach (var obj in inv.Counts)
                    {
                        invData.Rows.Add(obj.CatalogObjectId, obj.Quantity);
                    }
                    //Set cursor to next set of items.
                    body = new BatchRetrieveInventoryCountsRequest.Builder()
                        .LocationIds(locationIds)
                        .Cursor(invCursor)
                        .Build();
                    inv = await _client.InventoryApi.BatchRetrieveInventoryCountsAsync(body: body);
                    invCursor = inv.Cursor;
                }

                while (cursor != null)
                {
                    backgroundWorker!.label1.Text = @"Combining DataTables...";
                    //Go through all items
                    foreach (var catalog in item.Objects)
                    {
                        if (catalog.ItemData.Variations.Count <= 0) continue;

                        foreach (var variation in catalog.ItemData.Variations)
                        {
                            foreach (DataRow row in invData.Rows)
                            {
                                if (!string.Equals((string) row[0], variation.Id)) continue;
                                index++;
                                foreach (DataRow catid in catData.Rows)
                                {
                                    if (string.Equals((string) catid[0], catalog.ItemData.CategoryId))
                                        data.Rows.Add(catalog.ItemData.Name + " " + variation.ItemVariationData.Name,
                                            variation.ItemVariationData.Sku, (string) catid[1], row[1], "0");
                                    
                                    //Update Progress Bar
                                    percentage = (double)index / 1500;
                                    percentage *= 100;
                                    percentageInt = (int)Math.Round(percentage, 0);
                                    progress.Report(percentageInt);
                                }
                            }
                        }
                    }
                    //Set cursor to next set of items.
                    item = await _client.CatalogApi.ListCatalogAsync(cursor: cursor, types: "item");
                    cursor = item.Cursor;
                    
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
            progress.Report(100);
            backgroundWorker.label1.Text = @"Completed";
            backgroundWorker.Close();
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
