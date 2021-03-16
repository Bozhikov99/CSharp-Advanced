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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type typeName = Type.GetType(className);

            FieldInfo[] fields = typeName.GetFields(
                BindingFlags.Public|
                BindingFlags.Instance|
                BindingFlags.Static);

            MethodInfo[] getters = typeName.GetMethods(BindingFlags.NonPublic|BindingFlags.Instance);
            MethodInfo[] setters = typeName.GetMethods(BindingFlags.Public|BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo m in getters.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{m.Name} have to be public!");
            }

            foreach (MethodInfo m in setters.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{m.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string targetClass)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(targetClass);
            MethodInfo[] privateMethods = classType.GetMethods(
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static );

            sb.AppendLine($"All Private Methods of Class: {classType}");
            sb.AppendLine($"Base Class: {classType.BaseType}");
            
            foreach (MethodInfo m in privateMethods)
            {
                sb.AppendLine(m.Name);
            }

            return sb.ToString();
        }
    }
}
