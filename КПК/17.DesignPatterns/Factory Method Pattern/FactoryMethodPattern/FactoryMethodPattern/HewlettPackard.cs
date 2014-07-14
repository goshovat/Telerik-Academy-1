using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class HewlettPackard : Manufacturer
    {
        public override Laptop ManufactureLaptop()
        {
            var laptop = new HewlettPackardLaptop("HP super joystick", 7, 4096, 1024, HardDriveType.SolidStateDrive, ProcessorType.Intel, 8, 1700.99d);

            return laptop;
        }
    }
}
