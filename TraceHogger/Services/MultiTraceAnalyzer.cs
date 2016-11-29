using System.Collections.Generic;
using System.Linq;
using TH.DataAccess.Blocks;

namespace TraceHogger.Services
{
    public class MultiTraceAnalyzer
    {
        public void FindFlocks(List<TraceAnalysis> analyzedTraces)
        {
            var flocks = new Dictionary<string, Dictionary<int, List<CountedCommand>>>();

            foreach (var traceAnalysis in analyzedTraces)
            {
                var traceFlocks = traceAnalysis.CleanGrouped.GroupBy(g => g.Count)
                    .Where(k => k.Key > 1 && k.Count() > 1)
                    .ToDictionary(f => f.Key, v => v.Select(c => c).ToList());

                flocks.Add(traceAnalysis.Name, traceFlocks);
            }

            var distinctCommands = flocks.SelectMany(f => f.Value.SelectMany(v => v.Value.Select(c => c.Command))).Distinct();

            foreach (var distinctCommand in distinctCommands)
            {
                var currentCommand = distinctCommand;

                var groups = flocks
                    .Where(f => f.Value.Any(v => v.Value.Any(c => c.Command == currentCommand)))
                    .Select(f => f.Value)
                    .ToList();

                var bar = 2 * 2;
            }

            var foo = 2*2;
        }
    }
}
