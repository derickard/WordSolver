using System;
using System.Collections.Generic;
using System.Text;

namespace WordSolver
{
    class Solution
    {
        public List<string> Words { get; set; }

        public void Push (string word)
        {
            Words.Add(word);
        }
        
        public void Pop()
        {
            if(Words.Count != 0)
            {
                Words.RemoveAt(Words.Count);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(string w in Words)
            {
                sb.Append(w);
                sb.Append(" / ");
            }

            return sb.ToString();
        }
    }
}
