namespace Algorithms
{
    public static class Strings
    {
        #region SuperReducedStrings
        public static string superReducedString(string s)
        {
            List<char> chars = Reduce(s.Select(c => c).ToList());

            if(chars.Count == 0 )
                return "Empty String";
            else    
                return new string(chars.ToArray());
        }

        public static List<char> Reduce(List<char> chars)
        {
            for (int i = 0; i < chars.Count; i++)
            {
                for (int j = i+1; j < chars.Count; j++)
                {
                    if (chars[i] == chars[j])
                    {
                        chars.RemoveAt(j);
                        chars.RemoveAt(i);
                        Reduce(chars);
                    }

                }
            }
            return chars;
        }
        #endregion
        
        public static int camelcase(string s)
        {
            int count = 0;
            string UpperLsit = "QWERTYUIOPASDFGHJKLÇZXCVBNM";
            foreach(char c in s)
            {
                if (UpperLsit.Contains(c))
                    count++;
            }
            return count + 1;
        }

        public static int minimumNumber(int n, string password)
        {
            string numbers = "0123456789";
            string lower_case = "abcdefghijklmnopqrstuvwxyz";
            string upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string special_characters = "!@#$%^&*()-+";

            bool containNumbers = false, containLower = false, containUpper = false, containSpetial = false;
            int ret = 4;

            foreach(char c in password)
            {
                if (!containNumbers && numbers.Contains(c))
                {
                    ret--;
                    containNumbers = true;
                }
                if (!containLower && lower_case.Contains(c))
                {
                    ret--;
                    containLower = true;
                }
                if (!containUpper && upper_case.Contains(c))
                {
                    ret--;
                    containUpper = true;
                }
                if (!containSpetial && special_characters.Contains(c))
                {
                    ret--;
                    containSpetial = true;
                }
            }

            if(password.Length < 6) 
            {
                int miss = 6 - password.Length;
                return miss;
            }
            return ret;
        }
    }
}