using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventDay3
{
    class AdventDayThree
    {
        static private string[] GetListOfTriangles()
        {
            //parse text file into string array split by newline
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"InputData.txt");
            string TotalListOfDirections = File.ReadAllText(filePath);
            return TotalListOfDirections.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }
        static public int[] FirstTriangle = new int[3];
        static public int[] SecondTriangle = new int[3];
        static public int[] ThirdTriangle = new int[3];

        static private int IncrementCount = 0;
        static private int CountOfPartTwoSuccesses = 0;
        //Attempts to read 3 rows at a time and then calcuates the math verically instead of horizontally
        static private void CheckIfTriangleIsRealByRowOfThree(int[] Triangle)
        {
            FirstTriangle[IncrementCount] = Triangle[0];
            SecondTriangle[IncrementCount] = Triangle[1];
            ThirdTriangle[IncrementCount] = Triangle[2];

            IncrementCount++;
            if ((IncrementCount % 3) == 0)
            {
                IncrementCount = 0;
                //Could make this next part cleaner. Fix with rework.
                if (CheckIfTriangleIsReal(FirstTriangle))
                {
                    CountOfPartTwoSuccesses++;
                }
                if (CheckIfTriangleIsReal(SecondTriangle))
                {
                    CountOfPartTwoSuccesses++;
                }
                if (CheckIfTriangleIsReal(ThirdTriangle))
                {
                    CountOfPartTwoSuccesses++;
                }
            }
        }

        static private bool CheckIfTriangleIsReal(int[] TriangleEdgeLength)
        {
            //add all sides together then minus the largest number from the array. If the remaining value is larger than the 
            //largest number return true
            // if( (Total - Max) < (Max) ) return true

            int Length = (TriangleEdgeLength.Sum()) - (TriangleEdgeLength.Max());
            if (Length > TriangleEdgeLength.Max())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int CountOfRealTriangles = 0; 
            string[] ListOfTriangles = GetListOfTriangles();
            foreach (string Triangle in ListOfTriangles)
            {
                string[] TriangleEdgeLengthStr = Triangle.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int[] TriangleEdgeLength = TriangleEdgeLengthStr.Select(int.Parse).ToArray();
                //if the triangle is real, increment counter
                if ( CheckIfTriangleIsReal(TriangleEdgeLength) ) 
                {
                    CountOfRealTriangles++;
                }
                //Fucntion Call for rows of 3 at a time
                CheckIfTriangleIsRealByRowOfThree(TriangleEdgeLength);
            }
            Console.WriteLine("Number of real triangles is: {0}", CountOfRealTriangles);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Number of real triangles for part 2 is: {0}", CountOfPartTwoSuccesses);
        }
    }
}
