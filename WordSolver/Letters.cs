﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSolver
{
    class Letters
    {
        public List<char> AllLetters { get; set; }
        public List<char> AvailableLetters { get; set; }

        public Letters(List<char> allLetters)
        {
            AllLetters = allLetters;
            AvailableLetters = AllLetters;
        }

        public Letters()
        {
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Available letters: ");
            foreach(char c in AvailableLetters)
            {
                sb.Append($"{c} ");
            }
            sb.Append("\nAll letters: ");
            foreach (char c in AllLetters)
            {
                sb.Append($"{c} ");
            }
            sb.Append("\n");
            return sb.ToString();
        }
    }
}
