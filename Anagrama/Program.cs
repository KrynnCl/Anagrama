using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Anagrama
{
    class Program
    {
         public static void Main()
        {
            foreach (var test in GetTestCases())
            {
                var result = IsAnagramPair(test.First, test.Second);
                Console.WriteLine((result == test.Expected) ? "Success" : "FAIL");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Static Function to evaluate if the first word is an anagram of the second
        /// </summary>
        /// <param name="first">string first word to compare</param>
        /// <param name="second">string second word to compare</param>
        /// <returns></returns>
        public static bool IsAnagramPair(string first, string second)
        {
            string a = new String(first.ToLower().ToCharArray().OrderBy(letra=>letra).ToArray());
            
            string b = new String(second.ToLower().ToCharArray().OrderBy(letra => letra).ToArray());
            a = Regex.Replace(a, @"[^\w]", "", RegexOptions.None);
            b = Regex.Replace(b, @"[^\w]", "",RegexOptions.None);


            return a.Trim()==b.Trim();
        }


        public static IEnumerable<TestCase> GetTestCases()
        {
            yield return new TestCase { First = "add", Second = "dad", Expected = true };
            yield return new TestCase { First = "aad", Second = "dad", Expected = false };
            yield return new TestCase { First = "Astronomer", Second = "Moon starer", Expected = true };
            yield return new TestCase { First = "thorough", Second = "through", Expected = false };
            yield return new TestCase { First = "Jim Morrison", Second = "Mr. Mojo Risin'", Expected = true };
            yield return new TestCase { First = "Istno de Panama", Second = "Tio San me da pan", Expected = true };

        }
    }
    
}

    