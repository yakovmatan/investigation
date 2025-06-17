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
            Dictionary<string, int> dictActiveSensore = new Dictionary<string, int>();

            for (int i = 0; i < attachedSensore.Length; i++)
            {
                string current = this.attachedSensore[i].type;
                if (string.IsNullOrEmpty(current))
                    continue;

                if (dictActiveSensore.ContainsKey(current))
                {
                    dictActiveSensore[current] += 1;
                }
                else
                {
                    dictActiveSensore[current] = 1;
                }
            }
            return dictActiveSensore;
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
