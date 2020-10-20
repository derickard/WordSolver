using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WordSolver
{
    class Combinations
    {
        // Permutations.GetCombinations(AvailableLetters, # of letters in word)
        // returns enumerable of unique combinations from available letters
        static public IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetCombinations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }

        //static public List<List<char>> GetCombinations(List<char> items, int count)
        //{
        //    int i = 0;
        //    foreach(char item in items)
        //    {
        //        if (count == 1)
        //            yield return new List<char> { item };
        //        else
        //        {
        //            foreach (List<char> result in GetCombinations(items.Skip(i + 1), count - 1))
        //                yield return new List<char> { item }.Concat(result);
        //        }
        //    }
        //}
    }
}
