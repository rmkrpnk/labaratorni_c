using System;

namespace SmartHomeSystem
{
    internal class MotionSensor : Device
    {
        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} активовано.");
        }

        public override void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} деактивовано.");
        }
    }
}
