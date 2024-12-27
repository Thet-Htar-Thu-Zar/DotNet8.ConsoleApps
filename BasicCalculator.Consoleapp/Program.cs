class ConsoleApp
{
    static void Main(string[] args)
    {
        while(true) 
        { 
            try
            {
                #region enter firsNum, operator, secondNum

                Console.WriteLine("Please Enter first num:");
                int firstNum = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please Enter operator(+, -, *, /, %):");
                string Inputoperator = Console.ReadLine();

                Console.WriteLine("Please Enter second num:");
                int secondNum = Convert.ToInt32(Console.ReadLine());

                #endregion

                #region add

                if (Inputoperator == "+")
                {
                    Console.WriteLine("result: " + (firstNum + secondNum));
                }

                #endregion

                #region abstract

                else if (Inputoperator == "-")
                {
                    if (firstNum < secondNum)
                    {
                        Console.WriteLine("First num is less than second num");
                    }

                    else
                    {
                        Console.WriteLine("result: " + (firstNum - secondNum));
                    }
                }

                #endregion

                #region multiple

                else if (Inputoperator == "*")
                {
                    Console.WriteLine("result: " + (firstNum * secondNum));
                }

                #endregion

                #region division

                else if (Inputoperator == "/")
                {
                    Console.WriteLine("result: " + (firstNum / secondNum));
                }
                #endregion

                #region modulus

                else if (Inputoperator == "%")
                {
                    Console.WriteLine("result: " + (firstNum % secondNum));
                }
                #endregion

                else
                {
                    Console.WriteLine("Invalid Operator....Pls enter +, -, *, %, /");
                }

                Console.WriteLine("Do you want to continue..Please write y or n");
                string continueInput = Console.ReadLine();
                if(continueInput != "y" && continueInput != "Y") 
                {
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
};