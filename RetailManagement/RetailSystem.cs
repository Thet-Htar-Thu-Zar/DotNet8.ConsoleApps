using System.Diagnostics.CodeAnalysis;

namespace RetailManagement
{
    public class RetailSystem
    {
        static List<Product> inventory = new List<Product>
        {
            new Product { ProductID = "P001", ProductName = "Mouse", RemainingStock = 10, ProductPrice = 23000.00, ProductProfit = 400.00 },
            new Product { ProductID = "P002", ProductName = "Keyboard", RemainingStock = 20, ProductPrice = 50000.00, ProductProfit = 500.00 },
            new Product { ProductID = "P003", ProductName = "Adapter", RemainingStock = 30, ProductPrice = 23000.00, ProductProfit = 600.00 },
            new Product { ProductID = "P004", ProductName = "Airpods", RemainingStock = 50, ProductPrice = 60000.00, ProductProfit = 1000.00 },
            new Product { ProductID = "P005", ProductName = "MousePad", RemainingStock = 80, ProductPrice = 5000.00, ProductProfit = 400.00 }

        };
       private static List<SaleReports> saleReports = new List<SaleReports> { };

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to Retail management applicaion..");
                Console.WriteLine("\nChoose Option what you wanna do!");
                Console.WriteLine("1. Stock Menu");
                Console.WriteLine("2. Cashier Menu");
                Console.WriteLine("3. Manager Menu");
                Console.WriteLine("4. Exit");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        StockMenu();
                        break;
                    case "2":
                        CashierMenu();
                        break;
                    case "3":
                        ManagerMenu();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again...");
                        break;

                }
            }
        }

        #region StockMenu
        private void StockMenu()
        {
            while (true)
            {
                Console.WriteLine("\nStock Menu: ");
                Console.WriteLine("1. Display Inventory");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Modify Product");
                Console.WriteLine("4. Go to Main Menu");
                Console.WriteLine("Select a choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        displayRetail();
                        break;
                    case "2":
                        addProduct();
                        break;
                    case "3":
                        modifyProduct();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again...");
                        break;
                }
            }
        }
        private void displayRetail()
        {
            try
            { 
                if(inventory.Count > 0)
                {
                    Console.WriteLine("\nInventory");
                    foreach (var product in inventory)
                    {
                        Console.WriteLine("Product Details:");
                        Console.WriteLine($"  ID: {product.ProductID}");
                        Console.WriteLine($"  Name: {product.ProductName}");
                        Console.WriteLine($"  Stock: {product.RemainingStock}");
                        Console.WriteLine($"  Price: {product.ProductPrice:C}");
                        Console.WriteLine($"  Profit: {product.ProductProfit:C}");
                        Console.WriteLine(new string('-', 40));
                    }
                    Run();
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void addProduct()
        {
            try
            {
                Console.WriteLine("\nEnter Product_Id: ");
                string productId = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Enter Product_Name: ");
                string productName = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Enter Remaining_Stock");
                int remainingStock = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Product_Price");
                double productPrice = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter Product_Profit");
                double prouductProfit = Convert.ToDouble(Console.ReadLine());

                inventory.Add(new Product
                {
                    ProductID = productId,
                    ProductName = productName,
                    RemainingStock = remainingStock,
                    ProductPrice = productPrice,
                    ProductProfit = prouductProfit
                });

                Console.WriteLine("Product Add Successfully...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void modifyProduct()
        {
            try
            {
                Console.WriteLine("\n Enter Product ID to modify: ");
                string productId = Console.ReadLine();
                var product = inventory.FirstOrDefault(p => p.ProductID == productId);

                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                }

                Console.Write("Enter new Product name ... ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    product.ProductName = newName;
                }

                Console.Write("Enter new remaining stock of product ...");
                string newStockInput = Console.ReadLine();
                if (int.TryParse(newStockInput, out int newStock))
                {
                    product.RemainingStock = newStock;
                }

                Console.Write("Enter new price of product... ");
                string newPriceInput = Console.ReadLine();
                if (double.TryParse(newPriceInput, out double newPrice))
                {
                    product.ProductPrice = newPrice;
                }

                Console.Write("Enter new profit per item (leave blank to keep current): ");
                string newProfitInput = Console.ReadLine();
                if (double.TryParse(newProfitInput, out double newProfit))
                {
                    product.ProductProfit = newProfit;
                }

                Console.WriteLine("Product details updated successfully.");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        #endregion

        #region CashierMenu
        private void CashierMenu()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("\nCashier Menu: ");
                    Console.WriteLine("Do Order...");

                    Console.WriteLine("\nEnter Product ID :");
                    string input = Console.ReadLine();

                    var product = inventory.FirstOrDefault(p => p.ProductID == input);
                    if (product != null)
                    {
                        Console.WriteLine($"Enter quantity for {product.ProductName} (Available At Least: {product.RemainingStock}):");
                        int qty = Convert.ToInt32(Console.ReadLine());

                            if (qty > 0 && qty <= product.RemainingStock)
                            {
                                double TotalCost = product.ProductPrice * qty;
                                double Totalprofit = product.ProductProfit * qty;

                                product.RemainingStock -= qty;

                            var saleReport = new SaleReports
                            {
                                ProductID = input,
                                QuantitySold = qty,
                                TotalPrice = TotalCost,
                                TotalProfit = Totalprofit,
                            };
                            saleReports.Add(saleReport);

                            Console.WriteLine($"Sales: {TotalCost}");
                            Run();
                        }
                        else
                            {
                                Console.WriteLine("Invalid quantity. Please try again.");
                            }   
                    }
                    else
                    {
                        Console.WriteLine("Invalid Product ID. Please try again.");
                    }

                }
              
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region ManageMenu
        private void ManagerMenu()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("\nManager Menu: ");
                    Console.WriteLine("1. View Sales Reports");
                    Console.WriteLine("2. View Totals");
                    Console.WriteLine("3. Go to Main Menu");
                    Console.WriteLine("Select a choice:");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ViewSalesReports();
                            break;
                        case "2":
                            ViewTotals();
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again...");
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void ViewSalesReports()
        {
            try
            {

                if (saleReports.Count == 0)
                {
                    Console.WriteLine("No sale report..");
                }
                else
                {
                    Console.WriteLine("\n Sale Reports..");

                    Console.WriteLine("| Product ID | Quantity Sold          | TotalPrice | TotalProfit | ");

                    foreach (var report in saleReports)
                    {
                        Console.WriteLine($"| {report.ProductID,-10} | {report.QuantitySold,-20} | {report.TotalPrice,-13} | {report.TotalProfit,-12:C} | ");
                    }
                }
              
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ViewTotals()
        {
            try
            {
                double totalRevenue = saleReports.Sum(s => s.TotalPrice);
                double totalProfit = saleReports.Sum(s => s.TotalProfit);

                Console.WriteLine("\nSummary of Totals:");
                Console.WriteLine($"Total Revenue: {totalRevenue:C}");
                Console.WriteLine($"Total Profit: {totalProfit:C}");
            }
            catch
            {

            }
        }
    }
    #endregion
}


