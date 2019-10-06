using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TutorialsPoint
{
    public static class ExtensionMethods
    {
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IOrderedEnumerable<KeyValuePair<TKey, TValue>> ordered)
        {
            return ordered.ToDictionary(x => x.Key, x => x.Value);
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> enumerable)
        {
            return enumerable.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
