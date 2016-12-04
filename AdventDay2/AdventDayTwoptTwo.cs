using System;

namespace AdventDay2
{

    public class AdventDayTwoPt2
    {
        static int CurrentPositionPtTwo = 5;
        //Problem with moving like pt one is that it cannot be broken down into easily coded math. 
        //Need more of a keypad map for this functionalitiy.

        public static string GetKeyNumberPt2()
        {
            string hexValue = CurrentPositionPtTwo.ToString("X");
            return hexValue;
        }

        public static void UpdateCurrentPositionPtTwo(char Direction)
        {
            switch (Direction)
            {
                case 'U': //move up or minus 4

                    if (CurrentPositionPtTwo <= 5 && CurrentPositionPtTwo != 3)
                    {
                        return; //do nothing
                    } else if (CurrentPositionPtTwo == 9)
                    {
                        return; //do nothing
                    }
                    else if (CurrentPositionPtTwo == 3 || CurrentPositionPtTwo == 13)
                    {
                        CurrentPositionPtTwo -= 2; //move into exception case and minus 2
                    } else {
                        CurrentPositionPtTwo -= 4; //move up or minus 4
                    }
                    break;

                case 'D': //move down or plus 3

                    if (CurrentPositionPtTwo >= 9 && CurrentPositionPtTwo != 11)
                    {
                        return; //do nothing
                    }else if(CurrentPositionPtTwo == 5){
                        return; //do nothing
                    }
                    else if(CurrentPositionPtTwo == 1 || CurrentPositionPtTwo == 11){
                        CurrentPositionPtTwo += 2; //move into exception case and plus 2
                    }
                    else
                    {
                        CurrentPositionPtTwo += 4; //move down or plus 4
                    }
                    break;


                case 'R': //move right or plus 1

                    if (((CurrentPositionPtTwo % 4) == 0) && (CurrentPositionPtTwo != 8)) //If value equals 8, we can still move right to 9
                    {
                        return; //do nothing
                    }
                    else if (CurrentPositionPtTwo == 1 || CurrentPositionPtTwo == 9 || CurrentPositionPtTwo == 13) //cannot move right past 9
                    {
                        return; //do nothing at 9
                    }
                    else
                    {
                        CurrentPositionPtTwo += 1; //move right or plus 1
                    }
                    break;

                case 'L': //move left or minus 1

                    if ( ((CurrentPositionPtTwo % 4) == 2) && (CurrentPositionPtTwo != 6) ) //if Current Position is 6, we can still move left to 5
                    {
                        return; //do nothing
                    }
                    else if (CurrentPositionPtTwo == 1 || CurrentPositionPtTwo == 5 || CurrentPositionPtTwo == 13) //cannot move right past 9
                    {
                        return; //do nothing at 9
                    }
                    else
                    {
                        CurrentPositionPtTwo -= 1; //move left or minus 1
                    }
                    break;

            }
        }
    }
}
