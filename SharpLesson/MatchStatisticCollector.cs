using System.Collections.Generic;


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
                MatchStatisticCounter counter = new MatchStatisticCounter(statistic.Value);
                float heroWinRate = counter.CalculateWinRate();
                _winRateStatistic.Add(statistic.Key, heroWinRate);
            }
            return _winRateStatistic;
        }

        public Dictionary<Hero, float> GetMatchCountStatistic()
        {
            _matchCountStatistic = new Dictionary<Hero, float>();
            foreach(var statistic in _statisticList)
            {
                MatchStatisticCounter counter = new MatchStatisticCounter(statistic.Value);
                int matchCount = counter.GetTotalMatchCount();
                _matchCountStatistic.Add(statistic.Key, matchCount);
            }
            return _matchCountStatistic;
        }

        public Dictionary<Hero, float> GetWinstreakStatistic()
        {
            _winstreakStatistic = new Dictionary<Hero, float>();
            foreach( var statistic in _statisticList)
            {
                MatchStatisticCounter counter = new MatchStatisticCounter(statistic.Value);
                int winstreakCount = counter.CalculateWinStreak();
                _winstreakStatistic.Add(statistic.Key, winstreakCount);
            }
            return _winstreakStatistic;
        }
    }
}
