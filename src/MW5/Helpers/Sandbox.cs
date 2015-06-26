using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Helpers
{
    public static class Sandbox
    {
        public static void TestLogger()
        {
            if (!MessageService.Current.Ask("Run multithreading logger test?"))
            {
                return;
            }

            var timer = new Stopwatch();
            timer.Start();

            ThreadStart action = () => 
            { 
                for (int i = 0; i < 1000; i++)
                {
                    Logger.Current.Warn("An error occured: " + i);
                } 
            };

            var list = new List<Thread>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(new Thread(action));    
            }

            for (int i = 0; i < 5; i++)
            {
                list[i].Start();
            }

            timer.Stop();
            Debug.Print("Elapsed: " + timer.Elapsed);
        }
    }
}
