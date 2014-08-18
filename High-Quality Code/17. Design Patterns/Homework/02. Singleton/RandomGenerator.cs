// ********************************
// <copyright file="ColorConsole.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
// <author>Telerik Student</author>
// ********************************
namespace Singleton
{
    using System;

    public static class RandomGenerator
    {
        private static readonly Random rand = null;

        static RandomGenerator()
        {
            if (rand == null)
            {
                rand = new Random();
            }
        }

        public static int Generate(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue + 1);
        }
    }
}
