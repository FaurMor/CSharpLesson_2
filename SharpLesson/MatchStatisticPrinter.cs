using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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
        public const string Match = "матчей";
        public const string Win = "побед";
        public const string Winstreak = "винстрик";
        public const string Winrate = "винрейт";

        public string PrintSuccsessfulHero(Dictionary<Hero, float> winRateList) 
            => PrintMaxMatchCount(SortMatchStatisticDecrease(winRateList), Winrate);

        public string PrintUnsuccsessfulHero(Dictionary<Hero, float> winRateList) 
            => PrintMinMatchCount(SortMatchStatisticIncrease(winRateList), Winrate);
        
        public string PrintFavoriteHero(Dictionary<Hero, float> matchCountList)
            => PrintMaxMatchCount(SortMatchStatisticDecrease(matchCountList), Match);

        public string PrintUnfavoriteHero(Dictionary<Hero, float> matchCountList)
            => PrintMinMatchCount(SortMatchStatisticIncrease(matchCountList), Match);

        public string PrintWinstreakHero(Dictionary<Hero, float> winstreakList)
            => PrintMaxMatchCount(SortMatchStatisticDecrease(winstreakList), Winstreak);

        private string PrintMaxMatchCount(Dictionary<Hero, float> sortedMatchList, string matchEvent)
        {
            string result = string.Empty;
            float minMatchCount = 0;
            foreach (var matchCount in sortedMatchList)
            {
                if (matchCount.Value >= minMatchCount)
                {
                    minMatchCount = matchCount.Value;
                    if (matchEvent == Winrate)
                        result += PrintMatchResult(matchCount.Key.Name, matchCount.Value, matchEvent, true);
                    else result += PrintMatchResult(matchCount.Key.Name, matchCount.Value, matchEvent);
                }
                else { break; }
            }
            return result;
        }

        private string PrintMinMatchCount(Dictionary<Hero, float> sortedMatchList, string matchEvent)
        {
            string result = string.Empty;
            float minMatchCount = -1;
            foreach(var matchCount in sortedMatchList)
            {
                if (matchCount.Value <= minMatchCount || minMatchCount == -1)
                {
                    minMatchCount = matchCount.Value;
                    if (matchEvent == Winrate)
                        result += PrintMatchResult(matchCount.Key.Name, matchCount.Value, matchEvent, true);
                    else result += PrintMatchResult(matchCount.Key.Name, matchCount.Value, matchEvent);
                }
                else { break; }
            }
            return result;
        }

        private string PrintMatchResult(string name, float value, string matchEvent, bool isFormat=false)
        {
            if (isFormat)
            {
                return $" {name} ({PrintWinrateFormat(value)} {matchEvent})";
            }
            else
            {
                return $" {name} ({value} {matchEvent})";
            } 
        }
        
        private string PrintWinrateFormat(float winrateValue) 
            => string.Format("{0:0.00}", winrateValue);

        private Dictionary<Hero, float> SortMatchStatisticIncrease(Dictionary<Hero, float> statisticList)
            => statisticList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        private Dictionary<Hero, float> SortMatchStatisticDecrease(Dictionary<Hero, float> statisticList)
            => statisticList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

    }
}
