using System;

namespace SharpLesson
{
    public class Program
    {
        public static int Main(string[] args)
        {
            MatchStatisticCollector collector = new MatchStatisticCollector(MatchStatistic.GetMatchStatistic());
            MatchStatisticPrinter printer = new MatchStatisticPrinter();
            Console.WriteLine(MatchStatisticPrinter.SuccsessfulHero + printer.PrintSuccsessfulHero(collector.GetWinRateStatistic()));
            Console.WriteLine(MatchStatisticPrinter.UnsuccsessfulHero + printer.PrintUnsuccsessfulHero(collector.GetWinRateStatistic()));
            Console.WriteLine(MatchStatisticPrinter.FavoriteHero + printer.PrintFavoriteHero(collector.GetMatchCountStatistic()));
            Console.WriteLine(MatchStatisticPrinter.UnfavoriteHero + printer.PrintUnfavoriteHero(collector.GetMatchCountStatistic()));
            Console.WriteLine(MatchStatisticPrinter.WinstreakHero + printer.PrintWinstreakHero(collector.GetWinstreakStatistic()));

            return 0;
        }
    }
}