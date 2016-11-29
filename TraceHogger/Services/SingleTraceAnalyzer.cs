using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TH.DataAccess.Blocks;

namespace TraceHogger.Services
{
    public class SingleTraceAnalyzer
    {
        public TraceAnalysis InitAnalysis(List<TraceRow> rows, string analysisName)
        {
            var result = new TraceAnalysis
            {
                RawRows = rows, Name = analysisName
            };

            result.RawGrouped = result.RawRows.GroupBy(g => g.TextData).Select(c => new CountedCommand
            {
                Count = c.Count(),
                Command = c.Key,
                TotalDuration = c.Sum(m => m.Duration),
                AverageDuration = c.Average(m => m.Duration)
            }).OrderByDescending(c => c.Count).ToList();

            result.CleanRows = new List<TraceRow>();
            foreach (var traceRow in rows)
            {
                const string clearingRegex = @"=(\d+)";

                var cleanRow = traceRow.Clone();

                var procStart = cleanRow.TextData.IndexOf("exec", StringComparison.Ordinal);
                cleanRow.TextData = cleanRow.TextData.Substring(procStart);
                cleanRow.TextData = Regex.Replace(cleanRow.TextData, clearingRegex, "=#");
                cleanRow.TextData = cleanRow.TextData.Replace("=NULL", "=#");
                cleanRow.TextData = cleanRow.TextData.Replace("exec ", string.Empty);

                //custom cases, I'm lazy right now
                if (cleanRow.TextData.Contains("@CreationDate="))
                {
                    cleanRow.TextData = cleanRow.TextData.Substring(0, 
                        cleanRow.TextData.IndexOf("@CreationDate=", StringComparison.Ordinal));
                }

                result.CleanRows.Add(cleanRow);
            }

            result.CleanGrouped = result.CleanRows.GroupBy(g => g.TextData).Select(c => new CountedCommand
            {
                Count = c.Count(),
                Command = c.Key,
                TotalDuration = c.Sum(m => m.Duration),
                AverageDuration = c.Average(m => m.Duration)
            }).OrderByDescending(c => c.Count).ThenBy(c => c.Command).ToList();

            return result;
        }
    }
}
