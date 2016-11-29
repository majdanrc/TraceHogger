using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH.DataAccess.Blocks;

namespace TraceHogger.Helpers
{
    public static class TraceAnalysisOutputHelper
    {
        public static string OutputBasicStats(TraceAnalysis analysis, int rowsToShow = 20)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("# [name: {0}] statistics: {1} total; {2} grouped; gain -> {3} ({4}%)",
                analysis.Name, analysis.Total, analysis.Grouped, analysis.Gain, analysis.GainPercent));
            sb.AppendLine(string.Format("# [name: {0}] statistics: {1} total time;",
                analysis.Name, (analysis.CleanRows.First().StartTime - analysis.CleanRows.First().EndTime).Milliseconds));

            const int stringLimit = 100;

            if (rowsToShow > 0)
            {
                sb.AppendLine("#====== with ids");
                foreach (var source in analysis.RawGrouped.Take(rowsToShow))
                {
                    sb.AppendLine(source.Count + " " +
                                      source.Command.Substring(0,
                                          source.Command.Length < stringLimit ? source.Command.Length : stringLimit));
                }
                sb.AppendLine("#^^^^^^ with ids");
            }

            sb.AppendLine(@"#====== without ids \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/");
            foreach (var source in analysis.CleanGrouped)
            {
                sb.AppendLine(source.Count + "     "
                                 //+ " [ " + source.TotalDuration / 1000 + " ] "
                                 + source.Command.Substring(0,
                                      source.Command.Length < stringLimit ? source.Command.Length : stringLimit));
            }
            sb.AppendLine(@"#^^^^^^ without ids ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");

            sb.AppendLine("#====== longest");
            foreach (var source in analysis.CleanGrouped.OrderByDescending(o => o.TotalDuration).Take(10))
            {
                sb.AppendLine(source.Count + " [ " + source.TotalDuration / 1000 + " ] " +
                                  source.Command.Substring(0,
                                      source.Command.Length < stringLimit ? source.Command.Length : stringLimit));
            }
            sb.AppendLine("#^^^^^^ longest");
            sb.AppendLine();

            return sb.ToString();
        }

        public static string OutputCombinedStats(List<TraceAnalysis> analyzedTraces)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("# [combined stats] avg gain - {0}", analyzedTraces.Sum(t => t.GainPercent) / analyzedTraces.Count));
            sb.AppendLine(string.Format("# [combined stats] median gain - {0}", analyzedTraces.OrderBy(t => t.GainPercent).ElementAt(analyzedTraces.Count / 2).GainPercent));

            return sb.ToString();
        }
    }
}
