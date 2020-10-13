using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSolver
{
    class Letters
    {
        public List<char> AllLetters { get; set; }
        public List<char> AvailableLetters { get; set; }

        public void RemoveLetters(string word)
        {
            List<char> chars = word.ToCharArray().ToList();
            foreach(char c in chars)
            {
                AvailableLetters.Remove(c);
            }
        }

        public void ReturnLetters(string word)
        {
            List<char> chars = word.ToCharArray().ToList();
            foreach (char c in chars)
            {
                AvailableLetters.Add(c);
            }
        }
    }
}
