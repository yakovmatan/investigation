using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.sensors
{
    internal class PulseSensor:Sensor
    {
        private int count = 0;
        public PulseSensor():base("pulse")
        {

        }

        public override void Activate()
        {
            int counter = 0;
            if (count == 3)
            {
                counter++;
                this.active = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️ Sensor pulse is broken and can no longer be used.");
                Console.ResetColor();
                return;
            }
            base.Activate();
            count++;
        }
    }
}
