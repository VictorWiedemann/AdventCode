using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;



public enum Heading { North = 1, East = 2, South = 3, West = 4 };
enum LeftOrRight { Left = -1, Right = 1 };


namespace AdventDayOne
{
    class Program
    {
        static private Heading GetNewHeading(Heading OldHeading, LeftOrRight Direction)
        {
            int NewHeadingInt = (int)OldHeading + (int)Direction;
            if (NewHeadingInt == 0)
            {
                NewHeadingInt = 4;

            }
            else if (NewHeadingInt == 5)
            {
                NewHeadingInt = 1;

            }


            Heading NewHeading = (Heading)NewHeadingInt;


            return NewHeading;
        }

        static private string[] GetListOfDirections()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"InputData.txt");
            string TotalListOfDirections = File.ReadAllText(filePath);
            //string TotalListOfDirections = "R8, R4, R4, R8";
            return TotalListOfDirections.Split(new string[] { ", " }, StringSplitOptions.None);
        }


        static void Main(string[] args)
        {

            //Open and get turn file into a string
            string[] ListOfDirections = GetListOfDirections();

            //Get length of direction array for our loop
            int LengthOfDirectionArray = ListOfDirections.Length;

            //init variable that will be kept between loops
            Heading OldHeading = Heading.North;
            int xCoord = 0;
            int yCoord = 0;
            LeftOrRight NextDirection = LeftOrRight.Right;

            for (int i = 0; i < LengthOfDirectionArray; i++)
            {

                //Get if you are turning left or right
                char NextDirectionLetter = ListOfDirections[i][0];



                //Find if we are turning left or right
                if (NextDirectionLetter == 'R')
                {
                    NextDirection = LeftOrRight.Right;
                }
                else if (NextDirectionLetter == 'L')
                {
                    NextDirection = LeftOrRight.Left;
                }
                else
                {
                    //error
                }

                //Remove L or R to get just the number after
                int DistanceInSteps = int.Parse(ListOfDirections[i].Remove(0, 1));


                Heading NewHeading = GetNewHeading(OldHeading, NextDirection);

                //FIXME: make this better, not the greatest way to to do this.
                //SwitchCase?

                //With heading add or subtract value to total
                if (NewHeading == Heading.North)//positive y direction
                {
                    yCoord += DistanceInSteps;

                }
                else if (NewHeading == Heading.South)
                { //negative y direction

                    yCoord -= DistanceInSteps;

                }
                else if (NewHeading == Heading.East)
                { //positive x direction

                    xCoord += DistanceInSteps;

                }
                else if (NewHeading == Heading.West)
                { //negative x direction 

                    xCoord -= DistanceInSteps;

                }
                else
                {
                    //error
                }

                bool IsRepeatValue = AdventDayOnePt2.IsThereARepeatValue(NewHeading, DistanceInSteps);

                OldHeading = NewHeading;

            }

            int TotalValue = Math.Abs(xCoord) + Math.Abs(yCoord);
            int CrossOverTotal = Math.Abs(AdventDayOnePt2.CrossOverPosition[0]) + Math.Abs(AdventDayOnePt2.CrossOverPosition[1]);
            Console.WriteLine("{0}   {1}", TotalValue, CrossOverTotal);
        }


    }
}


