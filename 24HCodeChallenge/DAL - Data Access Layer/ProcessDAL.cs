using _24HCodeChallenge.Models;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Data.SqlClient;

namespace _24HCodeChallenge.DAL___Data_Access_Layer
{
    public class ProcessDAL:IDisposable
    {
        private bool disposedValue;
        SqlConnection connection = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();

        //DB Connection Class
        private SqlConnection Connect()
        {
            SqlConnection returnValue = default(SqlConnection);
            returnValue = new SqlConnection();
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
                IConfiguration configuration = builder.Build();
                string conn = configuration.GetConnectionString("DefaultConnection").ToString();

                returnValue.ConnectionString = conn;
            }
            catch (Exception ex)
            { throw; }
            return returnValue;
        }

        //saving of orders.csv to database
        public async Task<responseDO> saveOrders_toDB(DataTable data)
        {
            responseDO response = new responseDO();
            try
            {
                
                connection = Connect();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(connection))
                {
                    s.DestinationTableName = "tbl_order";
                    foreach (var column in data.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    try
                    {
                        s.WriteToServer(data);
                        response.Status = "Success";
                        response.Message = "Successfully Uploaded in Database";
                        response.Code = "200";
                    }
                    catch (Exception ex)
                    {
                        response.Status = "Bad Request";
                        response.Code = "400";
                        response.Message = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = "Bad Request";
                response.Code = "400";
                response.Message = ex.Message;
            }
            return response;

        }

        //saving of ordersdetails.csv to database
        public async Task<responseDO> saveOrders_detail_toDB(DataTable data)
        {
            responseDO response = new responseDO();
            try
            {
                
                connection = Connect();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(connection))
                {
                    s.DestinationTableName = "tbl_orderDetails";
                    foreach (var column in data.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    try
                    {
                        s.WriteToServer(data);
                        response.Status = "Success";
                        response.Message = "Successfully Uploaded in Database";
                        response.Code = "200";
                    }
                    catch (Exception ex)
                    {
                        response.Status = "Bad Request";
                        response.Code = "400";
                        response.Message = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = "Bad Request";
                response.Code = "400";
                response.Message = ex.Message;
            }
            return response;
        }

        //saving of pizzadetail.csv to database
        public async Task<responseDO> savePizza_detail_toDB(DataTable data)
        {
            responseDO response = new responseDO();
            try
            {
                
                connection = Connect();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(connection))
                {
                    s.DestinationTableName = "tbl_pizza_details";
                    foreach (var column in data.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    try
                    {
                        s.WriteToServer(data);
                        response.Status = "Success";
                        response.Message = "Successfully Uploaded in Database";
                        response.Code = "200";
                    }
                    catch (Exception ex)
                    {
                        response.Status = "Bad Request";
                        response.Code = "400";
                        response.Message = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = "Bad Request";
                response.Code = "400";
                response.Message = ex.Message;
            }
            return response;
        }

        //saving of pizzatype.csv to database
        public async Task<responseDO> savepizzaType_toDB(DataTable data)
        {
            responseDO response = new responseDO();
            try
            {
                connection = Connect();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(connection))
                {
                    s.DestinationTableName = "tbl_pizza_type";
                    foreach (var column in data.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    try
                    {
                        s.WriteToServer(data);
                        response.Status = "Success";
                        response.Message = "Successfully Uploaded in Database";
                        response.Code = "200";
                    }
                    catch (Exception ex)
                    {
                        response.Status = "Bad Request";
                        response.Code = "400";
                        response.Message = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = "Bad Request";
                response.Code = "400";
                response.Message = ex.Message;
            }
            return response;

        }



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ProcessDAL()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
