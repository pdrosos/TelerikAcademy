using System;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface
    | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]

public class VersionClass : System.Attribute
{
    public int Major { get; private set; }
    public int Minor { get; private set; }

    public VersionClass(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }
}


