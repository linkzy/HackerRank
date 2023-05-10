using System.Numerics;

namespace Algorithms
{
    public static class Implmentation
    {
        public static List<int> breakingRecords(List<int> scores)
        {
            int min = scores.First();
            int max = scores.First();
            List<int> result = new List<int>() { 0, 0 };

            for(int i = 1; i < scores.Count(); i++)
            {
                if (scores[i] > max)
                {
                    result[0] = result[0] + 1;
                    max = scores[i];
                }

                if (scores[i] < min)
                {
                    result[1] = result[1] + 1;
                    min = scores[i];
                }
            }
            return result;
        }

        public static string catAndMouse(int x, int y, int z)
        {
            int xdiff = x - z  < 0? (x - z) * -1 : x - z;
            int ydiff = y - z < 0 ? (y - z) * -1 : y - z;

            if (xdiff == ydiff)
                return "Mouse C";
            else if (xdiff > ydiff)
                return "Cat B";
            else
                return "Cat A";

        }

        public static int hurdleRace(int k, List<int> height)
        {
            int highest = 0;
            foreach(int h in height)
                highest = highest < h? h : highest;

            if (k >= highest)
                return 0;
            else
                return highest - k;
        }

        public static int designerPdfViewer(List<int> h, string word)
        {
            List<string> alphabet = "A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z".Split(',').ToList();
            Dictionary<char, int> charIndexes = new Dictionary<char, int>();
            for(int i = 0; i < alphabet.Count(); i++)
                charIndexes.Add(Convert.ToChar(alphabet[i].Trim()), i);

            int highest = 0;
            foreach(char c in word.ToUpper())
            {
                int index = charIndexes[c];
                highest = h[index] > highest ? h[index] : highest;
            }

            return highest * word.Count();
        }

        public static void extraLongFactorials(int n)
        {
            BigInteger factorial = n;
            while (n > 1)
            {
                factorial *= (n - 1);
                n--;
            }
            Console.WriteLine(factorial);
        }
    }
}

