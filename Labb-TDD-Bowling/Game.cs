using System.Diagnostics.Metrics;
using System.Runtime.Serialization.Formatters;
using System.Timers;

namespace Labb_TDD_Bowling
{
    public class Game
    {
        private readonly int[] _rolls = new int[22];
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int round = 0; round < 10; round++)
            {
                if (IsStrike(roll))
                {
                    score += ExtraPointStrike(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + _rolls[roll + 2];
                    roll += 2;
                }
                else
                {
                    score += ExtraPointsSpare(roll);
                    roll += 2;
                }

            }

            return score;
        }

        private int ExtraPointsSpare(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1];
        }

        private int ExtraPointStrike(int roll)
        {
            return 10 + _rolls[roll + 1] + _rolls[roll + 2];
        }

        private bool IsSpare(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return _rolls[roll] == 10;
        }

    }
}