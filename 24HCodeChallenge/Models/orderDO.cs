namespace _24HCodeChallenge.Models
{
    public class orderDO
    {
        public int order_id { get; set; }
        public DateOnly order_date {  get; set; }
        public TimeOnly order_time { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string JobPosition { get; set; }
    }
    public class order_detailsDO
    {
        public string order_id { get; set; }
        public string order_details { get; set; }
        public string pizza_id { get; set; }
        public string quantity { get; set; }

    }

}
