using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Type classType=Type.GetType(className);

            FieldInfo[] fields = classType.GetFields(BindingFlags.NonPublic|
                BindingFlags.Static|
                BindingFlags.Instance|
                BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            object instance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {className}");
            foreach (var f in fields)
            {
                sb.AppendLine($"{f.Name} = {f.GetValue(instance)}");
            }

            return sb.ToString();
        }
    }
}
