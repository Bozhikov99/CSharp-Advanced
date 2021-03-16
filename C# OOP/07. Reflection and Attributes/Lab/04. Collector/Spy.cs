using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string targetClass)
        {
            StringBuilder sb = new StringBuilder();

            Type className = Type.GetType(targetClass);

            MethodInfo[] methods = className.GetMethods(
                BindingFlags.Public |
                BindingFlags.NonPublic|
                BindingFlags.Instance);

            foreach (MethodInfo m in methods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{m.Name} will return {m.ReturnType}");
            }

            foreach (MethodInfo m in methods.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{m.Name} will set field of {m.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}
