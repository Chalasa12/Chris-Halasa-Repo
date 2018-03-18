using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class Logger
    {
        private string logPath = Path.Combine(Environment.CurrentDirectory, "Vending_Machine_Log.txt");
        private string salesPath = Path.Combine(Environment.CurrentDirectory, "Sales_Report.txt");

        public void FeedMoneyLogger(int inputMoney, string vendingBalance)
        {
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine($"{DateTime.Now} FEED MONEY: \t{inputMoney.ToString("C2")}\t${vendingBalance}");
            }
        }

        public void DispenseItemLogger(string dollarAmount, string vendingBalance, Item item)
        {
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine($"{DateTime.Now} {item.Description} {item.Slot}\t${dollarAmount}\t${vendingBalance}");
            }
        }

        public void GiveChangeLogger(string beforeBalance, string vendingBalance)
        {
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine($"{DateTime.Now} GIVE CHANGE: \t${beforeBalance}\t${vendingBalance}");
            }
        }

        public void SalesReportLogger(string[] displayArray, double totalSales)
        {
            foreach (string itemString in displayArray)
            {
                using (StreamWriter sw = new StreamWriter(salesPath, true))
                {
                    sw.WriteLine(itemString);
                }
            }
            using (StreamWriter sw = new StreamWriter(salesPath, true))
            {
                sw.WriteLine($"**Total Sales** {totalSales.ToString("C2")}.  Report run:  {DateTime.Now}\n\n");
                sw.WriteLine("-------------------------------------------------------------------------");
            }
        }
    }
}


