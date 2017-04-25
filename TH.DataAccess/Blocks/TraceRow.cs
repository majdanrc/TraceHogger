using System;

namespace TH.DataAccess.Blocks
{
    public class TraceRow
    {
        public int RowNumber { get; set; }
        public string TextData { get; set; }
        public long Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public long Reads { get; set; }
        public long Writes { get; set; }

        public TraceRow Clone()
        {
            return new TraceRow
            {
                RowNumber = RowNumber,
                TextData = TextData,
                Duration = Duration,
                StartTime = StartTime,
                EndTime = EndTime,
                Reads = Reads,
                Writes = Writes
            };
        }
    }
}
