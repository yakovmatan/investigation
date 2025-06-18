using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.sensors
{
    public static class SensorFactory
    {
        public static Sensor CreateSensor(string type)
        {
            switch (type.ToLower())
            {
                case "audio": return new AudioSensor();
                case "thermal": return new ThermalSensor();
                case "pulse": return new PulseSensor();
                case "motion": return new MotionSensor();
                case "magnetic": return new MagneticSensor();



                default: throw new ArgumentException("Invalid sensor type");
            }
        }
    }

}
