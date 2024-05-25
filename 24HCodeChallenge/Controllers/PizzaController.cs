using _24HCodeChallenge.DAL___Data_Access_Layer;
using _24HCodeChallenge.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Data;

namespace _24HCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : Controller
    {
        ProcessDAL processDAL = new ProcessDAL();


        //start function of uploading of csv files to DB//
        [HttpPost("upload-order-csv_data")]
        public async Task<IActionResult> UploadOrdersCSV([FromForm] IFormFileCollection file)
        {
            responseDO response = new responseDO();
            try
            {
                
                DataTable dt = new DataTable();
                orderDO orderdO = new orderDO();
                //convert file in order to parse and convert to datatable
                var reader = new StreamReader(file[0].OpenReadStream());
                using (TextFieldParser csvReader = new TextFieldParser(reader))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        dt.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        dt.Rows.Add(fieldData);
                        
                    }
                }
                //saving to the database 
                Task<responseDO> taskResult = Task.Run(async () => await processDAL.saveOrders_toDB(dt));
                response = taskResult.Result;
                
                return Json(response);
            }
            catch (Exception ex)
            {
                response.Status = "Bad Request";
                response.Code = "400";
                response.Message = "Invalid File Format";
                return Json(response);
            }
        }

        [HttpPost("upload-order_details-csv_data")]
        public async Task<IActionResult> UploadOrderDetailCSV([FromForm] IFormFileCollection file)
        {
            responseDO response = new responseDO();
            try
            {
                
                DataTable dt = new DataTable();
                //convert file in order to parse and convert to datatable
                var reader = new StreamReader(file[0].OpenReadStream());
                using (TextFieldParser csvReader = new TextFieldParser(reader))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        dt.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        dt.Rows.Add(fieldData);
                    }
                }
                //saving to the database 
                Task<responseDO> taskResult = Task.Run(async () => await processDAL.saveOrders_detail_toDB(dt));
                response = taskResult.Result;

                return Json(response);
            }
            catch (Exception ex)
            {
                response.Status = "Bad Request";
                response.Code = "400";
                response.Message = "Invalid File Format";
                return Json(response);
            }
        }

        [HttpPost("upload-pizza_details-csvd_ata")]
        public async Task<IActionResult> UploadPizzaDetailCSV([FromForm] IFormFileCollection file)
        {
            responseDO response = new responseDO();
            try
            {
                
                DataTable dt = new DataTable();
                //convert file in order to parse and convert to datatable
                var reader = new StreamReader(file[0].OpenReadStream());
                using (TextFieldParser csvReader = new TextFieldParser(reader))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        dt.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }           
                        }
                        dt.Rows.Add(fieldData);
                    }
                }
                //saving to the database 
                Task<responseDO> taskResult = Task.Run(async () => await processDAL.savePizza_detail_toDB(dt));
                response = taskResult.Result;

                return Json(response);
            }
            catch (Exception ex)
            {
                response.Status = "Bad Request";
                response.Code = "400";
                response.Message = "Invalid File Format";
                return Json(response);
            }
        }

        [HttpPost("upload-pizza-type-csv_data")]
        public async Task<IActionResult> UploadPizzaTypeCSV([FromForm] IFormFileCollection file)
        {
            responseDO response = new responseDO();
            try
            {
                
                DataTable dt = new DataTable();
                //convert file in order to parse and convert to datatable
                var reader = new StreamReader(file[0].OpenReadStream());
                using (TextFieldParser csvReader = new TextFieldParser(reader))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        dt.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        dt.Rows.Add(fieldData);
                    }
                }
                //saving to the database 
                Task<responseDO> taskResult = Task.Run(async () => await processDAL.savepizzaType_toDB(dt));
                response = taskResult.Result;

                return Json(response);
            }
            catch (Exception ex)
            {
                response.Status = "Bad Request";
                response.Code = "400";
                response.Message = "Invalid File Format";
                return Json(response);
            }
        }
        //end function of uploading of csv files to DB//


        //API for getting the order Details
        [HttpPost("get_order_details")]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                orderPizza orderPizza = new orderPizza();
                orderPizza.order_id = id;
                Task<orderPizza> orderResult = Task.Run(async () => await processDAL.GetOrder(orderPizza));
                orderPizza = orderResult.Result;

                return Json(orderPizza);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //API for getting the reports
        [HttpPost("get_listOfOrders_pizza")]
        public async Task<IActionResult> ListOfOrderByDate(string datefrom,string dateto)
        {
            try
            {
                ListOfOrderReportByDate orderPizza = new ListOfOrderReportByDate();
                Task<ListOfOrderReportByDate> orderResult = Task.Run(async () => await processDAL.ListOfOrderByDate(datefrom, dateto));
                orderPizza = orderResult.Result;
                return Json(orderPizza);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //getTotalSalesreport
        [HttpPost("get_TotalSales")]
        public async Task<IActionResult> GetTotalSales(string datefrom, string dateto)
        {
            try
            {
                List<TotalSaleReport> salesReport = new List<TotalSaleReport>();
                Task<List<TotalSaleReport>> orderResult = Task.Run(async () => await processDAL.GetTotalSales(datefrom, dateto));
                salesReport = orderResult.Result;
                return Json(salesReport);

            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }

    }
}
