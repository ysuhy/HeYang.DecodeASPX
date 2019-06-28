using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HeYang.DecodeASPX
{
    class Program
    {





        static void Main(string[] args)
        {
            DoAspx.Start();
            DoAspxCS.Start();
            DoStatileFile.Start();
            Console.WriteLine("done");

            Console.Read();

        }




    }
}
