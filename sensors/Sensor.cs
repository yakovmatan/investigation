using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.sensors
{
    internal abstract class Sensor
    {
        protected string type;

        public Sensor(string type)
        {
            this.type = type;
        }

        public void Activate(Dictionary<string, int> sensors)
        {
            if (sensors.ContainsKey(this.type))
            {
                sensors[this.type] += 1;
            }
            else
            {
                sensors[this.type] = 1;
            }
                
        }
    }
}
