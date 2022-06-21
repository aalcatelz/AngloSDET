using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AngloSDET.TestAutomation.Core.Extensions
{
    public static class ScenarioContextExtension
    {
        public static void SaveValue<T>(this ScenarioContext source, string key, T value)
        {
            if (source.ContainsKey(key))
            {
                source[key] = value;
            }
            else
            {
                source.Add(key, value);
            }
        }
        public static T GetValue<T>(this ScenarioContext source, string key)
        {
            if (source.ContainsKey(key))
            {
                return source.Get<T>(key);
            }

            return default;
        }
    }
}
