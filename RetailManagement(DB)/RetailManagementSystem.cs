using Microsoft.EntityFrameworkCore;
using RetailManagement_DB_.Model;

namespace RetailManagement_DB_
{
    public class RetailManagementSystem
    {
        public readonly AppDbContext _db = new AppDbContext();

        #region choose option
        public void RetailSystem()
        {
            while (true)
            {
                Console.WriteLine("\nRetail System Menu: ");
                Console.WriteLine("1. Display All Product");
                Console.WriteLine("2. Add new Product");
                Console.WriteLine("3. Show Only one Product");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Doing Purchase ");
                Console.WriteLine("7. Show Sale Report ");
                Console.WriteLine("8. End Program ");
                Console.WriteLine("\nSelect a choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowProducts();
                        break;
                    case "2":
                        CreateProduct();
                        break;
                    case "3":
                        ShowProduct();
                        break;
                    case "4":
                        UpdateProduct();
                        break;
                    case "5":
                        DeleteProduct();
                        break;
                    case "6":
                        CreateSaleReport();
                        break;
                    case "7":
                        ShowSalereports();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again...");
                        break;
                }
            }
        }

        #endregion

        #region CreateProduct
        public void CreateProduct()
        {
            try
            {
                Console.WriteLine("Enter Product Name....");
                string pname = Console.ReadLine();
                Console.WriteLine("Enter Remaing_Stock");
                int stock = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Price of one amount of Product");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Profit of one amount of Product");
                int profit = Convert.ToInt32(Console.ReadLine());

                ProductModel product = new ProductModel
                {
                    ProductName = pname,
                    RemainingStock = stock,
                    ProductPrice = price,
                    ProductProfit = profit
                };
                _db.Add(product);
                var result = _db.SaveChanges();

                Console.WriteLine(result == 1 ? "Product Adding Successfully.." : "Product Adding Fail...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        #endregion

        #region ShowProduct
        public void ShowProduct()
        {
            try
            {
                Console.WriteLine("\nEnter Product ID....");
                string input = Console.ReadLine();

                if (Guid.TryParse(input, out Guid pid))
                {

                    Console.WriteLine($"Product Detail of ID: {pid}");

                    var lst = _db.Products.AsNoTracking().FirstOrDefault(p => p.ProductID == pid && p.ActiveFlag == true);
                    if (lst is not null)
                    {
                        Console.WriteLine("---------------------------");
                        Console.WriteLine($"\nProduct Name....{lst.ProductName}");
                        Console.WriteLine($"Remaining Stock....{lst.RemainingStock}");
                        Console.WriteLine($"Product Price....{lst.ProductPrice}");
                        Console.WriteLine($"Product Profit....{lst.ProductProfit}");
                        Console.WriteLine("---------------------------");

                    }
                    else
                    {
                        Console.WriteLine("This Product doesn't exist...");
                    }
                }

                else
                {
                    Console.WriteLine("Invalid Product ID. Please enter a valid GUID.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        #endregion

        #region Show AllProducts
        public void ShowProducts()
        {
            try
            {
                var lst = _db.Products.Where(p => p.ActiveFlag == true).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine($"\nProduct ID :  {item.ProductID}");
                    Console.WriteLine($"Product Name :  {item.ProductName}");
                    Console.WriteLine($"Remaining Stock :   {item.RemainingStock}");
                    Console.WriteLine($"Product Price : {item.ProductPrice}");
                    Console.WriteLine($"Product Profit....{item.ProductProfit}");
                    Console.WriteLine("---------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        #endregion

        #region UpdateProduct
        public void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Enter Product ID....");
                string input = Console.ReadLine();

                if (Guid.TryParse(input, out Guid pid))
                {

                    var item = _db.Products.FirstOrDefault(p => p.ProductID == pid);

                    if (item is null)
                    {
                        Console.WriteLine("No data found..");
                        return;
                    }

                    Console.WriteLine("Enter Product Name...");
                    string pname = Console.ReadLine();

                    if (pname is not null)
                    {
                        item.ProductName = pname;
                    }

                    Console.WriteLine("Enter Product Stock...");
                    string newStockInput = Console.ReadLine();
                    if (int.TryParse(newStockInput, out int newStock))
                    {
                        item.RemainingStock = newStock;
                    }

                    Console.WriteLine("Enter Price of one amount of Product....");
                    string newPriceInput = Console.ReadLine();
                    if (decimal.TryParse(newPriceInput, out decimal newPrice))
                    {
                        item.ProductPrice = newPrice;
                    }

                    Console.WriteLine("Enter Profit of one amount of Product....");
                    string newProfitInput = Console.ReadLine();

                    if (decimal.TryParse(newProfitInput, out decimal newProfit))
                    {
                        item.ProductProfit = newProfit;
                    }

                    _db.Entry(item).State = EntityState.Modified;
                    var result = _db.SaveChanges();

                    Console.WriteLine(result == 1 ? "Product details updated successfully...." : "Product details updated fail...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region DeleteProduct
        public void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter Product ID...");
                string input = Console.ReadLine();

                if (Guid.TryParse(input, out Guid pid))
                {

                    var item = _db.Products.FirstOrDefault(p => p.ProductID == pid);

                    if (item is null)
                    {
                        Console.WriteLine("No data found");
                        return;
                    }
                    item.ActiveFlag = false;
                    _db.Entry(item).State = EntityState.Modified;

                    var result = _db.SaveChanges();

                    Console.WriteLine(result == 1 ? "Deleting Successfully..." : "Deleting Fail...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region CreateSaleReport
        public void CreateSaleReport()
        {
            try
            {
                Console.WriteLine("Enter Product ID...");
                string input = Console.ReadLine();

                if (Guid.TryParse(input, out Guid pid))
                {

                    var item = _db.Products.FirstOrDefault(p => p.ProductID == pid);

                    if (item is not null)
                    {
                        Console.WriteLine($"Enter quantity for {item.ProductName} (Available At Least: {item.RemainingStock}):");
                        int qty = Convert.ToInt32(Console.ReadLine());

                        if (qty > 0 && qty <= item.RemainingStock)
                        {
                            decimal TotalCost = Convert.ToDecimal(item.ProductPrice * qty);
                            decimal Totalprofit = Convert.ToDecimal(item.ProductProfit * qty);

                            item.RemainingStock -= qty;

                            var saleReport = new SalereportModel
                            {
                                ProductID = pid,
                                QuantitySold = qty,
                                TotalPrice = TotalCost,
                                TotalProfit = Totalprofit,
                            };
                            _db.Add(saleReport);
                            _db.Entry(item).State = EntityState.Modified;
                            var result = _db.SaveChanges();

                            if (result != null)
                            {
                                Console.WriteLine("Purchasing Successfully..");
                            }
                            else
                            {
                                Console.WriteLine("Purchasing Fail...");
                            }

                            Console.WriteLine("---------------------------");
                            Console.WriteLine($"\nSales: {TotalCost}");
                            Console.WriteLine("---------------------------");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region ShowAllSaleReports
        public void ShowSalereports()
        {
            try
            {
                var lst = _db.Salereports.ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine($"\nProduct ID :  {item.ProductID}");
                    Console.WriteLine($"Quantity Sold :   {item.QuantitySold}");
                    Console.WriteLine($"Total Price : {item.TotalPrice}");
                    Console.WriteLine($"Total Profit....{item.TotalProfit}");
                    Console.WriteLine("---------------------------");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
