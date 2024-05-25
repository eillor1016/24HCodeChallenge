using _24HCodeChallenge.DAL___Data_Access_Layer;
using _24HCodeChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System.Data;

namespace _24HCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        ProcessDAL processDAL = new ProcessDAL();

        [HttpPost("upload-order-csv_data")]
        public async Task<IActionResult> UploadOrdersCSV([FromForm] IFormFileCollection file)
        {
            try
            {
                responseDO response = new responseDO();
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
                Task<responseDO> taskResult = Task.Run(async () => await processDAL.saveOrders_toDB(dt));
                response = taskResult.Result;
                
                return Json(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("upload-order_details-csv_data")]
        public async Task<IActionResult> UploadOrderDetailCSV([FromForm] IFormFileCollection file)
        {
            try
            {
                responseDO response = new responseDO();
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
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("upload-pizza_details-csvd_ata")]
        public async Task<IActionResult> UploadPizzaDetailCSV([FromForm] IFormFileCollection file)
        {
            try
            {
                responseDO response = new responseDO();
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
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("upload-pizza-type-csv_data")]
        public async Task<IActionResult> UploadPizzaTypeCSV([FromForm] IFormFileCollection file)
        {
            try
            {
                responseDO response = new responseDO();
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
                return BadRequest(ex.Message);
            }
        }

    }
}
