using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TH.DataAccess.Blocks;
using TH.DataAccess.Repositories;
using TraceHogger.Helpers;
using TraceHogger.Services;

namespace TraceHogger.UI
{
    public partial class MainForm : Form
    {
        private List<TraceAnalysis> _analyzedTraces = new List<TraceAnalysis>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGetTables_Click(object sender, EventArgs e)
        {
            var tables = TableRepository.GetTables("MordorEV").ToList();

            clbTableList.Items.Clear();

            foreach (var table in tables)
            {
                clbTableList.Items.Add(table, CheckState.Unchecked);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var tables = clbTableList.CheckedItems.Cast<string>().ToList();

            var analyzer = new SingleTraceAnalyzer();

            _analyzedTraces = new List<TraceAnalysis>();

            foreach (var table in tables)
            {
                var rows = TraceRowRepository.GetRows(table);
                var analysis = analyzer.InitAnalysis(rows, table);
                _analyzedTraces.Add(analysis);

                rtbAnalysisResults.AppendText(TraceAnalysisOutputHelper.OutputBasicStats(analysis, Convert.ToInt32(nudNumberOfRows.Value)));
                rtbAnalysisResults.AppendText("###### ###### ###### ###### ###### ###### ------------------------------------------------------------- * -->>");
                rtbAnalysisResults.AppendText(Environment.NewLine + Environment.NewLine);
            }

            rtbAnalysisResults.AppendText(TraceAnalysisOutputHelper.OutputCombinedStats(_analyzedTraces));

            var multiAnalyzer = new MultiTraceAnalyzer();

            multiAnalyzer.FindFlocks(_analyzedTraces);

            rtbAnalysisResults.SelectionStart = rtbAnalysisResults.Text.Length;
            rtbAnalysisResults.ScrollToCaret();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbAnalysisResults.Clear();
        }

        private void btnCopyMetrics_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            sb.AppendLine("name;total;reads;writes");

            foreach (var analysis in _analyzedTraces)
            {
                sb.AppendLine(
                    $"{analysis.Name};{analysis.Total};{analysis.CleanRows.Sum(r => r.Reads)};{analysis.CleanRows.Sum(r => r.Writes)}");
            }

            Clipboard.SetText(sb.ToString());
        }

        private void btnCopyRows_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            sb.AppendLine("proc;count");

            foreach (var analysis in _analyzedTraces)
            {
                foreach (var source in analysis.CleanGrouped)
                {
                    sb.AppendLine($"{source.Command.Substring(0, source.Command.Length < 100 ? source.Command.Length : 100)};{source.Count}");
                }

                sb.AppendLine("------ gone with the wind ------;0");
            }

            Clipboard.SetText(sb.ToString());
        }
    }
}
