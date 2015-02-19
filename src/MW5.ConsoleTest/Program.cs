using System;

namespace MW5.ConsoleTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Tests.TestLabels();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Exception occured: " + ex.Message);
            }
            System.Console.ReadLine();
        }
    }
}
