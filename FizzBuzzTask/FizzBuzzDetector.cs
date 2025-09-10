using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FizzBuzzTask
{
    public class FizzBuzzDetector
    {
        public class Result
        {
            public string Output { get; set; }
            public int Count { get; set; }

            public Result(string output, int count)
            {
                Output = output;
                Count = count;
            }

        }
        public Result GetOverlappings(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input cannot be null");

            if (input.Length < 7 || input.Length > 100)
                throw new ArgumentException("Input length must be between 7 and 100 characters.", nameof(input));

            StringBuilder output = new StringBuilder();

            var regex = new Regex(@"[A-Za-z0-9']+|[^A-Za-z0-9']+"); // pattern for words

            var matches = regex.Matches(input);


            int wordIndex = 0;
            int count = 0;

            foreach (Match match in matches)
            {
                string token = match.Value;

                if (Regex.IsMatch(token, @"^[A-Za-z0-9']+$")) // matching only alphanumeric words
                {
                    wordIndex++;
                    string replacement = "";

                    if (wordIndex % 15 == 0)
                    {
                        replacement = "FizzBuzz";
                    }
                    else if (wordIndex % 3 == 0)
                    {
                        replacement = "Fizz";
                    }
                    else if (wordIndex % 5 == 0)
                    {
                        replacement = "Buzz";
                    }

                    

                    if (!string.IsNullOrEmpty(replacement))
                    {
                        output.Append(replacement);
                        count++;
                    }
                    else
                    {
                        output.Append(token);
                    }
                }
                else
                {
                    output.Append(token); // Adding the other parts of the string and keeping the formatting.
                }
            }

            return new Result(output.ToString(), count);
        }
    }
}

