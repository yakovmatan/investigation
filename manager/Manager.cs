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
    internal class Manager
    {
        private List<string> TypesOfSensors = new List<string> { "Audio sensor", "Thermal sensor" };
        private Agent footSoldier;
        private Sensor audioSensore = new AudioSensor();
        private Sensor thermalSensor = new ThermalSensor();
        private Room room = new Room();

        public Manager()
        {
            this.footSoldier = new FootSoldier(TypesOfSensors);
        }

        // function to active sensor
        public void ActivateSensor(string type)
        {
            if (type == "audio")
            {
                audioSensore.Activate(room.activeSensore);
            }
            else if (type == "thermal")
            {
                thermalSensor.Activate(room.activeSensore);
            }
        }
        // function to get how much is maches
        public int NumOfMatches()
        {
            return room.NumOfMatches(footSoldier.GetSensorRequirementCount());
        }
    }
}
