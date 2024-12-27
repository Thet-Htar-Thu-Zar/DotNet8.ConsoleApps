namespace RetailManagement
{
    public class Product
    {
        public string ProductID { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int RemainingStock { get; set; }
        public double ProductPrice { get; set; }
        public double ProductProfit { get; set; }
       
    }

    public class SaleReports
    {
        public string ProductID { get; set; } = null!;
        public int QuantitySold { get; set; }
        public double TotalPrice { get; set; }
        public double TotalProfit { get; set; }
    }
}
