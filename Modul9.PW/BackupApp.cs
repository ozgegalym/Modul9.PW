using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul9.PW
{
class BackupApp
    {
        private List<Storage> devices;

        public BackupApp(List<Storage> devices)
        {
            this.devices = devices;
        }

        public double CalculateTotalMemory()
        {
            return devices.Sum(device => device.GetMemory());
        }

        public double CopyDataToDevices(double dataSize)
        {
            return devices.Max(device => device.CopyData(dataSize));
        }

        public int CalculateRequiredDevices(double dataSize)
        {
            double remainingData = dataSize;
            int requiredDevices = 0;

            foreach (var device in devices)
            {
                double freeSpace = device.GetFreeSpace();
                if (remainingData <= freeSpace)
                {
                    requiredDevices++;
                    break;
                }
                else
                {
                    requiredDevices++;
                    remainingData -= freeSpace;
                }
            }

            return requiredDevices;
        }
    }

}

