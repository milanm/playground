using System;
namespace RomanToArabic
{
    public class Translate
    {
        private static int ArabicFromRomanWeight(char roman)
        {
            switch(roman)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: throw new Exception("Roman literal not known: " + roman);
            }
        }

        public static string getArabic(string romanNumeral)
        {
            int result = 0;

            for (int i = 0; i < romanNumeral.Length; i++)
            {
                if ((i != romanNumeral.Length - 1) &&
                    (ArabicFromRomanWeight(romanNumeral[i + 1]) > ArabicFromRomanWeight(romanNumeral[i])))
                {
                    result += ArabicFromRomanWeight(romanNumeral[i + 1]) - ArabicFromRomanWeight(romanNumeral[i]);
                    i++;
                }
                else
                {
                    result += ArabicFromRomanWeight(romanNumeral[i]);
                }
            }

            return result.ToString();
        }
    }
}
