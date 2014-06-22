namespace WalkInMatrix.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;    

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void PrintMatrixToConsoleSizeFiveTest()
        {
            string outputFile = "ConsoleOutput.txt";
            StreamWriter writer = new StreamWriter(outputFile);

            using (writer)
            {
                Console.SetOut(writer);

                Matrix matrix = new Matrix(5, 5);
                MatrixWalker walker = new MatrixWalker(matrix);
                walker.FillMatrix();

                Console.Write(matrix);
            }
            
            StreamReader reader = new StreamReader(outputFile);

            string consoleResult = string.Empty;
            using (reader)
            {
                consoleResult = reader.ReadToEnd();
            }

            string expectedResult = @" 1  13  14  15  16
12   2  21  22  17
11  23   3  20  18
10  25  24   4  19
 9   8   7   6   5";

            Assert.AreEqual(expectedResult, consoleResult, "result is incorect");
        }

        [TestMethod]
        public void PrintMatrixToConsoleSizeSixTest()
        {
            string outputFile = "ConsoleOutput.txt";
            StreamWriter writer = new StreamWriter(outputFile);
            using (writer)
            {
                Console.SetOut(writer);

                Matrix matrix = new Matrix(6, 6);
                MatrixWalker walker = new MatrixWalker(matrix);
                walker.FillMatrix();

                Console.Write(matrix);
            }
            
            StreamReader reader = new StreamReader(outputFile);

            string consoleResult = string.Empty;
            using (reader)
            {
                consoleResult = reader.ReadToEnd();
            }

            string expectedResult = @" 1  16  17  18  19  20
15   2  27  28  29  21
14  31   3  26  30  22
13  36  32   4  25  23
12  35  34  33   5  24
11  10   9   8   7   6";

            Assert.AreEqual(expectedResult, consoleResult, "result is incorect");
        }

        [TestMethod]
        public void PrintMatrixToConsoleSizeTenTest()
        {
            string outputFile = "ConsoleOutput.txt";
            StreamWriter writer = new StreamWriter(outputFile);
            using (writer)
            {
                Console.SetOut(writer);

                Matrix matrix = new Matrix(10, 10);
                MatrixWalker walker = new MatrixWalker(matrix);
                walker.FillMatrix();

                Console.Write(matrix);
            }
            
            StreamReader reader = new StreamReader(outputFile);

            string consoleResult = string.Empty;
            using (reader)
            {
                consoleResult = reader.ReadToEnd();
            }

            string expectedResult = @"  1   28   29   30   31   32   33   34   35   36
 27    2   51   52   53   54   55   56   57   37
 26   73    3   50   66   67   68   69   58   38
 25   90   74    4   49   65   72   70   59   39
 24   89   91   75    5   48   64   71   60   40
 23   88   99   92   76    6   47   63   61   41
 22   87   98  100   93   77    7   46   62   42
 21   86   97   96   95   94   78    8   45   43
 20   85   84   83   82   81   80   79    9   44
 19   18   17   16   15   14   13   12   11   10";

            Assert.AreEqual(expectedResult, consoleResult, "result is incorect");
        }
    }
}
