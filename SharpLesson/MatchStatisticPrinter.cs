using System.Collections.Generic;
using System.Linq;

namespace SharpLesson
{
    public class MatchStatisticPrinter
    {
        public const string SuccsessfulHero = "Самый успешный герой:";
        public const string UnsuccsessfulHero = "Самый неуспешный герой:";
        public const string FavoriteHero = "Самый любимый герой:";
        public const string UnfavoriteHero = "Самый нелюбимый герой:";
        public const string WinstreakHero = "Герой с самым большим винстриком:";

        public MatchStatisticPrinter() { }

        public string PrintSuccsessfulHero(Dictionary<Hero, float> winRateList)
        {
            string result = "";
            var sortedWinrateList = SortMatchStatisticDecrease(winRateList);
            float maxWinRate = 0;
            foreach(var winRate in sortedWinrateList)
            {
                if (winRate.Value >= maxWinRate)
                {
                    maxWinRate = winRate.Value;
                    result += $" {winRate.Key}";
                    result += " " + string.Format("{0:0.00}",winRate.Value);
                }
                else { break; }
            }
            return result;
        }

        public string PrintUnsuccsessfulHero(Dictionary<Hero, float> winRateList)
        {
            string result = "";
            var sortedWinrateList = SortMatchStatisticIncrease(winRateList);
            float minWinRate = -1;
            foreach (var winRate in sortedWinrateList)
            {
                if (winRate.Value <= minWinRate || minWinRate == -1)
                {
                    minWinRate = winRate.Value;
                    result += $" {winRate.Key}";
                    result += " " + string.Format("{0:0.00}", winRate.Value);
                }
                else { break; }
            }
            return result;
        }

        public string PrintFavoriteHero(Dictionary<Hero, int> matchCountList)
        {
            string result = "";
            var sortedMatchCountList = SortMatchStatisticDecrease(matchCountList);
            int maxMatchCount = 0;
            foreach(var matchCount in sortedMatchCountList)
            {
                if (matchCount.Value >= maxMatchCount)
                {
                    maxMatchCount = matchCount.Value;
                    result += $" {matchCount.Key} ({matchCount.Value} матчей)";
                }
                else { break; }
            }
            return result;
        }

        public string PrintUnfavoriteHero(Dictionary<Hero, int> matchCountList)
        {
            string result = "";
            var sortedMatchCountList = SortMatchStatisticIncrease(matchCountList);
            int minMatchCount = -1;
            foreach (var matchCount in sortedMatchCountList)
            {
                if (matchCount.Value >= minMatchCount || minMatchCount == -1)
                {
                    minMatchCount = matchCount.Value;
                    result += $" {matchCount.Key} ({matchCount.Value} матчей)";
                }
                else { break; }
            }
            return result;
        }

        public string PrintWinstreakHero(Dictionary<Hero, int> winstreakList)
        {
            string result = "";
            var sortedWinstreakList = SortMatchStatisticDecrease(winstreakList);
            int maxWinstreak = 0;
            foreach (var winstreak in sortedWinstreakList)
            {
                if (winstreak.Value >= maxWinstreak)
                {
                    maxWinstreak = winstreak.Value;
                    result += $" {winstreak.Key} ({winstreak.Value} побед)";
                }
                else { break; }
            }
            return result;
        }

        private Dictionary<Hero, int> SortMatchStatisticIncrease(Dictionary<Hero, int> statisticList) 
            => statisticList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        private Dictionary<Hero, float> SortMatchStatisticIncrease(Dictionary<Hero, float> statisticList)
            => statisticList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        private Dictionary<Hero, int> SortMatchStatisticDecrease(Dictionary<Hero, int> statisticList)
            => statisticList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        private Dictionary<Hero, float> SortMatchStatisticDecrease(Dictionary<Hero, float> statisticList)
            => statisticList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

    }
}
