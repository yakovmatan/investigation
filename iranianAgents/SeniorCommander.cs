using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigation.sensors;

namespace investigation.iranianAgents
{
    internal class SeniorCommander:Agent,IAttackAgent
    {
        private int CounterAttack = 0;

        public SeniorCommander(List<string> availableSensors):base(6,availableSensors,"senior commander")
        {

        }

        public void Attack(Sensor[] sensors)
        {
            if (CounterAttack % 3 == 0)
            {
                int sensorsCount = sensors.Count(s => s != null);
                if (sensorsCount == 0) return;

                int index1, index2;

                do
                {
                    index1 = random.Next(sensors.Length);
                }
                while (sensors[index1] == null);

                sensors[index1] = null;

                if (sensorsCount >= 2)
                {
                    do
                    {
                        index2 = random.Next(sensors.Length);
                    }
                    while (sensors[index2] == null);

                    sensors[index2] = null;
                }
            }
            CounterAttack++;
        }


    }
}
