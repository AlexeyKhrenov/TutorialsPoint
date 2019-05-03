using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.Groups
{
    public abstract class Group<T> where T : class, IEquatable<T>
    {
        // don't use HashSet for index access
        public virtual List<T> Set { get; set; }

        public int Size => Set.Count;

        private T _identity = null;
        private T[][] _cartesianProduct = null;
        private Dictionary<T, T> _inverseMap = null;

        public Group()
        {
            Set = new List<T>();
        }

        // check all four axioms
        public bool IsValidGroup()
        {
            return
                IsClosedUnderOperation()   &&
                IdentityElement() != null   &&
                EachElementHasInverse()    &&
                IsOperationAssociative()   ;
        }

        // CLOSURE
        public virtual bool IsClosedUnderOperation()
        {
            var cartesianProduct = CartesianProduct();

            for (var i = 0; i < cartesianProduct.Length; i++)
            {
                var line = cartesianProduct[i];

                for (var j = 0; j < line.Length; j++)
                {
                    if (!Contains(line[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // IDENTITY
        public virtual T IdentityElement()
        {
            if (_identity != null)
            {
                return _identity;
            }

            // there can be only one identity element
            for (var i = 0; i < Size; i++)
            {
                var A = Set[i]; // we check if A is an identity element

                for (var j = i + 1; j < Size; j++)
                {
                    var B = Set[j];

                    var C = Operation(A, B);

                    if (!C.Equals(B))
                    {
                        break;
                    }

                    if (j == Size - 1)
                    {
                        _identity = A;
                        return A;
                    }
                }
            }
            return null;
        }

        // INVERSE
        public virtual bool EachElementHasInverse()
        {
            return !InverseMap().ContainsValue(null);
        }

        public virtual T Inverse(T a)
        {
            if (_inverseMap != null && _inverseMap.Count == Size)
            {
                _inverseMap.TryGetValue(a, out var inverse);
                return inverse;
            }

            for (var i = 0; i < Size; i++)
            {
                var b = Set[i];
                var c = Operation(a, b);

                //there can only be one inverse element for each element
                if (c.Equals(IdentityElement()))
                {
                    return b;
                }
            }

            return null;
        }

        // ASSOCIATIVITY
        public virtual bool IsOperationAssociative()
        {
            var cartesianProduct = CartesianProduct();

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    for (var k = 0; k < Size; k++)
                    {
                        var axBxC = Operation(Set[i], cartesianProduct[j][k]);
                        var AxBxc = Operation(cartesianProduct[i][j], Set[k]);
                        if (!axBxC.Equals(AxBxc))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        public virtual T[][] CartesianProduct()
        {
            if (_cartesianProduct != null)
            {
                return _cartesianProduct;
            }

            _cartesianProduct = new T[Size][];

            for (var i = 0; i < Size; i++)
            {
                _cartesianProduct[i] = new T[Size];

                for (var j = 0; j < Size; j++)
                {
                    for (var k = 0; k < Size; k++)
                    {
                        _cartesianProduct[i][j] = Operation(Set[i], Set[j]);
                    }
                }
            }

            return _cartesianProduct;
        }

        // if group contains the same elements the code fill fail only
        // when executing this method - fix it or make 
        // group validation compulsory
        protected virtual Dictionary<T,T> InverseMap()
        {
            if (_inverseMap != null)
            {
                return _inverseMap;
            }

            _inverseMap = new Dictionary<T, T>();

            for (var i = 0; i < Size; i++)
            {
                var a = Set[i];
                var b = Inverse(a);
                _inverseMap.Add(a, b);
            }

            return _inverseMap;
        }

        public bool Contains(T element)
        {
            return Set.Contains(element);
        }

        public abstract T Operation(T a, T b);
    }
}
