namespace _24HCodeChallenge.Models
{
    public class responseDO
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public successDetailDO success {  get; set; }
        public failDetailDO fail { get; set; }
    }

    public class successDetailDO
    {
        public int count {  get; set; }

    }
    public class failDetailDO
    {
        public int count { get; set; }

    }
}
