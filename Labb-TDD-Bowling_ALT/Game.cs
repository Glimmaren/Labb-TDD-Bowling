using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_TDD_Bowling_ALT
{
    internal class Game
    {
        private int totalScore;

        public int[,] frames = new int[11, 2];

        private int roundCount;
        private int rollCount = 1;
        private int strikeScore;
        private int extraScoreRolls;
        private int count;
        private bool spare;

        public int[] rolls = new int[22];
        private int currentRoll;

        public void Roll(int v)
        {
            frames[roundCount, rollCount] = v;

            if (extraScoreRolls != 0)
            {
                strikeScore += v;
                extraScoreRolls--;
                count++;

                if (count != 0) // gör metod IsSpare och IsStrike
                {
                    if (count == 2) //Stike scoreing
                    {
                        if (frames[roundCount, 1] + frames[roundCount, 0] != 10)
                            frames[roundCount - 1, 1] += strikeScore;
                        else
                            frames[roundCount - 2, 1] += strikeScore;
                        totalScore += strikeScore;
                        strikeScore = 0;
                        count = 0;

                    }
                    else if (spare)
                    {
                        frames[roundCount - 1, 1] += strikeScore;
                        totalScore += strikeScore;
                        spare = false;
                    }
                }
            }

            if (rollCount == 0 || v == 10)
            {

                roundCount++;

                if (v == 10 && roundCount < 9) // Strike
                {

                    extraScoreRolls = 2;
                }
                else if (v + frames[roundCount - 1, 1] == 10 && roundCount < 9) //Spare
                {
                    extraScoreRolls = 1;
                    spare = true;
                }

                rollCount = 1;

            }
            else
                rollCount--;

            totalScore += v;
        }

        public int Score()
        {
            throw new NotImplementedException();
        }
    }
}
