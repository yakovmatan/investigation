using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigation.iranianAgents;

namespace investigation.sensors
{
    internal class MagneticSensor:Sensor
    {
        private bool alreadyCanceled = false;
        public MagneticSensor() : base("pulse")
        {

        }

        public void CanelingAttack(Agent agent)
        {
            if (alreadyCanceled) return;

            if (agent is IAttackAgent attackAgent)
            {
                attackAgent.CounterAttack = -6;
                alreadyCanceled = true;
            }
        }
    }
}
