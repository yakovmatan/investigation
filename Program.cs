using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigation.manager;

namespace investigation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display();
            display.ShowWelcome();
            while(true)
            {
                display.EnterChoose();
                bool agentExposed = display.ShowMatches();
                if (agentExposed)
                {
                    break;
                }
            }
            
        }
    }
}
