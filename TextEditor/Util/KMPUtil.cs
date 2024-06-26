﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextEditor.TextEditor.Util
{
    public class KMPUtil
    {
        private static int[] ComputeFailureFunction(string pattern)
        {
            int[] fail = new int[pattern.Length];
            fail[0] = 0;

            int m = pattern.Length;
            int j = 0;
            for (int i = 1; i < m; i++)
            {
                while (j > 0 && pattern[j] != pattern[i])
                {
                    j = fail[j - 1];
                }
                if (pattern[j] == pattern[i])
                {
                    j++;
                }
                fail[i] = j;
            }
            return fail;
        }

        public static int Search(string text, string pattern,bool flag)
        {
            if (flag) 
            {
                int a = ReverseSearch(text, pattern);
                return a==-1?-1:text.Length-a-pattern.Length;
            }
            int n = text.Length;
            int m = pattern.Length;
            int[] fail = ComputeFailureFunction(pattern);

            int j = 0;
            for (int i = 0; i < n; i++)
            {
                while (j > 0 && pattern[j] != text[i])
                {
                    j = fail[j - 1];
                }
                if (pattern[j] == text[i])
                {
                    j++;
                }
                if (j == m)
                {
                    return i - m + 1; // Match found
                }
            }
            return -1; // No match found
        }

        private static int ReverseSearch(string text, string pattern)
        {
            text = new string(text.Reverse().ToArray());
            pattern = new string(pattern.Reverse().ToArray());
            int n = text.Length;
            int m = pattern.Length;
            int[] fail = ComputeFailureFunction(pattern);

            int j = 0;
            for (int i = 0; i < n; i++)
            {
                while (j > 0 && pattern[j] != text[i])
                {
                    j = fail[j - 1];
                }
                if (pattern[j] == text[i])
                {
                    j++;
                }
                if (j == m)
                {
                    return i - m + 1; // Match found
                }
            }
            return -1;// No match found
        }

        public static List<int> KMPSearch(string text, string pattern)
        {
            List<int> indices = new List<int>();
            int[] lps = ComputeFailureFunction(pattern);
            int i = 0;
            int j = 0;
            while (i < text.Length)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == pattern.Length)
                {
                    indices.Add(i - j);
                    i = i - j + pattern.Length; // 开始下一次搜索的位置
                    j = 0; // 重置pattern的索引
                }
                else if (i < text.Length && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
            }
            return indices;
        }
    }


}
