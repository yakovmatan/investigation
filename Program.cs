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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            InvestigationController gameFlow = new InvestigationController();
            while(true)
            {
                gameFlow.InvastigationRound();
                gameFlow.ShowMatches();
                bool gameEnded = gameFlow.ContinueGame();
                if (gameEnded)
                {
                    break;
                }
            }
            
        }
    }
}
