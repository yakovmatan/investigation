using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.sensors
{
    internal abstract class Sensore
    {
        protected string type;

        public Sensore(string type)
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
