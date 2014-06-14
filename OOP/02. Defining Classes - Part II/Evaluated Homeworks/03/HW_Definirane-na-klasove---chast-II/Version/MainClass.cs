using System;

[VersionAttribute(1, 0)]
class MainClass
{
    static void Main()
    {
        Type type = typeof(MainClass);

        //To search only this class and not it's entite inheritance chain use false param
        object[] versionAttributes = type.GetCustomAttributes(false);

        //We introduced only one custom attribute and we will get just 1 element in array
        //if we had several (like version history) we would have more elements in array
        foreach (VersionAttribute versionAttribute in versionAttributes)
        {
            Console.WriteLine("The version of the MainClass is {0}.{1}",
                versionAttribute.Major, versionAttribute.Minor);
        }

        Console.WriteLine();
    }
}

