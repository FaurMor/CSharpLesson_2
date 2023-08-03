using System.Collections.Generic;
using System.Linq;

namespace SharpLesson
{
    public class MatchStatisticCounter
    {
        private List<bool> _statisticList;

        public MatchStatisticCounter(List<bool> statisticList)
        {
            _statisticList = statisticList;
        }

        public float CalculateWinRate()
        {
            int battleCount = _statisticList.Count;
            int winCount = _statisticList.Where(x => x).Count();
            return (float)winCount / battleCount;
        }

        public int GetTotalMatchCount() => _statisticList.Count;
            
        public int CalculateWinStreak()
        {
            int maxWinStreak = 0;
            int winStreak = 0;
            foreach (var result in _statisticList)
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
