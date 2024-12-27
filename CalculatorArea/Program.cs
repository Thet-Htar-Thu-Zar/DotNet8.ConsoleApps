class Area
{
    static void Main(string[] args)
    {
        try
        {
            double Area = 0;

            Console.WriteLine("Please enter width...");
            double width = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter height...");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Area: {width * height}");
            //Area = width * height;
            //Console.WriteLine($"Area: {Area.ToString("F2")}");
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
