using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigation.sensors;

namespace investigation.room
{
    internal class Room
    {
        public Sensor[] attachedSensore;

        public Room(int length)
        {
            attachedSensore = new Sensor[length];
        }

        public  void Attach(int index,Sensor sensor)
        {
            attachedSensore[index] = sensor;
        }

        private Dictionary<string,int> FromListToDict()
        {
            Dictionary<string, int> dictAttachedSensore = new Dictionary<string, int>();

            for (int i = 0; i < attachedSensore.Length; i++)
            {
                Sensor current = this.attachedSensore[i];
                if (current == null || !current.active)
                    continue;

                if (dictAttachedSensore.ContainsKey(current.type))
                {
                    dictAttachedSensore[current.type] += 1;
                }
                else
                {
                    dictAttachedSensore[current.type] = 1;
                }
            }
            return dictAttachedSensore;
        }

        public int NumOfMatches(Dictionary<string,int> weaknessSensors)
        {
            int numOfMatches = 0;
            foreach (var keyValue in FromListToDict())
            {
                if (weaknessSensors.ContainsKey(keyValue.Key))
                {
                    numOfMatches += Math.Min(keyValue.Value, weaknessSensors[keyValue.Key]);
                }
            }
            return numOfMatches;
        }
    }
}
