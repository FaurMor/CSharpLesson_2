using System.Collections.Generic;
using System.Linq;

namespace SharpLesson
{
    public static class MatchStatisticCounter
    {
        public static float CalculateWinRate(List<bool> statisticList)
        {
            int battleCount = statisticList.Count;
            int winCount = statisticList.Where(x => x).Count();
            return (float)winCount / battleCount;
        }

        public static int GetTotalMatchCount(List<bool> statisticList) => statisticList.Count;
            
        public static int CalculateWinStreak(List<bool> statisticList)
        {
            int maxWinStreak = 0;
            int winStreak = 0;
            foreach (var result in statisticList)
            {
                if (result)
                {
                    winStreak++;
                    if (winStreak > maxWinStreak) 
                    {
                        maxWinStreak = winStreak; 
                    }
                }
                else winStreak = 0;
            }
            return maxWinStreak;
        }
    }
}
