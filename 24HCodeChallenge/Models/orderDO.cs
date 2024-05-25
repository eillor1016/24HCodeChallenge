namespace _24HCodeChallenge.Models
{
    public class orderDO
    {
        public int id { get; set; }
        public string date {  get; set; }
        public string time { get; set; }
        //public order_detailsDO details { get; set; }

    }
 
   

    public class orderPizza
    {
        public int order_id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string pizza_id { get; set; }
        public string pizza_type { get; set; }
        public string quantity { get; set; }
        public string size { get; set; }
        public string price { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string ingredients { get; set; }


    }

    public class ListOfOrderReportByDate
    {
      public  List<orderPizza> report { get; set; }
    }

    public class TotalSaleReport
    {
        public string pizzaName { get; set; }
        public string category { get; set; }
        public string size { get; set; }
        public string price { get; set; }
        public string totalOrder { get; set; }
        public string totalSales { get; set; }
    }
}
