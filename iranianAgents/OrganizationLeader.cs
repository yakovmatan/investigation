using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigation.sensors;

namespace investigation.iranianAgents
{
    internal class OrganizationLeader:Agent,IAttackAgent
    {
        public int CounterAttack { get; set; } = 0;

        public OrganizationLeader(List<string> availableSensors):base(8,availableSensors,"organization leader")
        {

        }

        public void Attack(Sensor[] sensors)
        {
            if (CounterAttack > 0 && CounterAttack % 3 == 0)
            {
                if (!sensors.Any(s => s != null)) return;
                int index;
                do
                {
                    index = random.Next(sensors.Length);
                }
                while (sensors[index] == null);

                sensors[index] = null;
            }
            else if (CounterAttack % 10 == 0)
            {
                for (int i = 0; i < sensors.Length; i++)
                {
                    sensors[i] = null;
                }
            }
            CounterAttack++;
        }

    }
}
