using System;

namespace AdventDayOne
{

    public class AdventDayOnePt2
    {
        //persistant current position
        static public int[] CurrentPosition = new int[2] { 0, 0 };
        static public int PersistantIncrement = 0;
        static public int[,] ListOfPositions = new int[1000, 2];
        static public bool RepeatBool = false;
        static public int[] CrossOverPosition = new int[2] { 0, 0 };



        //check entire array of input values for any matches. If match found return true and save crossover point.
        public static bool CheckForRepeatInArray(int[] XYCoord)
        {
            //for first time through loop, skip out. First Value is (0,0)


            for (int j = 0; j < 1000; j++)
            {
                //check if the x coordinate has been saved before
                if (ListOfPositions[j, 0] == XYCoord[0])
                {
                    //check if the y coordinate has been saved before with that x value
                    if (ListOfPositions[j, 1] == XYCoord[1])
                    {
                        //save the crossOver Position for the get function
                        CrossOverPosition = XYCoord;
                        RepeatBool = true;
                        return true;
                    }
                }
            }
            //Add to the X coordinate
            ListOfPositions[PersistantIncrement, 0] = XYCoord[0];
            //Add to the Y Coordinate
            ListOfPositions[PersistantIncrement, 1] = XYCoord[1];
            PersistantIncrement++;
            return false;
        }

        public static bool IsThereARepeatValue(Heading NewHeading, int DistanceInSteps)
        {
            //jump out if we already found the repeat step
            if (RepeatBool) return true;

            //Not the cleanest implementation. Can do better.
            if (NewHeading == Heading.North)//positive y direction
            {
                int[] tempXYCoord = new int[2] { 0, 0 };
                for (int i = 1; i < DistanceInSteps + 1; i++)
                {
                    tempXYCoord[0] = CurrentPosition[0];
                    tempXYCoord[1] = (CurrentPosition[1] + i);

                    if (CheckForRepeatInArray(tempXYCoord)) return true;

                }
                CurrentPosition = tempXYCoord;
            }
            else if (NewHeading == Heading.South)
            { //negative y direction

                int[] tempXYCoord = new int[2] { 0, 0 };
                for (int i = 1; i < DistanceInSteps + 1; i++)
                {
                    tempXYCoord[0] = CurrentPosition[0];
                    tempXYCoord[1] = (CurrentPosition[1] - i);

                    if (CheckForRepeatInArray(tempXYCoord)) return true;

                }
                CurrentPosition = tempXYCoord;

            }
            else if (NewHeading == Heading.East)
            { //positive x direction

                int[] tempXYCoord = new int[2] { 0, 0 };
                for (int i = 1; i < DistanceInSteps + 1; i++)
                {
                    tempXYCoord[0] = CurrentPosition[0] + i;
                    tempXYCoord[1] = CurrentPosition[1];

                    if (CheckForRepeatInArray(tempXYCoord)) return true;



                }
                CurrentPosition = tempXYCoord;

            }
            else if (NewHeading == Heading.West)
            { //negative x direction 

                int[] tempXYCoord = new int[2] { 0, 0 };
                for (int i = 1; i < DistanceInSteps + 1; i++)
                {
                    tempXYCoord[0] = CurrentPosition[0] - i;
                    tempXYCoord[1] = CurrentPosition[1];

                    if (CheckForRepeatInArray(tempXYCoord)) return true;



                }
                CurrentPosition = tempXYCoord;


            }
            else
            {
                //error
            }

            return false;
        }

    }

}