﻿using System.Collections.Generic;


namespace SharpLesson
{
    public class MatchStatisticCollector
    {
        private Dictionary<Hero, List<bool>> _statisticList;
        private Dictionary<Hero, float> _winRateStatistic;
        private Dictionary<Hero, float> _matchCountStatistic;
        private Dictionary<Hero, float> _winstreakStatistic;

        public MatchStatisticCollector(Dictionary<Hero, List<bool>> statisticList) 
            => _statisticList = statisticList;

        public Dictionary<Hero, float> GetWinRateStatistic()
        {
            _winRateStatistic = new Dictionary<Hero, float>();
            foreach (var statistic in _statisticList) 
            {
                float heroWinRate = MatchStatisticCounter.CalculateWinRate(statistic.Value);
                _winRateStatistic.Add(statistic.Key, heroWinRate);
            }
            return _winRateStatistic;
        }

        public Dictionary<Hero, float> GetMatchCountStatistic()
        {
            _matchCountStatistic = new Dictionary<Hero, float>();
            foreach(var statistic in _statisticList)
            {
                int matchCount = MatchStatisticCounter.GetTotalMatchCount(statistic.Value);
                _matchCountStatistic.Add(statistic.Key, matchCount);
            }
            return _matchCountStatistic;
        }

        public Dictionary<Hero, float> GetWinstreakStatistic()
        {
            _winstreakStatistic = new Dictionary<Hero, float>();
            foreach( var statistic in _statisticList)
            {
                int winstreakCount = MatchStatisticCounter.CalculateWinStreak(statistic.Value);
                _winstreakStatistic.Add(statistic.Key, winstreakCount);
            }
            return _winstreakStatistic;
        }
    }
}
