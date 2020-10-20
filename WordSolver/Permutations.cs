using System;
using System.Linq;
using System.Text;

namespace WordSolver
{
    public class Permutations
    {
        // calling:
        //  string[] atoms = new string[] { "ant", "bat", "cow", "cow" };
        //  StringPerm p = null;
        //  Console.WriteLine("All permutations are:\n");
        //      for (int k = 0; (ulong) k<StringPerm.FactorialLookup(atoms.Length()); ++k)
        //      {
        //          p = new StringPerm(atoms, k);
        //          Console.WriteLine(k + " " + p.ToString());
        //      }

        private string[] element;
        private int order;

        public Permutations(string[] atoms)
        {
            if (atoms == null) throw new ArgumentNullException("atoms");
            if (!IsValid(atoms)) throw new ArgumentException("atoms");
            this.element = new string[atoms.Length];
            atoms.CopyTo(this.element, 0);
            this.order = atoms.Length;
        }

        public Permutations(string[] atoms, int k)
        {
            this.element = new string[atoms.Length];
            this.order = atoms.Length;

            // Step #1 - Find factoradic of k
            int[] factoradic = new int[this.order];
            for (int j = 1; j <= this.order; ++j)
            {
                factoradic[this.order - j] = k % j;
                k /= j;
            }

            // Step #2 - Convert factoradic[] to numeric permuatation in perm[]
            int[] temp = new int[this.order];
            int[] perm = new int[this.order];
            for (int i = 0; i < this.order; ++i)
            {
                temp[i] = ++factoradic[i];
            }
            perm[this.order - 1] = 1;  // right-most value is set to 1.
            for (int i = this.order - 2; i >= 0; --i)
            {
                perm[i] = temp[i];
                for (int j = i + 1; j < this.order; ++j)
                {
                    if (perm[j] >= perm[i]) ++perm[j];
                }
            }
            for (int i = 0; i < this.order; ++i)  // put in 0-based form
                --perm[i];

            // Step #3 - map numeric permutation to string permutation
            for (int i = 0; i < this.order; ++i)
                this.element[i] = atoms[perm[i]];
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            //result.Append("{ ");
            for (int i = 0; i < this.order; ++i)
            {
                result.Append(this.element[i]);
                //result.Append(" ");
            }
            //result.Append("}");
            return result.ToString();
        }

        public static bool IsValid(string[] e)
        {
            if (e == null) return false;
            if (e.Length < 2) return false;
            for (int i = 0; i < e.Length - 1; ++i)
            {
                if (e[i].CompareTo(e[i + 1]) >= 0) return false;
            }
            return true;
        }



        public static ulong FactorialLookup(int n)
        {
            if (n < 0 || n > 20)
                throw new Exception("Input argument must be between 0 and 20");
            ulong[] answers = new ulong[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600, 6227020800, 87178291200,
                                            1307674368000, 20922789888000, 355687428096000, 6402373705728000, 121645100408832000, 2432902008176640000 };
            return answers[n];
        }

        //public static string[] GetPermutations(string[] Word)
        //{
        //    Permutations p = null;
        //    ulong size = FactorialLookup(Word.Length);
        //    string[] ReturnPerms = new string[size];
        //    for (int k = 0; (ulong)k < Size; ++k)
        //    {
        //        p = new Permutations(Word, k);
        //        ReturnPerms[k] = 
        //        Console.WriteLine("\t Permutation: " + k + " " + p.ToString());
        //    }

        //    return ReturnPerms;

        //}
    }
}