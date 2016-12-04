using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventDay2
{
    class AdventDayTwo
    {
        static private int CurrentPosition = 5; //5 is the starting position

        static private int GetNextNumber()
        {
            return CurrentPosition;
        }


        static private void UpdateCurrentPosition(char Direction)
        {
            switch (Direction)
            {
                case 'U': //move up or minus 3

                    if (CurrentPosition <= 3)
                    {
                        return; //do nothing
                    }
                    else
                    {
                        CurrentPosition -= 3; //move up or minus 3
                    }
                    break;

                case 'D': //move down or plus 3

                    if (CurrentPosition >= 7)
                    {
                        return; //do nothing
                    }
                    else
                    {
                        CurrentPosition += 3; //move down or plus 3
                    }
                    break;


                case 'R': //move right or plus 1

                    if ((CurrentPosition % 3) == 0)
                    {
                        return; //do nothing
                    }
                    else
                    {
                        CurrentPosition += 1; //move right or plus 1
                    }
                    break;

                case 'L': //move left or minus 1

                    if ((CurrentPosition % 3) == 1)
                    {
                        return; //do nothing
                    }else {
                        CurrentPosition -= 1; //move left or minus 1
                    }
                    break;

            }
        }


        static private string[] GetListOfDirections()
        {
            //parse text file into string array split by newline
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"InputData.txt");
            string TotalListOfDirections = File.ReadAllText(filePath);
            return TotalListOfDirections.Split(new string[] { Environment.NewLine}, StringSplitOptions.None);
        }
        static void Main(string[] args)
        {
            //receive the entire text file and put it into this array of strings
            string[] ListOfInstructions = GetListOfDirections();
            int[] KeypadEntry = new int[ListOfInstructions.Length];
            string keypadEntryStringPtTwo = "";
            //loop for each numberpad entry, split by newline character in text file
            for (int i = 0; i < ListOfInstructions.Length; i++)
            {
                //for each letter 
                foreach (char Direction in ListOfInstructions[i])
                {
                    UpdateCurrentPosition(Direction);
                    AdventDayTwoPt2.UpdateCurrentPositionPtTwo(Direction);
                }
                KeypadEntry[i] = GetNextNumber();
                keypadEntryStringPtTwo += AdventDayTwoPt2.GetKeyNumberPt2();
           }
            string keypadEntryString = "";


            foreach (int entry in KeypadEntry)
            {
                keypadEntryString += entry;

            }



            Console.WriteLine("{0}", keypadEntryString);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("{0}", keypadEntryStringPtTwo);
        }
    }
}
