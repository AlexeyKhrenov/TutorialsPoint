using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialsPoint.LinearAlgebra
{
    public class Vector
    {
        public int Dimension => array.Length;

        private double[] array;

        public Vector(int dimension)
        {
            array = new double[dimension];
        }

        public Vector(double[] array)
        {
            this.array = array;
        }

        public Vector FindPerpendicular(Vector b)
        {
            double _AB = this * b;
            if (_AB == 0)
            {
                return null;
            }

            double _BB = b * b;
            if (_BB == null)
            {
                return null;
            }

            double alpha = (double)_AB / (double)_BB;
            return this - b * alpha;
        }

        public static double operator * (Vector a, Vector b)
        {
            if (a.Dimension != b.Dimension)
            {
                throw new ArgumentException();
            }

            double result = 0;

            for (var i = 0; i < a.Dimension; i++)
            {
                result += a.array[i] * b.array[i];
            }

            return result;
        }

        public static Vector operator * (Vector a, double scalar)
        {
            var c = new Vector(a.Dimension);
            c.AddVector(a);
            c.Multiplication(scalar);
            return c;
        }

        public static Vector operator + (Vector a, Vector b)
        {
            var c = new Vector(a.Dimension);
            c.AddVector(a);
            c.AddVector(b);
            return c;
        }

        public static Vector operator - (Vector a, Vector b)
        {
            var c = new Vector(a.Dimension);
            c.AddVector(a);
            c.MinusVector(b);
            return c;
        }

        private void AddVector(Vector b)
        {
            if (b.Dimension != Dimension)
            {
                throw new ArgumentException();
            }

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = array[i] + b.array[i];
            }
        }

        private void MinusVector(Vector b)
        {
            if (b.Dimension != Dimension)
            {
                throw new ArgumentException();
            }

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = array[i] - b.array[i];
            }
        }

        private void Multiplication(double scalar)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * scalar;
            }
        }

        private double Sum()
        {
            double result = 0;

            for (var i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }
    }
}
