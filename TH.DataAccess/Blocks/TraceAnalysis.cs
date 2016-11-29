using System.Collections.Generic;

namespace TH.DataAccess.Blocks
{
    public class TraceAnalysis
    {
        public string Name { get; set; }

        public List<TraceRow> RawRows { get; set; }
        public List<TraceRow> CleanRows { get; set; }
        public List<CountedCommand> RawGrouped { get; set; }
        public List<CountedCommand> CleanGrouped { get; set; }

        public int Total
        {
            get { return RawRows.Count; }
        }
        public int Grouped
        {
            get { return RawGrouped.Count; }
        }
        public int Gain
        {
            get { return Total - Grouped; }
        }
        public decimal GainPercent
        {
            get { return Total > 0 ? ((decimal)Gain / Total) * 100 : 0; }
        }
    }
}
