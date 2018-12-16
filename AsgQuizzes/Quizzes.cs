using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AsgQuizzes
{
    /// <summary>
    /// HINT: Implement this methods to make all tests in QuizzesTest.cs pass
    /// </summary>
    public class Quizzes
    {
        /// Expected time to resolve: 2 minutes
        public bool IsPalindrome(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                throw new ArgumentException();
            var startChar = default(int);
            var endChar = str.Length - 1;
            var input = str.ToLower();
            while (true)
            {
                if (startChar > endChar)
                    return true;
                if (input[startChar] != input[endChar])
                    return false;
                startChar++;
                endChar--;
            }

        }

        /// Expected time to resolve: 2 minutes
        public int[] GetOddNumbers(int n)
        {
            var oddNumbers = new List<int>();
            try
            {
                for (int i = 0; i <= n; i++)
                    if (i % 2 != 0)
                        oddNumbers.Add(i);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            return oddNumbers.ToArray();
        }

        /// Expected time to resolve: 5 minutes
        public string[] OrderByAvgScoresDescending(IEnumerable<Exam> exams)
        {
            try
            {
                return exams.GroupBy(e => e.Student)
                    .Select(e => new { Avg = e.Average(s => s.Score), Name = e.Key })
                    .OrderByDescending(o => o.Avg)
                    .Select(s => new List<string> { s.Name }.FirstOrDefault())
                    .ToArray();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        /// Expected time to resolve: 15 minutes
        public string GenerateBoard(string strInput)
        {
            Func<string, bool> IsStringHasOtherChar = (str) =>
            {
                var _input = str.Replace(" ", "").ToLower();
                for (int i = 0; i < _input.Length; i++)
                    if (!(_input[i] == 'x' || _input[i] == 'o'))
                        return true;
                return false;
            };
            if (strInput.Length > 9 || IsStringHasOtherChar(strInput))
                throw new ArgumentException();
            var input = strInput.ToCharArray();
            //While testing please don't change the unit test Assert value - I have used the same as my base template
            var boardTemplate = @"
 {0} | {1} | {2} 
-----------
 {3} | {4} | {5} 
-----------
 {6} | {7} | {8} 
";
            int index = 0;
            foreach (var c in input)
            {
                boardTemplate = boardTemplate.Replace("{" + index + "}", c.ToString().ToUpper());
                index++;
            }
            return boardTemplate;

        }

        /// Expected time to resolve: 60 minutes
        public int PostFixCalc(string s)
        {
            //Operate if it is a operand
            Func<string, string, string, string> MathOperation = (value1, value2, operand) =>
              {
                  var temp1 = Convert.ToDouble(value1);
                  var temp2 = Convert.ToDouble(value2);

                  switch (operand)
                  {
                      case "+":
                          return (temp2 + temp1).ToString();
                      case "-":
                          return (temp2 - temp1).ToString();
                      case "*":
                          return (temp2 * temp1).ToString();
                      case "/":
                          return (temp2 / temp1).ToString();
                      default:
                          return string.Empty;
                  }
              };
            var stack = new Stack<string>();
            var input = s.Split(' ');

            for (int i = 0; i < input.Length; i++)
                if (new Regex(@"^[0-9]+$").IsMatch(input[i]))
                    //Push if it is a number
                    stack.Push(input[i].ToString());
                else
                    //Push after performing the operation
                    stack.Push(MathOperation(stack.Pop(), stack.Pop(), input[i].ToString()));
            return Convert.ToInt32(stack.Pop());
        }
    }

    public class Exam
    {
        public string Student { get; set; }
        public decimal Score { get; set; }

        public Exam(string student, decimal score)
        {
            this.Student = student;
            this.Score = score;
        }
    }

}
