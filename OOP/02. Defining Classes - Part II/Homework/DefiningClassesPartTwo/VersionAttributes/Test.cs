namespace VersionAttributes
{
    using System;
    using System.Reflection;

    [Version(1, 1)]
    class Test
    {
        [Version(2, 4)]
        public void MethodOne()
        {
        }

        [Version(3, 13)]
        private void MethodTwo()
        {
        }

        [Version(4, 5)]
        static void Main(string[] args)
        {
            MemberInfo member = typeof(Test);
            Console.WriteLine("Class: {0}", member.Name);

            foreach (Attribute attribute in member.GetCustomAttributes())
            {
                PrintVersionAttribute(attribute);
            }

            MethodInfo[] methods = typeof(Test).GetMethods(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine("Method: {0}", method.Name);
                foreach (Attribute attribute in method.GetCustomAttributes())
                {
                    PrintVersionAttribute(attribute);
                }
            }
        }

        [Version(0, 1)]
        private static void PrintVersionAttribute(Attribute attribute)
        {
            if (attribute is VersionAttribute)
            {
                VersionAttribute version = (VersionAttribute)attribute;
                Console.WriteLine(" Version: {0}", version.GetVersion);
            }
        }
    }
}
