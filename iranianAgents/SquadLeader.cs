using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using investigation.sensors;

namespace investigation.iranianAgents
{
    internal class SquadLeader:Agent,IAttackAgent
    {
        public int CounterAttack { get; set; } = 0;
        public SquadLeader(List<string> availableSensors):base(4,availableSensors,"squad leader")
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
            CounterAttack++;
            
            
        }
    }
}
