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
        int rowcount = 0;
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
                        rowcount = s.RowsCopied;
                        response.Status = "Success";
                        response.Message = "Successfully Uploaded in Database with total Count of " + rowcount;
                        response.Code = "200";
                    }
                    catch (Exception ex)
                    {
                        response.Status = "Bad Request";
                        response.Code = "400";
                        response.Message = ex.Message;
                    }
                }
                connection.Close();
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
                        rowcount = s.RowsCopied;
                        response.Status = "Success";
                        response.Message = "Successfully Uploaded in Database with total Count of " + rowcount;
                        response.Code = "200";
                    }
                    catch (Exception ex)
                    {
                        response.Status = "Bad Request";
                        response.Code = "400";
                        response.Message = ex.Message;
                    }
                }
                connection.Close();
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
                        rowcount = s.RowsCopied;
                        response.Status = "Success";
                        response.Message = "Successfully Uploaded in Database with total Count of " + rowcount;
                        response.Code = "200";
                    }
                    catch (Exception ex)
                    {
                        response.Status = "Bad Request";
                        response.Code = "400";
                        response.Message = ex.Message;
                    }
                }
                connection.Close();
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
                        rowcount = s.RowsCopied;
                        response.Status = "Success";
                        response.Message = "Successfully Uploaded in Database with total Count of " + rowcount;
                        response.Code = "200";
                    }
                    catch (Exception ex)
                    {
                        response.Status = "Bad Request";
                        response.Code = "400";
                        response.Message = ex.Message;
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                response.Status = "Bad Request";
                response.Code = "400";
                response.Message = ex.Message;
            }
            return response;

        }

        //getOrder details to Database
        public async Task<orderPizza> GetOrder(orderPizza data)
        {
            orderPizza orderPizza = new orderPizza();
            try
            {
                DataTable dt = new DataTable(); 
                connection = Connect();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
                sqlcmd = new SqlCommand("sp_getOrder", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@ID", data.order_id);
                dt.Load(sqlcmd.ExecuteReader());
                if (dt.Rows.Count>0)
                {
                    foreach(DataRow row in dt.Rows)
                    {

                 
                        orderPizza.order_id =Convert.ToInt32(row["order_id"]);
                        orderPizza.date =Convert.ToDateTime(row["date"]).ToString("MM/dd/yyyy");
                        orderPizza.time = row["time"].ToString();
                        orderPizza.pizza_id = row["pizza_id"].ToString();
                        orderPizza.pizza_type = row["pizza_type_id"].ToString();
                        orderPizza.quantity = row["quantity"].ToString();
                        orderPizza.size = row["size"].ToString();
                        orderPizza.price = row["price"].ToString();
                        orderPizza.name = row["name"].ToString();
                        orderPizza.category = row["category"].ToString();
                        orderPizza.ingredients = row["ingredients"].ToString();

                    }
                }
                return orderPizza;
                connection.Close();
            }
            catch(Exception ex)
            {
                return orderPizza;
            }
        }


        //getOrder details to Database
        public async Task<ListOfOrderReportByDate> ListOfOrderByDate(string dateFrom,string dateTo)
        {
            ListOfOrderReportByDate pizzaOrders = new ListOfOrderReportByDate();
            pizzaOrders.report = new List<orderPizza>();

            try
            {
                DataTable dt = new DataTable();
                connection = Connect();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
                sqlcmd = new SqlCommand("sp_getListofOrderbyDate", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                sqlcmd.Parameters.AddWithValue("@DateTo", dateTo);
                dt.Load(sqlcmd.ExecuteReader());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        orderPizza orderPizza = new orderPizza();
                        orderPizza.order_id = Convert.ToInt32(row["order_id"]);
                        orderPizza.date = Convert.ToDateTime(row["date"]).ToString("MM/dd/yyyy");
                        orderPizza.time = row["time"].ToString();
                        orderPizza.pizza_id = row["pizza_id"].ToString();
                        orderPizza.pizza_type = row["pizza_type_id"].ToString();
                        orderPizza.quantity = row["quantity"].ToString();
                        orderPizza.size = row["size"].ToString();
                        orderPizza.price = row["price"].ToString();
                        orderPizza.name = row["name"].ToString();
                        orderPizza.category = row["category"].ToString();
                        orderPizza.ingredients = row["ingredients"].ToString();

                        
                        pizzaOrders.report.Add(orderPizza);
                    }
                }
                return pizzaOrders;
                connection.Close();
            }
            catch (Exception ex)
            {
                return pizzaOrders;
            }
        }


        public async Task<List<TotalSaleReport>> GetTotalSales(string dateFrom, string dateTo)
        {
            List<TotalSaleReport> salesReport = new List<TotalSaleReport>();

            try
            {
                DataTable dt = new DataTable();
                connection = Connect();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Open();
                sqlcmd = new SqlCommand("sp_getSalesReportByDate", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                sqlcmd.Parameters.AddWithValue("@DateTo", dateTo);
                dt.Load(sqlcmd.ExecuteReader());
                if (dt.Rows.Count > 0)
                {
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        TotalSaleReport A = new TotalSaleReport();
                        A.pizzaName = row["name"].ToString();
                        A.category = row["category"].ToString();
                        A.size = row["size"].ToString();
                        A.price = row["price"].ToString();
                        A.totalOrder = row["TotalOrder"].ToString();
                        A.totalSales = row["TotalSales"].ToString();
                        salesReport.Add(A);
                    }
                }
                return salesReport;
                connection.Close();
            }
            catch (Exception ex)
            {
                return salesReport;
            }
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
