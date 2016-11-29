namespace TH.DataAccess.Blocks
{
    public class CountedCommand
    {
        public int Count { get; set; }
        public string Command { get; set; }
        public long TotalDuration { get; set; }
        public double AverageDuration { get; set; }
    }
}
