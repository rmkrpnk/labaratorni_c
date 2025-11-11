using System;
using System.Collections.Generic;

namespace SmartHomeSystem
{
    internal class SmartHomeController
    {
        private List<ISwitchable> allDevices = new List<ISwitchable>();
        private List<IEnergyConsumer> energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            allDevices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            energyDevices.Add(device);
        }

        public void TurnAllOn()
        {
            foreach (var dev in allDevices)
                dev.TurnOn();
        }

        public void TurnAllOff()
        {
            foreach (var dev in allDevices)
                dev.TurnOff();
        }

        public void ShowEnergyReport(int hours)
        {
            Console.WriteLine($"\nЗвіт про споживання енергії за {hours} год:");

            double totalEnergy = 0;

            foreach (var dev in energyDevices)
            {
                double used = dev.GetEnergyUsage(hours);
                Console.WriteLine($"{dev.DeviceName}: {used:F2} кВт·год (потужність: {dev.PowerConsumption} Вт)");
                totalEnergy += used;
            }

            Console.WriteLine($"Загальне споживання: {totalEnergy:F2} кВт·год");
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {totalEnergy * 4:F2} грн\n");
        }
    }
}
