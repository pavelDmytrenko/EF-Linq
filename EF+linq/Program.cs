using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            DBOperation dBOperation = new DBOperation();
            var resItem = dBOperation.SelectItem(Convert.ToDateTime(DateTime.Today.AddMonths(-1)));
            foreach (var res in resItem)
            {
                Console.WriteLine(res.UserId + "  " + res.Name + " " + res.Count);
            }
            Console.Read();
        }
    }
}
