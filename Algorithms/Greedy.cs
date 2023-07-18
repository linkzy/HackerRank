namespace HackerRank.Algorithms
{
    public static class Greedy
    {
        public static void decentNumber(int n)
        {
            if (new List<int> { 1, 2, 4 }.Contains(n))
            {
                Console.WriteLine("-1");
                return;
            }                

            if (n % 3 == 0)
            {
                Console.WriteLine("".PadLeft(n, '5'));
                return;
            }
            
            for(int i = 5; i < n; i += 5)
            {
                int left = n - i;
                if(left % 3 == 0)
                {
                    string number = "".PadLeft(left, '5');
                    number += "".PadLeft(i, '3');
                    Console.WriteLine(number);
                    return;
                }
            }

            for (int i = 3; i < n; i += 3)
            {
                int left = n - i;
                if (left % 5 == 0)
                {
                    string number = "".PadRight(left, '3');
                    Console.WriteLine(number.PadRight(i, '5'));
                    return;
                }
            }


            if (n % 5 == 0)
            {
                Console.WriteLine("".PadLeft(n, '3'));
                return;
            }

            Console.WriteLine("-1");
        }
    }
}
