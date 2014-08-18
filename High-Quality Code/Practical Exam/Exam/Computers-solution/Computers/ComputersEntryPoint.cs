namespace Computers
{
    using System;
    using Computers.Commands.Info;
    using Computers.Commands.Parsers;
    using Computers.Factories;
    using Computers.Manufacturers;
    using Computers.Types;

    internal class ComputersEntryPoint
    {
        public static void Main()
        {
            ICommandParser parser = new CommandParser();

            Pc pc;
            Laptop laptop;
            Server server;

            var manufacturerName = Console.ReadLine();
            Manufacturer manufacturer = new Manufacturer(manufacturerName);
            AbstractComputerFactory computerFactory = CreateComputerFactory.GetComputerFactory(manufacturer);

            laptop = computerFactory.CreateLaptop();
            server = computerFactory.CreateServer();
            pc = computerFactory.CreatePc();

            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput == null || userInput.StartsWith("Exit"))
                {
                    break;
                }

                CommandInfo commandInfo = parser.Parse(userInput);

                // Command pattern is not implemented further here, because it's not required in the task description :)
                if (commandInfo.CommandName == "Charge")
                {
                    laptop.ChargeBattery(commandInfo.Argument);
                }
                else if (commandInfo.CommandName == "Process")
                {
                    server.Process(commandInfo.Argument);
                }
                else if (commandInfo.CommandName == "Play")
                {
                    pc.Play(commandInfo.Argument);
                }
            }
        }
    }
}