﻿using System.Collections.Generic;

namespace SharpLesson
{
    public static class MatchStatistic
    {
        public static Dictionary<Hero, List<bool>> GetMatchStatistic()
        {
            Dictionary<Hero, List<bool>> totalStatisticDict = new Dictionary<Hero, List<bool>>();

            totalStatisticDict.Add(new Hero(HeroNames.Luizianna), new List<bool>() { false, true, true });

            totalStatisticDict.Add(new Hero(HeroNames.Korkes), new List<bool>() { true, true, true, false, true });

            totalStatisticDict.Add(new Hero(HeroNames.Nova), new List<bool>() { true, true, false, true, true, true, false });

            totalStatisticDict.Add(new Hero(HeroNames.YunJin), new List<bool>() { true, false, false });

            totalStatisticDict.Add(new Hero(HeroNames.Raiko), new List<bool>() { false, false, true, true, false });

            return totalStatisticDict;
        }
    }
}
