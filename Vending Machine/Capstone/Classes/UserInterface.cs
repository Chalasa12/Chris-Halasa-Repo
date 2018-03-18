using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class UserInterface
    {
        VendingMachine vendingMachine;

        public UserInterface(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }

        public void RunInterface()
        {
            IntroPic();
            while (true)
            {
                MainMenu();
            }

        }
        public void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");

            try
            {
                int menuChoice = int.Parse(Console.ReadLine());
                if (menuChoice == 1)
                {
                    Console.Clear();
                    Console.WriteLine();
                    string[] displayArray = vendingMachine.DisplayItems();
                    foreach (string item in displayArray)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (menuChoice == 2)
                {
                    PurchaseMenu();
                }
                if (menuChoice == 411)
                {
                    SalesReport();
                    Console.WriteLine("*****************************");
                    Console.WriteLine("Sales Report Printed");
                    Console.WriteLine("*****************************");
                }
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("*****************************");
                Console.WriteLine("Please Select A Menu Option.");
                Console.WriteLine("*****************************");
            }
        }

        public void PurchaseMenu()
        {
            bool menuActive = true;
            while (menuActive)
            {
                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                try
                {
                    int purchaseMenuChoice = int.Parse(Console.ReadLine());
                    if (purchaseMenuChoice == 1)
                    {
                        Console.WriteLine();
                        Console.Write("Please Insert Cash ($1, $2, $5, $10): $");
                        try
                        {
                            int inputMoney = int.Parse(Console.ReadLine());
                            if (inputMoney < 0)
                            {
                                Console.WriteLine("Balance Cannot Be Below $0.00"); // added if statement here to keep user from inputing negative money
                            }
                            else
                            {
                                vendingMachine.FeedMoney(inputMoney);
                                Console.WriteLine();
                                Console.WriteLine("Current Balance: $" + vendingMachine.CheckBalance());//changed to check balance because of bug with totalMoney variable
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("**********************************");
                            Console.WriteLine("Please Enter Whole Dollar Amount.");
                            Console.WriteLine("**********************************");
                        }
                    }
                    if (purchaseMenuChoice == 2)
                    {
                        string[] displayArray = vendingMachine.DisplayItems();
                        foreach (string item in displayArray)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        Console.Write("Please Select Product: ");

                        string inputProduct = Console.ReadLine();
                        inputProduct = inputProduct.ToUpper(); //allows user input to be case insensitive
                        int balance = vendingMachine.VendingBalance;
                        bool doesItemExist = vendingMachine.DoesItemExist(inputProduct);
                        bool isItemAvailable = vendingMachine.IsItemAvailable(inputProduct);//changed these to be in variables to make it cleaner
                        bool isEnoughMoney = vendingMachine.IsEnoughMoney(inputProduct, balance);

                        if (doesItemExist && isItemAvailable && isEnoughMoney)
                        {
                            Console.WriteLine();
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine(vendingMachine.DispenseItem(inputProduct));
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("Remaining Balance: $" + vendingMachine.CheckBalance());
                            Console.WriteLine();
                        }
                        else if (!doesItemExist)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Sorry That Item Doesn't Exist");
                        }
                        else if (!isItemAvailable)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Sorry That Item Is Out of Stock. Please Select Another Item");
                        }
                        else if (!isEnoughMoney)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Insuffienct Funds. Please Insert More $");
                        }

                    }
                    if (purchaseMenuChoice == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Your Change Is: $" + vendingMachine.CheckBalance());
                        int[] changeArray = vendingMachine.GiveChange();

                        Console.WriteLine("_________________________________");
                        menuActive = false;
                        System.Threading.Thread.Sleep(3000);
                    }
                    if (purchaseMenuChoice > 3)
                    {
                        Console.WriteLine("*****************************");
                        Console.WriteLine("Please Select A Menu Option.");
                        Console.WriteLine("*****************************");
                    }
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("*****************************");
                    Console.WriteLine("Please Select A Menu Option.");
                    Console.WriteLine("*****************************");
                }
            }
        }
        public void IntroPic()
        {
            Console.WriteLine("_____________________________________________");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|############################################|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|                           |##############|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  =====  ..--''`  |~~``|   |##|````````|##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  |   |  \\     |  :    |   |##| Exact  |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  |___|   /___ |  | ___|   |##| Change |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  /=__\\  ./.__\\   |/,__\\   |##| Only   |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  \\__//   \\__//    \\__//   |##|________|##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|===========================|##############|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|```````````````````````````|##############|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#| =.._      +++     //////  |##############|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#| \\/  \\     | |     \\   \\ \\ |#|`````````|##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  \\___\\    |_|     /___ /  |#| _______ |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  / __\\  /|_|\\   // __\\    |#| |1|2|3| |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  \\__//-  \\|_//   -\\__//   |#| |4|5|6| |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|===========================|#| |7|8|9| |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|```````````````````````````|#| ``````` |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#| ..--    ______   .--._.   |#|[=======]|##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#| \\   \\   |    |   |    |   |#|  _   _  |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  \\___\\  : ___:   | ___|   |#| ||| ( ) |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  / __\\  |/ __\\   // __\\   |#| |||  `  |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|  \\__//   \\__//  /_\\__//   |#|  ~      |##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|===========================|#|_________|##|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|```````````````````````````|##############|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|############################################|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#|||||||||||||||||||||||||||||####```````###|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|#||||||||||||PUSH|||||||||||||####\\|||||/###|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|############################################|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\////////////////////////////|");
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("|________________________________ | CR98 |___|");
        }

        public void SalesReport()
        {
            Console.WriteLine();
            string[] displayArray = vendingMachine.DisplaySalesReport();
            Logger logger = new Logger();
            logger.SalesReportLogger(displayArray, vendingMachine.TotalSales);
        }

    }
}
