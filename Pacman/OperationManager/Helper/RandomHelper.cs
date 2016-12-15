﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.Helper
{
    public static class RandomHelper
    {
        public static int GetRandomNumber(double[] list)
        {
            var proportionList = new ProportionValue<int>[list.Length];
            for (var i = 0; i < list.Length; i++)
            {
               proportionList[i] = ProportionValue.Create(list[i], i);
            }

            return proportionList.ChooseByRandom();
        }
    }
    public class ProportionValue<T>
    {
        public double Proportion { get; set; }
        public T Value { get; set; }
    }

    public static class ProportionValue
    {
        public static ProportionValue<T> Create<T>(double proportion, T value)
        {
            return new ProportionValue<T> { Proportion = proportion, Value = value };
        }

        static Random random = new Random();
        public static T ChooseByRandom<T>( this IEnumerable<ProportionValue<T>> collection)
        {
            var rnd = random.NextDouble();
            foreach (var item in collection)
            {
                if (rnd < item.Proportion)
                    return item.Value;
                rnd -= item.Proportion;
            }
            throw new InvalidOperationException(
                "The proportions in the collection do not add up to 1.");
        }
    }
}
