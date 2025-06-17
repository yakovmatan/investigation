using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.sensors
{
    public abstract class Sensor
    {
        public string type { get; }
        public bool active { get; protected set; } = false;
        public Sensor(string type)
        {
            this.type = type;
        }

        public virtual void Activate()
        {
            this.active = true;
        }
    }
}
