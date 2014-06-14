using System;

static class Distance
{
    public static double Calculation(Definition.Point first,Definition.Point second)
    {
        return Math.Sqrt(Math.Pow((second.x - first.x), 2) + Math.Pow((second.y - first.y), 2) + Math.Pow((second.z - first.z), 2));
    } 
}