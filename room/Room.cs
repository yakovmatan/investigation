using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.room
{
    internal class Room
    {
        public Dictionary<string,int> activeSensore = new Dictionary<string,int>();

        public int NumOfMatches(Dictionary<string,int> weaknessSensors)
        {
            int numOfMatches = 0;
            foreach (var keyValue in activeSensore)
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
