using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


namespace Algorithms
{
    public static class Sorting
    {
        public static int introTutorial(int V, List<int> arr)
        {
            int boundryleft = 0, boundryright = arr.Count;
            int pos = 0;

            while (boundryright > boundryleft)
            {
                pos = (int)Math.Floor((double)((boundryright - boundryleft) / 2)) + boundryleft;

                if (arr[pos] == V)
                    return pos;
                else if (arr[pos] > V)
                    boundryright = pos - 1;
                else
                    boundryleft = pos + 1;
            }

            if (arr[boundryleft] == V)
                return boundryleft;
            else
                throw new Exception("Not found!");
        }

        public static void insertionSort1(int n, List<int> arr)
        {
            int number = arr.Last();
            bool breakLoop = false;

            for(int i = arr.Count()-2; i >= 0; i--)
            {
                if (arr[i] > number)
                {
                    arr[i + 1] = arr[i];
                    breakLoop = false;
                }
                else
                {
                    arr[i + 1] = number;
                    breakLoop = true;
                }
                    

                string line = "";
                foreach(int j in arr)
                {
                    line += j + " ";
                }

                Console.WriteLine(line.Trim());      

                if(breakLoop)
                {
                    break;
                }
                else{
                    if (i == 0)
                    {
                        arr[i] = number;
                        line = "";
                        foreach (int j in arr)
                        {
                            line += j + " ";
                        }
                        Console.WriteLine(line.Trim());
                    }
                }
            }
        }

        #region InsertionSort2
        public static void insertionSort2(int n, List<int> arr)
        {
            int numberIndex = 0;
            for (int i = 1; i < arr.Count(); i++)
            {
                if (arr[numberIndex] >= arr[i])
                    Insert(arr[numberIndex], numberIndex, ref arr); 
                else
                    printList(arr);
                numberIndex++;
            }
            Insert(arr.Last(), arr.Count(), ref arr);
        }

        public static void Insert(int n,int r, ref List<int> arr)
        {
            if (r == 0)
            {
                arr.Insert(2, n);
                arr.RemoveAt(r);
                printList(arr);
                return;

            }

            for (int j = 0; j < arr.Count(); j++)
            {
                
                if (arr[j] <= n)
                    continue;
                
                if (r >= arr.Count())
                {
                    arr.Insert(j, n);
                    arr.RemoveAt(r);
                }
                else if (j < r)
                {
                    arr.RemoveAt(r);
                    arr.Insert(j, n);
                }
                else if(j>r)
                {
                    arr.Insert(j, n);
                    arr.RemoveAt(r);
                }
                                
                printList(arr);
                break;
            }
        }

        private static void printList(List<int> list)
        {
            string line = "";
            foreach(int i in list)
            {
                line += i + " ";
            }
            Console.WriteLine(line.Trim());
        }
        #endregion

        #region QuickSort
        static List<string> bigSorting(List<string> unsorted)
        {
            QuickSort(unsorted, 0, unsorted.Count() - 1);
            return unsorted;
        }

        static void SwapPostions(List<string> list, int position1, int position2)
        {
            var item = list[position1];
            list[position1] = list[position2];
            list[position2] = item;
        }

        static int Partion(List<string> list, int boundryLeft, int boundryRight)
        {
            int pivotPostion = boundryLeft;
            string pivot = list[boundryLeft];

            for (int i = boundryLeft; i <= boundryRight; i++)
            {
                if (IsASmallerThanB(list[i], pivot))
                {
                    pivotPostion++;
                    SwapPostions(list, pivotPostion, i);
                }
            }
            SwapPostions(list, pivotPostion, boundryLeft);
            return pivotPostion;
        }

        static void QuickSort(List<string> list, int boundryLeft, int boundryRight)
        {
            if (boundryLeft < boundryRight)
            {
                int pivotPosition = Partion(list, boundryLeft, boundryRight);
                QuickSort(list, boundryLeft, pivotPosition - 1);
                QuickSort(list, pivotPosition + 1, boundryRight);
            }
        }

        static bool IsASmallerThanB(string a, string b)
        {
            if (a == b)
                return false;
            if (a.Length < b.Length)
                return true;
            else if (a.Length > b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
            {
                if ((int)a[i] < (int)b[i])
                    return true;
                else if ((int)a[i] > (int)b[i])
                    return false;
            }
            return false;
        }
        #endregion
    }
}