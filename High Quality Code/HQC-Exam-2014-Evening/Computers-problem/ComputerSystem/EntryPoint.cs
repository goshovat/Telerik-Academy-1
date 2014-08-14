namespace ComputerSystem
{
    using System;
    using ComputerSystem.Core.Computers;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var manufacturer = Console.ReadLine();

            var creator = new ComputersCreator();
            var manufacturerCompany = creator.GetManufacturer(manufacturer, new NewManufacturerFactory());
            Laptop laptop = manufacturerCompany.CreateLaptop();
            Server server = manufacturerCompany.CreateServer();
            PersonalComputer pc = manufacturerCompany.CreatePC();

            while (true)
            {
                var c = Console.ReadLine();

                // TODO: check the null
                if (c.StartsWith("Exit") || c == null)
                {
                    break;
                }

                var cp = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cp.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var cn = cp[0];
                var ca = int.Parse(cp[1]);

                if (cn == "Charge")
                {
                    laptop.ChargeBattery(ca);
                }
                else if (cn == "Process")
                {
                    server.Process(ca);
                }
                else if (cn == "Play")
                {
                    pc.Play(ca);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}