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

        public override void Activate(int index, string[] sensors)
        {
            if (count == 3)
            {
                Console.WriteLine("The sensor is broken");
                return;
            }
            base.Activate(index, sensors);
            count++;
        }
    }
}
