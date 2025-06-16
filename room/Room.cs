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
        public string[] activeSensore;

        public Room(int length)
        {
            activeSensore = new string[length];
        }

        private Dictionary<string,int> FromListToDict()
        {
            Dictionary<string, int> dictActiveSensore = new Dictionary<string, int>();

            for (int i = 0; i < activeSensore.Length; i++)
            {
                if (string.IsNullOrEmpty(this.activeSensore[i]))
                    continue;

                if (dictActiveSensore.ContainsKey(this.activeSensore[i]))
                {
                    dictActiveSensore[this.activeSensore[i]] += 1;
                }
                else
                {
                    dictActiveSensore[this.activeSensore[i]] = 1;
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
