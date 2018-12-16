using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsgQuizzes.Tests
{
    /// <summary>
    /// HINT: This class MUST NOT be modified. You don't have to write anything here.
    /// </summary>
    [TestClass]
    public class QuizzesTest
    {

        [TestMethod]
        public void IsPalindrome1()
        {
            var qs = new Quizzes();
            Assert.IsTrue(qs.IsPalindrome("Anna"));
        }

        [TestMethod]
        public void IsPalindrome2()
        {
            var qs = new Quizzes();
            Assert.IsFalse(qs.IsPalindrome("Store"));
        }

        [TestMethod]
        public void PostfixCalc1a()
        {
            var qs = new Quizzes();
            Assert.AreEqual(100, qs.PostFixCalc("5 5 + 10 *"));
        }

        [TestMethod]
        public void PostfixCalc1b()
        {
            var qs = new Quizzes();
            Assert.AreEqual(26, qs.PostFixCalc("2 3 8 * +"));
        }

        [TestMethod]
        public void PostfixCalc1c()
        {
            var qs = new Quizzes();
            Assert.AreEqual(-2, qs.PostFixCalc("8 1 2 3 + - /"));
        }

        [TestMethod]
        public void GetOddNumbersTest()
        {
            var qs = new Quizzes();
            CollectionAssert.AreEqual(new[] { 1, 3, 5, 7, 9 }, qs.GetOddNumbers(10));
        }

        [TestMethod]
        public void OrderByAvgScoresDescendingTest()
        {
            var exams =
                new[]
                    {
                        new Exam("anna", 9.5m), new Exam("anna", 7.0m), new Exam("anna", 8.0m),
                        new Exam("marcel", 7.0m), new Exam("marcel", 5.0m), new Exam("marcel", 8.0m),
                        new Exam("lluis", 9.0m), new Exam("lluis", 9.0m), new Exam("lluis", 9.0m),
                        new Exam("ari", 3.0m), new Exam("ari", 4.0m), new Exam("ari", 5.0m),
                    };
            var qs = new Quizzes();
            CollectionAssert.AreEqual(new[] {"lluis", "anna", "marcel", "ari"}
                                      , qs.OrderByAvgScoresDescending(exams));
        }

        [TestMethod]
        public void GenerateBoard1()
        {
            var strInput = " o x    x";
            var qs = new Quizzes();
            Assert.AreEqual(@"
   | O |   
-----------
 X |   |   
-----------
   |   | X 
"
, qs.GenerateBoard(strInput));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateBoardError()
        {
            var strInput = "olakeaseo";
            var qs = new Quizzes();
            var ret = qs.GenerateBoard(strInput);
        }
    }
}
