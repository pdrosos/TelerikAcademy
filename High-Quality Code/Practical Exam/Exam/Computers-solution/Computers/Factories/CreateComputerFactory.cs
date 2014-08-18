namespace Computers.Factories
{
    using System;
    using Computers.Manufacturers;

    public static class CreateComputerFactory
    {
        public static AbstractComputerFactory GetComputerFactory(Manufacturer manufacturer)
        {
            AbstractComputerFactory computerFactory;

            if (manufacturer.Name == "HP")
            {
                computerFactory = new HpFactory();
            }
            else if (manufacturer.Name == "Dell")
            {
                computerFactory = new DellFactory();
            }
            else if (manufacturer.Name == "Lenovo")
            {
                computerFactory = new LenovoFactory();
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer!");
            }

            return computerFactory;
        }
    }
}
