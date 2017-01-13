using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace ChurroData.Controllers
{
    [RoutePrefix("api")]
    public class DefaultController : ApiController
    {

        [HttpGet]
        [Route("Token")]
        public Guid WhatIsYourToken()
        {
            return Guid.Parse("xxx");
        }

        [HttpGet]
        [Route("Fibonacci")]
        public long FibonacciNumber(long n)
        {
            if (n > 92 || n< -92)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }else
            {
                if(n >= 0)
                {
                    return FasterFibonacci(n);
                }
                else
                {
                    if((-n)%2 == 1)
                    return FasterFibonacci(-n);
                    else
                    return -FasterFibonacci(-n);
                }

                
            }
              //  throw new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow.");

          



        }


        /**
             * basd on the fact
             * F(2k) = F(k)[2F(k+1) – F(k)]
             * F(2k+1) = F(k+1)2 + F(k)2
             * proof can be found at http://www.m-hikari.com/imf-password2008/1-4-2008/ulutasIMF1-4-2008.pdf
             * **/
        private long FasterFibonacci(long n)
        {
            if (n == 0) return 0;
            if (n <= 2)
                return 1;
            long k = n / 2;
            long a = FasterFibonacci(k + 1);
            long b = FasterFibonacci(k);

            if (n % 2 == 1)
                return a * a + b * b;
            else
                return b * (2 * a - b);
        }


        [HttpGet]
        [Route("TriangleType")]
        public string WhatShapeIsThis(long a, long b, long c)
        {
            if(a<0 || b<0 || c < 0)
            {
                return "Error";
            }
            
            if (a + b > c && b + c > a && a + c > b)
            {
                if (a == b && b == c)
                {
                    return "Equilateral";
                }
                else if (a == b || b == c || c == a)
                {
                    return "Isosceles";
                }
                else
                {
                    return "Scalene";
                }

            }
            else
            {
                return "Error";
            }
        }

        [HttpGet]
        [Route("ReverseWords")]
        public string ReverseWords(string sentence)
        {
            if (sentence == null) return string.Empty;
            if (string.IsNullOrWhiteSpace(sentence)) return string.Empty;

            var leadingSpaceNumber = sentence.Length - sentence.TrimStart().Length;
            var tailingSpaceNumber = sentence.Length - sentence.TrimEnd().Length;
            string charArrayNoLeadingOrTailing = sentence.TrimStart().TrimEnd();


            Func<string, string> convert = delegate (string text)
            {

                var charArray = text.ToCharArray();
                Array.Reverse(charArray);
                var innerResult = new string(charArray);
                return innerResult;

            };


            var reversedWords = string.Join(" ", charArrayNoLeadingOrTailing.Split(' ').Select(x => convert(x)));



            // add leading space and tailing space back
            for (int i = 0; i < leadingSpaceNumber; i++)
            {
                reversedWords = ' ' + reversedWords;
            }

            for (int i = 0; i < tailingSpaceNumber; i++)
            {
                reversedWords = reversedWords + ' ';
            }
            return reversedWords;
            //var textOriginal = sentence;
            //string temp = textOriginal;

            //int i = 0;
            //while (temp.EndsWith("\r\n"))
            //{
            //    temp = temp.Remove(temp.Length - 2);
            //    i++;
            //}
            ////i is how many \r\n in the last part of string.

            //string[] lines = Regex.Split(textOriginal, "\r\n|\r|\n");

            //StringBuilder builder = new StringBuilder();
            //foreach (var line in lines)
            //{
            //    var reversedWords = string.Join(" ", line.Split(' ').Select(x => new String(x.Reverse().ToArray())));
            //    builder.Append(string.Concat(reversedWords));
            //    builder.Append("\r\n");
            //}
            //var bigResult = builder.ToString();

            //bigResult = bigResult.TrimEnd("\r\n".ToArray());
            //for (int j = 0; j < i; j++)
            //{
            //    bigResult = bigResult + "\r\n";
            //}
            //return bigResult;
        }


    }
}
