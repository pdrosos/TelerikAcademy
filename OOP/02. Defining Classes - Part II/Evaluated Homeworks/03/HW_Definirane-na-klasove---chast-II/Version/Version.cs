using System;

//Note - AllowMultiple = false/true allows for several attributes to be used at the same time
//for example if we want to see the version history we must set it to true 
//and add new attrubite every time we release a new version
[AttributeUsage(AttributeTargets.Struct |
  AttributeTargets.Class | AttributeTargets.Interface | 
  AttributeTargets.Enum | AttributeTargets.Method,
  AllowMultiple = true)]
public class VersionAttribute : System.Attribute
{
    //Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods 
    //and holds a version in the format major.minor (e.g. 2.11). 
    //Apply the version attribute to a sample class and display its version at runtime.
    
    public int Major { get; private set; }
    public int Minor { get; private set; }

    public VersionAttribute(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }
}


