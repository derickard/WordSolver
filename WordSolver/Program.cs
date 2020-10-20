using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace WordSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> letters = new List<char>()
            {
                'a',
                'b',
                'c',
                't'
            };
            Letters TestLetters = new Letters(letters);
            Console.WriteLine(TestLetters.ToString());

            List<string> Combos = new List<string>();

            foreach(IEnumerable<char> e in Combinations.GetCombinations(TestLetters.AvailableLetters, 3))
            {
                string Combo = new string(e.ToArray());

                //  want to feed each of these combos to Permutations as an array  
                string[] ComboStr = e.Select(c => c.ToString()).ToArray();
                Console.WriteLine($"Combo:-\t{Combo}-");
                Permutations p = null;
                for (int k = 0; (ulong)k < Permutations.FactorialLookup(ComboStr.Length); ++k)
                {
                    p = new Permutations(ComboStr, k);
                    Console.WriteLine("\t" + p.ToString());
                }

                //string[] ComboPerms = GetPermutations(ComboStr);
               

                Combos.Add(Combo);
            }

            //Console.WriteLine("Combos:");
            //foreach(string s in Combos)
            //{
            //    Console.WriteLine(s);
            //}
            
            //string[] ComboArray = new string[] { "a", "b", "c", "t" };
            //Permutations pP = null;
            //Console.WriteLine("Permutations:");
            //for (int k = 0; (ulong)k < Permutations.FactorialLookup(ComboArray.Length); ++k)
            //{
            //    pP = new Permutations(ComboArray, k);
            //    Console.WriteLine(k + " " + pP.ToString());
            //}
        }

        //public static string[] GetPermutations(string[] Word)
        //{
        //    Permutations p = null;
        //    ulong Size = Permutations.FactorialLookup(Word.Length);
        //    string[] ReturnPerms = new string[Size];
        //    for (int k = 0; (ulong)k < Size; ++k)
        //    {
        //        p = new Permutations(Word, k);
        //        ReturnPerms[k] = p.ToString();
        //        Console.WriteLine("\t Permutation: " + k + " " + p.ToString());
        //    }

        //    return ReturnPerms;

        //}
    }
}
