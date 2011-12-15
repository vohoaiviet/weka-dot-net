﻿namespace Weka.NET.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public static class Arrays
    { 
        public static bool ArrayEquals(double?[] left, double?[] right)
        {
            if (left.Length != right.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (left[i].HasValue)
                {
                    if (false == right[i].HasValue)
                    {
                        return false;
                    }
                }
                else
                {
                    if (right[i].HasValue)
                    {
                        return false;
                    }

                    continue;
                }

                if (false == left[i].Value.Equals(right[i].Value))
                {
                    return false;
                }
            }

            return true;
        }

        internal static IEnumerable<double?> BuildSingleton(int length, int index, double? value)
        {
            double?[] values = new double?[length];

            values[index] = value;

            return values;
        }

        public static bool AreEquals(IList<double?> left, IList<double?> right)
        {
            if (left.Count != right.Count)
            {
                return false;
            }

            for (int i = 0; i < left.Count; i++)
            {
                if (left[i].HasValue)
                {
                    if (false == right[i].HasValue)
                    {
                        return false;
                    }

                    if (false == left[i].Value.Equals(right[i].Value))
                    {
                        return false;
                    }

                    continue;
                }

                if (right[i].HasValue)
                {
                    return false;
                }
            }

            return true;
        }

        internal static string ArrayToString(IList<double?> Items)
        {
            var buff = new StringBuilder("[");

            foreach (var item in Items)
            {
                if (item.HasValue)
                {
                    buff.Append(item.Value);
                }

                buff.Append(",");
            }

            buff.Replace(',', ']', buff.Length - 1, buff.Length);

            return buff.ToString();
        }

        internal static int GetHashCodeForArray(IList<double?> Items)
        {
            int hash = 13;

            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].HasValue)
                {
                    hash ^= Items[i].Value.GetHashCode();
                }
            }

            return hash;
        }

        public static IList<double?> Merge(IList<double?> first, IList<double?> second)
        {
            double?[] result = new double?[first.Count];

            for (int i = 0; i < first.Count; i++)
            {
                if (first[i].HasValue)
                {
                    if (second[i].HasValue)
                    {
                        throw new Exception("booh");
                    }

                    result[i] = first[i];
                    continue;
                }

                if (second[i].HasValue)
                {
                    result[i] = second[i];
                }
            }

            return result.ToList();
        }
    }
}