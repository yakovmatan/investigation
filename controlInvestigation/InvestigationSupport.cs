using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using investigation.iranianAgents;
using investigation.room;
using investigation.sensors;

namespace investigation.manager
{
    internal class InvestigationSupport
    {
        public Agent agent { get; private set; }
        public Room room { get; private set; }

        public List<string> SensorTypes { get; } = new List<string> { "audio", "thermal", "pulse", "magnetic", "motion" };

        private Dictionary<string, int> numOfSensors = new Dictionary<string, int>
        {
            {"foot soldier",2 },
            {"squad leader", 4 },
            {"senior commander", 6 },
            {"organization leader", 8 }
        };

        public void InitNewAgent(Agent agent)
        {
            room = new Room(this.GetRequiredSensorCount());
            this.agent = agent;
        }

        public int GetRequiredSensorCount()
        {
            return numOfSensors[agent.type];
        }

        public void AttachSensor(int index, Sensor sensor)
        {
            room.Attach(index, sensor);
        }

        // function to active sensor
        public void ActivateSensors()
        {
            foreach (var sensor in this.room.attachedSensore)
            {
                if (sensor == null)
                    continue;
                sensor.Activate();
                if (sensor is MagneticSensor magnetic)
                {
                    magnetic.CancelingAttack(agent);
                }
            }
        }

        public void HandleAttack()
        {
            if (agent is IAttackAgent attackAgent)
            {
                attackAgent.Attack(room.attachedSensore);
            }
        }
        // function to get how much is maches
        public int GetMatchCount()
        {
            return room.NumOfMatches(agent.GetSensorRequirementCount());
        }

        public bool IsFullMatched()
        {
            return GetMatchCount() == GetRequiredSensorCount();
        }
    }
}
