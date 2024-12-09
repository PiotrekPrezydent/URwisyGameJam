using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Boot.Systems
{
    public static class DependencyInjectorSystem
    {
        internal static void BindConfigs()
        {
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static;
            foreach (var type in Assembly.GetExecutingAssembly().DefinedTypes)
            {
                foreach (var field in type.GetFields(bindingFlags))
                {
                    if (!field.FieldType.Name.EndsWith("Config"))
                        continue;
                    Object[] configs = Resources.LoadAll("Configs");
                    foreach (var config in configs)
                    {
                        if (!config.GetType().Equals(field.FieldType))
                            continue;
                        field.SetValue(null, config);
                        break;
                    }
                }
            }
        }
    }
}