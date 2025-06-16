using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.sensors
{
    internal abstract class Sensor
    {
        public string type { get; }

        public Sensor(string type)
        {
            this.type = type;
        }

        public virtual void Activate(int index,string[] sensors)
        {
            sensors[index] = this.type;
        }
    }
}
