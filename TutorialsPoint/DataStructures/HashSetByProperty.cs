using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.DataStructures
{
    public class HashSetByProperty<TClass, TProperty> : HashSet<TClass> where TClass : class
    {
        /// <summary>
        /// Creates HashSet with IEqualityComparer, which compares objects on
        /// property, that is retrieved via provided propertyFunc
        /// Beware: uses boxing for value types
        /// </summary>
        public HashSetByProperty(Func<TClass, TProperty> propertyFunc) : base(new EqualityComparator(propertyFunc))
        {
        }

        private class EqualityComparator : IEqualityComparer<TClass>
        {
            private Func<TClass, TProperty> propertyFunc;
            private Func<TClass, TClass, bool> comparerFunc;

            public EqualityComparator(Func<TClass, TProperty> propertyFunc)
            {
                this.propertyFunc = propertyFunc;

                // beware - it uses boxing for value types
                comparerFunc = (a, b) => propertyFunc(a).Equals(propertyFunc(b));
            }

            public bool Equals(TClass x, TClass y)
            {
                // error in MSDN guideline
                // https://stackoverflow.com/questions/55205473/msdn-guide-x-equalsnull-returns-false-for-non-nullable-value-types-only

                if(y == null || x == null)
                {
                    if(x == null && y == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (ReferenceEquals(x, y)) return true;

                return propertyFunc(x).Equals(propertyFunc(y));
            }

            public int GetHashCode(TClass obj)
            {
                return propertyFunc(obj).GetHashCode();
            }
        }
    }
}
